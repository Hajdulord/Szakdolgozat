using HMF.Thesis.Interfaces;
using UnityEngine;

namespace HMF.Thesis.Misc
{

    [System.Serializable]
    public class SaveData
    {
        public string mainWeapon;
        public string[] inUseItems;
        public int[] inUseItemsQuantity;
        public float[] transform;
        public float health;

        public float time;
        public int deaths;
        public int kills;
        public string name;

        public int scene;

        public string date;

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
