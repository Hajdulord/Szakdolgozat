using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using HMF.Thesis.Interfaces;
using UnityEngine;

namespace HMF.Thesis.Misc
{
    public static class SaveSystem
    {
        public static void SaveScore()
        {
            var formatter = new BinaryFormatter();

            string path = Application.persistentDataPath + "/scores.hmf";

            var stream = new FileStream(path, FileMode.Create);

            var data = new ScoreData();

            formatter.Serialize(stream, data);

            stream.Close();
        }

        public static ScoreData LoadScore()
        {
            string path = Application.persistentDataPath + "/scores.hmf";

            if (File.Exists(path))
            {
                var formatter = new BinaryFormatter();

                var stream = new FileStream(path, FileMode.Open);

                var data = formatter.Deserialize(stream) as ScoreData;
                
                stream.Close();

                return data;
            }
            else
            {
                return null;
            }
        }

        public static void SavePlayer(ICharacter character, IInventory inventory, Transform pos, int sceneIndex, int saveIndex)
        {
            var formatter = new BinaryFormatter();

            string path = Application.persistentDataPath + "/save" + saveIndex + ".hmf";

            var stream = new FileStream(path, FileMode.Create);

            var data = new SaveData(character, inventory, pos, sceneIndex);

            formatter.Serialize(stream, data);

            stream.Close();
        }

        public static SaveData LoadPlayer(int saveIndex)
        {
            string path = Application.persistentDataPath + "/save" + saveIndex + ".hmf";

            if (File.Exists(path))
            {
                var formatter = new BinaryFormatter();

                var stream = new FileStream(path, FileMode.Open);

                if (stream.Length > 0)
                {
                    var data = formatter.Deserialize(stream) as SaveData;

                    stream.Close();
                    
                    return data;
                }
                else
                {
                    stream.Close();

                    return null;
                }
            }
            else
            {
                return null;
            }
        }
    }
}
