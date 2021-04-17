using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using HMF.Thesis.Interfaces.ComponentInterfaces;

namespace HMF.Thesis.Misc
{
    public class UseInventory : MonoBehaviour
    {
        [SerializeField] private GameObject _player = null!;
        [SerializeField] private List<Image> _images = null!;
        [SerializeField] private Sprite _emptySlot = null;
        private void Start() 
        {
            var inventory = _player.GetComponent<IInventoryComponent>().Inventory;

            for (int i = 0; i < 4; i++)
            {
                if (inventory.InUse.ContainsKey(i))
                {
                    _images[i].sprite = inventory.InUse[i].Sprite;
                }
                else
                {
                    _images[i].sprite = _emptySlot;
                }
            }
        }

        public void UpdateDisplay()
        {
            var inventory = _player.GetComponent<IInventoryComponent>().Inventory;
            for (int i = 0; i < 4; i++)
            {
                if (inventory.InUse.ContainsKey(i))
                {
                    _images[i].sprite = inventory.InUse[i].Sprite;
                }
                else
                {
                    _images[i].sprite = _emptySlot;
                }

            }
        }
    }
}
