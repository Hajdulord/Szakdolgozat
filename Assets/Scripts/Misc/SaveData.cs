using HMF.Thesis.Interfaces;
using UnityEngine;

namespace HMF.Thesis.Misc
{

    [System.Serializable]
    public class SaveData
    {
        public int mainWeapon;
        public int[] inUseItems;
        public int[] inUseItemsQuantity;
        public float[] transform;
        public float health;

        public float time;
        public int deaths;
        public int kills;
        public string name;

        public int scene;

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

            inUseItems = new int[4]{-1, -1, -1, -1};
            inUseItemsQuantity = new int[4]{0, 0, 0, 0};

            mainWeapon = ItemSort(inventory.MainWeapon.Name);

            for (int i = 0; i < 4; i++)
            {
                var item = inventory.InUse[i];

                if (item != null)
                {
                    inUseItems[i] = ItemSort(item.Name);
                    inUseItemsQuantity[i] = inventory.InventoryShelf[item.Name].Quantity;
                }
                else
                {
                    inUseItems[i] = ItemSort("");
                }
            }

        }

        private int ItemSort(string name)
        {
            switch (name)
            {
                case "Katana":
                    return 0;

                case "Masamune":
                    return 1;

                case "Muramasa":
                    return 2;

                case "Cure Potion":
                    return 3;

                case "Health Potion":
                    return 4;

                case "Fire Burst":
                    return 5;

                case "Ice Lance":
                    return 6;
                
                case "":
                default:
                    return -1;
            }
        }
    }
}
