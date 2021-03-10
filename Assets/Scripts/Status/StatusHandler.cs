using System.Collections;using System.Collections.Generic;
using UnityEngine;

//!Comments and Tests.
namespace HMF.Thesis.Status
{
    public class StatusHandler
    {
        private Dictionary<string, StatusBase> _cachedStatuses;
        private Dictionary<string, StatusBase> _activeStatuses;
        private Dictionary<string, float> _activeStatusesExpirationTime;
        private Dictionary<string, float> _activeStatusesEffectTime;

        public StatusHandler()
        {
            _cachedStatuses = new Dictionary<string, StatusBase>();
            _activeStatuses = new Dictionary<string, StatusBase>();
            _activeStatusesExpirationTime = new Dictionary<string, float>();
            _activeStatusesEffectTime = new Dictionary<string, float>();
        }

        public void CalculateStatusEffects()
        {
            var time = Time.time;
            foreach (var status in _activeStatuses)
            {
                if (_activeStatusesEffectTime[status.Key] - time <= 0)
                {
                    status.Value.Affect();
                }
                if (_activeStatusesExpirationTime[status.Key] - time <= 0)
                {
                    RemoveStatus(status.Key);
                }
            }
        }

        public void AddStatus(string status)
        {
            if(_activeStatuses.ContainsKey(status))
            {
                _activeStatusesExpirationTime[status] = Time.time + _activeStatuses[status].LifeTime;
                _activeStatusesEffectTime[status] = Time.time + _activeStatuses[status].EffectInterval;
            }
            else if(_cachedStatuses.ContainsKey(status))
            {
                var newStatus = StatusFactory.GetStatus(status);
                if (newStatus != null)
                {
                    _activeStatuses.Add(status, newStatus);
                    _activeStatusesExpirationTime.Add(status, Time.time + newStatus.LifeTime);
                    _activeStatusesEffectTime.Add(status, Time.time + newStatus.EffectInterval);
                }
            }
            else
            {
                var newStatus = StatusFactory.GetStatus(status);
                if (newStatus != null)
                {
                    _cachedStatuses.Add(status, newStatus);

                    _activeStatuses.Add(status, newStatus);
                    _activeStatusesEffectTime.Add(status, Time.time + newStatus.EffectInterval);
                    _activeStatusesExpirationTime.Add(status, Time.time + newStatus.LifeTime);
                }
            }
        }

        public void RemoveStatus(string status)
        {
            if (_activeStatuses.ContainsKey(status))
            {
                _activeStatuses.Remove(status);
                _activeStatusesExpirationTime.Remove(status);
                _activeStatusesEffectTime.Remove(status);
            }
        }

    }
}
