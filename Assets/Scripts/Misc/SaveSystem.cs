using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using HMF.Thesis.Interfaces;
using UnityEngine;

namespace HMF.Thesis.Misc
{
    /// Class for saving gamedata to a file.
    public static class SaveSystem
    {
        /// Saves the score using a binaryFormatter to a file.
        public static void SaveScore()
        {
            var formatter = new BinaryFormatter();

            string path = Application.persistentDataPath + "/scores.hmf";

            var stream = new FileStream(path, FileMode.Create);

            var data = new ScoreData();

            formatter.Serialize(stream, data);

            stream.Close();
        }

        /// Loads the score using a binaryFormatter from a file.
        /*!
          \returns ScoreData.
        */
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

        /// Saves the gameData using a binaryFormatter to a file.
        /*!
          \param character is the player's character data.
          \param inventory is the player's inventory data.
          \param pos is the player's position.
          \param sceneIndex is the current scenes buildIndex.
        */
        public static void SavePlayer(ICharacter character, IInventory inventory, Transform pos, int sceneIndex, int saveIndex)
        {
            var formatter = new BinaryFormatter();

            string path = Application.persistentDataPath + "/save" + saveIndex + ".hmf";

            var stream = new FileStream(path, FileMode.Create);

            var data = new SaveData(character, inventory, pos, sceneIndex);

            formatter.Serialize(stream, data);

            stream.Close();
        }

        /// Loads the gameData using a binaryFormatter from a file.
        /*!
          \param saveIndex is the index of the saveslot.
          \returns SaveData.
        */
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
