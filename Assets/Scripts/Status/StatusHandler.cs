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

        public StatusHandler()
        {
            _cachedStatuses = new Dictionary<string, StatusBase>();
            _activeStatuses = new Dictionary<string, (StatusBase Status, float ExpirationTime, float EffectTime)>();
        }

        public void CalculateStatusEffects()
        {
            var time = Time.time;
            foreach (var status in _activeStatuses)
            {
                if (status.Value.EffectTime - time <= 0)
                {
                    status.Value.Status.Affect();
                    _activeStatuses[status.Key] = (status.Value.Status, status.Value.ExpirationTime,status.Value.Status.EffectInterval + Time.time);
                }
                if (status.Value.ExpirationTime - time <= 0)
                {
                    RemoveStatus(status.Key);
                }
            }
        }

        public void AddStatus(string status)
        {
            if(_activeStatuses.ContainsKey(status))
            {

                _activeStatuses[status] = (_activeStatuses[status].Status, Time.time + _activeStatuses[status].ExpirationTime, _activeStatuses[status].EffectTime);
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
        }

        public void RemoveStatus(string status)
        {
            if (_activeStatuses.ContainsKey(status))
            {
                _activeStatuses.Remove(status);
            }
        }

    }
}
