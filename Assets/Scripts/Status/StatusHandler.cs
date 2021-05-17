using System.Collections.Generic;
using UnityEngine;
using HMF.Thesis.Interfaces;
using System.Collections;

namespace HMF.Thesis.Status
{
    /// Class for handling the lifecircle of statuses.
    public class StatusHandler : IStatusHandler
    {
        private Dictionary<string, StatusBase> _cachedStatuses; ///< Cache of the used statuses.
        private Dictionary<string, (StatusBase Status, float ExpirationTime, float EffectTime)> _activeStatuses; ///< All the active satatuses and their ExpirationTime and EffectTime. 

        private GameObject _gameObject; ///< The GameObject that is the parent of this handler.

        /// Constructor to initialize private fields.
        /*!
          \param gameObject is the parent object of this handler.
        */
        public StatusHandler(GameObject gameObject)
        {
            _cachedStatuses = new Dictionary<string, StatusBase>();
            _activeStatuses = new Dictionary<string, (StatusBase Status, float ExpirationTime, float EffectTime)>();
            _gameObject = gameObject;
        }

        /// Adds a status to the _activeStatuses dictionary and starts it.
        public void AddStatus(string status)
        {
            var alreadyActive = false;

            if(_activeStatuses.ContainsKey(status))
            {
                // happens when a status is alrady active
                _activeStatuses[status] = (_activeStatuses[status].Status, Time.time + _activeStatuses[status].ExpirationTime, _activeStatuses[status].EffectTime);
                alreadyActive = true;
            }
            else if(_cachedStatuses.ContainsKey(status))
            {
                // happens when a status is not active currently but is cached
                var newStatus = StatusFactory.GetStatus(status);
                if (newStatus != null)
                {
                    _activeStatuses.Add(status, (newStatus, Time.time + newStatus.LifeTime, Time.time + newStatus.EffectInterval));
                }
            }
            else
            {
                // happens when a status is completly new
                var newStatus = StatusFactory.GetStatus(status);
                if (newStatus != null)
                {
                    _cachedStatuses.Add(status, newStatus);

                    _activeStatuses.Add(status, (newStatus, Time.time + newStatus.LifeTime, Time.time + newStatus.EffectInterval));
                }
            }

            if (_activeStatuses.ContainsKey(status) && !alreadyActive)
            {
                // starts the Coroutine for the status
                _gameObject.GetComponent<Dummy>().StartCoroutine(Use(_activeStatuses[status].Status));
            }
        }

        /// Starts a statuseffect.
        /*!
          \param status is the status to start.
        */
        private IEnumerator Use(StatusBase status)
        {
            var time = 0f;
            status.PrePhase(_gameObject);

            if (_gameObject.tag == "Player")
            {
                // activates the statusindicator on the player
                ActiveStatusVizualizer.Instance.Add(status.Name);
            }

            while (time < status.LifeTime)
            {
                time += status.EffectInterval;
                
                status.Affect(_gameObject);

                yield return new WaitForSeconds(status.EffectInterval);
            }

            status.CloseUp(_gameObject);

            if (_gameObject.tag == "Player")
            {
                ActiveStatusVizualizer.Instance.Remove(status.Name);
            }

            _activeStatuses.Remove(status.Name);
        }

        /// Stoppes all Statuses.
        public void RemoveAllStatuses()
        {

            foreach (var status in _activeStatuses)
            {
                status.Value.Status.CloseUp(_gameObject);

                if (_gameObject.tag == "Player")
                {
                    ActiveStatusVizualizer.Instance.Remove(status.Value.Status.Name);
                }
            }
            
            _activeStatuses.Clear();

            _gameObject.GetComponent<Dummy>().StopAllCoroutines();
        }

    }
}
