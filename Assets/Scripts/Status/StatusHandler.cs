using System.Collections.Generic;
using UnityEngine;
using HMF.Thesis.Interfaces;

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

        public void CalculateStatusEffects()
        {
            var time = Time.time;
            var statuesToChange = new List<string>();
            var statuesToRemove = new List<string>();

            foreach (var status in _activeStatuses)
            {
                if (status.Value.EffectTime - time <= 0)
                {
                    status.Value.Status.Affect(_gameObject);
                    Debug.Log($"{status.Value.Status.Name} has effected.");
                    //_activeStatuses[status.Key] = (status.Value.Status, status.Value.ExpirationTime,status.Value.Status.EffectInterval + Time.time);
                    if(!statuesToChange.Contains(status.Key))
                    {
                        statuesToChange.Add(status.Key);
                    }
                }
                if (status.Value.ExpirationTime - time <= 0)
                {
                    //RemoveStatus(status.Key);
                    //Debug.Log($"{status.Value.Status.Name} has ended.");
                    if(!statuesToRemove.Contains(status.Key))
                    {
                        statuesToRemove.Add(status.Key);
                    }
                }
            }

            foreach(var status in statuesToChange)
            {
                _activeStatuses[status] = ( _activeStatuses[status].Status,  _activeStatuses[status].ExpirationTime,  _activeStatuses[status].Status.EffectInterval + Time.time);
            }

            foreach (var status in statuesToRemove)
            {
                RemoveStatus(status);
                Debug.Log($"{status} has ended.");
            }
        }

        public void AddStatus(string status)
        {
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
                _activeStatuses[status].Status.PrePhase(_gameObject);
                _activeStatuses[status].Status.Affect(_gameObject);
                Debug.Log($"{_activeStatuses[status].Status.Name} has effected.");
            }
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