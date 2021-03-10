using System.Collections.Generic;
using System;
using System.Linq;
using HMF.Thesis.Interfaces;

//! Comments and Tests.
namespace HMF.Thesis.Status
{
    public static class StatusFactory
    {
        private static Dictionary<string, Type> _statusesByName;
        private static bool _IsInitialized => _statusesByName != null;

        private static void InitializeFactory()
        {
            if(_IsInitialized)
                return;

            Type objType = typeof(StatusFactory);
            var statusTypes = objType.Assembly.GetTypes().Where(myType => myType.IsAssignableFrom(typeof(IStatus)));

            _statusesByName = new();

            foreach (var type in statusTypes)
            {
                var tempStatus = Activator.CreateInstance(type) as IStatus;

                _statusesByName.Add(tempStatus.Name, type);
            }
        }

        public static IStatus GetStatus(string statusType)
        {
            if (_statusesByName.ContainsKey(statusType))
            {
                Type type = _statusesByName[statusType];
                var status = Activator.CreateInstance(type) as IStatus;

                return status;
            }

            return null;
        }
    }
}
