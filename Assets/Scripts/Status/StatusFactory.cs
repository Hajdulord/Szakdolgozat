using System.Collections.Generic;
using System;
using System.Linq;

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

            Type objType = typeof(StatusBase);
            var statusTypes = objType.Assembly.GetTypes().Where(myType => myType.IsClass && myType.IsSubclassOf(typeof(StatusBase)));

            _statusesByName = new Dictionary<string, Type>();

            foreach (var type in statusTypes)
            {
                var tempStatus = Activator.CreateInstance(type) as StatusBase;

                _statusesByName.Add(tempStatus.Name, type);
            }
        }

        public static StatusBase GetStatus(string statusType)
        {
            InitializeFactory();

            if (_statusesByName.ContainsKey(statusType))
            {
                Type type = _statusesByName[statusType];
                var status = Activator.CreateInstance(type) as StatusBase;

                return status;
            }

            return null;
        }
    }
}
