using System;
using System.Collections.Generic;
using System.Linq;

namespace HMF.Thesis.Magic
{
    /// A factory class that produces magics using reflection.
    public static class MagicFactory
    {
        private static Dictionary<string, Type> _magicByName; ///< Dictionary that stores the possible magic's types by name.
        private static bool _IsInitialized => _magicByName != null;///< A variable to store if initialization is needed.

        /// Initialize the Factory by filling the _magicByName dictionary.
        private static void InitializeFactory()
        {
            if(_IsInitialized)
                return;

            /// Gets the magic usying reflection.
            Type objType = typeof(MagicBase);
            var magicTypes = objType.Assembly.GetTypes().Where(myType => myType.IsClass && myType.IsSubclassOf(typeof(MagicBase)));

            _magicByName = new Dictionary<string, Type>();

            foreach (var type in magicTypes)
            {
                /// Instantiate the magic to get its name.
                var tempMagic = Activator.CreateInstance(type) as MagicBase;

                _magicByName.Add(tempMagic.Name, type);
            }
        }

        /// The factory methode that gives you an instance of the required magic.
        /*!
          \param magicType is the name of the magic you need.
          \returns MagicBase
        */
        public static MagicBase GetMagic(string magicType)
        {
            InitializeFactory();

            if (_magicByName.ContainsKey(magicType))
            {
                Type type = _magicByName[magicType];
                var magic = Activator.CreateInstance(type) as MagicBase;

                return magic;
            }

            return null;
        }
    }
}
