using HMF.Thesis.Interfaces;
using UnityEngine;

namespace HMF.Thesis.Misc
{
    /// Data class for saving progress.
    [System.Serializable]
    public class SaveData
    {
        public string mainWeapon; ///< The name of the mainWeapon.
        public string[] inUseItems; ///< The names of the items.
        public int[] inUseItemsQuantity; ///< The quantity of the items.
        public float[] transform; ///< The position of the player.
        public float health; ///< The health of the player.

        public float time; ///< The elapsed time since the start of the game.
        public int deaths; ///< The death count of the player.
        public int kills; ///< The kill count of the player.
        public string name; ///< The name of the player.

        public int scene; ///< The current scene's buildIndex.

        public string date; ///< The current date.

        /// Constructor to set the fields.
        /*!
          \param character is the player's character data.
          \param inventory is the player's inventory data.
          \param pos is the player's position.
          \param sceneIndex is the current scenes buildIndex.
        */
        public SaveData(ICharacter character, IInventory inventory, Transform pos, int sceneIndex)
        {
            time = Score.Instance.ElapsedTime;
            deaths = Score.Instance.Deaths;
            kills = Score.Instance.Kills;
            name = Score.Instance.Name;

            scene = sceneIndex;

            transform = new float[3];
            transform[0] = pos.position.x;
            transform[1] = pos.position.y;
            transform[2] = pos.position.z;

            health = character.Health;

            inUseItems = new string[4]{string.Empty, string.Empty, string.Empty, string.Empty};
            inUseItemsQuantity = new int[4]{0, 0, 0, 0};

            mainWeapon = inventory.MainWeapon.Name;

            for (int i = 0; i < 4; i++)
            {
                if (inventory.InUse.ContainsKey(i))
                {
                    var item = inventory.InUse[i];
                    
                    inUseItems[i] = item.Name;
                    inUseItemsQuantity[i] = inventory.InventoryShelf[item.Name].Quantity;
                }
                else
                {
                    inUseItems[i] = string.Empty;
                }
            }

            date = System.DateTime.Now.ToString();
        }

    }
}
