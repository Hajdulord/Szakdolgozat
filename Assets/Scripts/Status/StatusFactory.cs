using System.Collections.Generic;
using System;
using System.Linq;

namespace HMF.Thesis.Status
{
    /// A factory class that produces statuses using reflection.
    public static class StatusFactory
    {
        
        private static Dictionary<string, Type> _statusesByName; ///< Dictionary that stores the possible statuses' types by name.
        private static bool _IsInitialized => _statusesByName != null; ///< A variable to store if initialization is needed.

        /// Initialize the Factory by filling the _statusesByName dictionary.
        private static void InitializeFactory()
        {
            if(_IsInitialized)
                return;

            /// Gets the statuses usying reflection.
            Type objType = typeof(StatusBase);
            var statusTypes = objType.Assembly.GetTypes().Where(myType => myType.IsClass && myType.IsSubclassOf(typeof(StatusBase)));

            _statusesByName = new Dictionary<string, Type>();

            foreach (var type in statusTypes)
            {
                /// Instantiate the statuses to get its name.
                var tempStatus = Activator.CreateInstance(type) as StatusBase;

                _statusesByName.Add(tempStatus.Name, type);
            }
        }

        /// The factory methode that gives you an instance of the required status.
        /*!
          \param statusType is the name of the status you need.
          \returns StatusBase
        */
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
