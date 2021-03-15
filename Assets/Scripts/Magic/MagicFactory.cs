using System;
using System.Collections.Generic;
using System.Linq;

namespace HMF.Thesis.Magic
{
    public static class MagicFactory
    {
        private static Dictionary<string, Type> _magicByName;
        private static bool _IsInitialized => _magicByName != null;

        private static void InitializeFactory()
        {
            if(_IsInitialized)
                return;

            Type objType = typeof(MagicBase);
            var magicTypes = objType.Assembly.GetTypes().Where(myType => myType.IsClass && myType.IsSubclassOf(typeof(MagicBase)));

            _magicByName = new Dictionary<string, Type>();

            foreach (var type in magicTypes)
            {
                var tempMagic = Activator.CreateInstance(type) as MagicBase;

                _magicByName.Add(tempMagic.Name, type);
            }
        }

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
