using System.Collections.Generic;
using UnityEngine;
using HMF.Thesis.Interfaces;
using System.Collections;
using System;

//!Comments and Tests.
namespace HMF.Thesis.Status
{
    public class StatusHandler : IStatusHandler
    {
        private Dictionary<string, StatusBase> _cachedStatuses;
        private Dictionary<string, (StatusBase Status, float ExpirationTime, float EffectTime)> _activeStatuses;

        private GameObject _gameObject;

        public StatusHandler(GameObject gameObject)
        {
            _cachedStatuses = new Dictionary<string, StatusBase>();
            _activeStatuses = new Dictionary<string, (StatusBase Status, float ExpirationTime, float EffectTime)>();
            _gameObject = gameObject;
        }

        public void AddStatus(string status)
        {
            //_reset = false;
            var alreadyActive = false;
            if(_activeStatuses.ContainsKey(status))
            {
                _activeStatuses[status] = (_activeStatuses[status].Status, Time.time + _activeStatuses[status].ExpirationTime, _activeStatuses[status].EffectTime);
                alreadyActive = true;
            }
            else if(_cachedStatuses.ContainsKey(status))
            {
                var newStatus = StatusFactory.GetStatus(status);
                if (newStatus != null)
                {
                    _activeStatuses.Add(status, (newStatus, Time.time + newStatus.LifeTime, Time.time + newStatus.EffectInterval));
                }
            }
            else
            {
                var newStatus = StatusFactory.GetStatus(status);
                if (newStatus != null)
                {
                    _cachedStatuses.Add(status, newStatus);

                    _activeStatuses.Add(status, (newStatus, Time.time + newStatus.LifeTime, Time.time + newStatus.EffectInterval));
                }
            }

            if (_activeStatuses.ContainsKey(status) && !alreadyActive)
            {
                //_activeStatuses[status].Status.PrePhase(_gameObject);
                //_activeStatuses[status].Status.Affect(_gameObject);
                //Debug.Log($"{_activeStatuses[status].Status.Name} has effected.");
                _gameObject.GetComponent<Dummy>().StartCoroutine(Use(_activeStatuses[status].Status));
            }
        }

        private IEnumerator Use(StatusBase status)
        {
            var time = 0f;
            status.PrePhase(_gameObject);

            if (_gameObject.tag == "Player")
            {
                ActiveStatusVizualizer.Instance.Add(status.Name);
            }

            
            //Debug.Log($"{status.Name} started.");

            while (time < status.LifeTime)
            {
                time += status.EffectInterval;
                
                status.Affect(_gameObject);

                //Debug.Log($"{status.Name} has effected.");

                yield return new WaitForSeconds(status.EffectInterval);
            }

            status.CloseUp(_gameObject);

            //Debug.Log($"{status.Name} has ended.");

            if (_gameObject.tag == "Player")
            {
                ActiveStatusVizualizer.Instance.Remove(status.Name);
            }

            RemoveStatus(status.Name);
        }

        public void RemoveAllStatuses()
        {
            //_reset = true;

            foreach (var status in _activeStatuses)
            {
                status.Value.Status.CloseUp(_gameObject);
            }
            
            _activeStatuses.Clear();

            _gameObject.GetComponent<Dummy>().StopAllCoroutines();
        }

        public void RemoveStatus(string status)
        {
            if (_activeStatuses.ContainsKey(status))
            {
                _activeStatuses[status].Status.CloseUp(_gameObject);
                _activeStatuses.Remove(status);
            }
        }

    }
}
