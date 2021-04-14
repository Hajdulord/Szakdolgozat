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
        private void Start() 
        {
            var inventory = _player.GetComponent<IInventoryComponent>().Inventory;

            for (int i = 0; i < inventory.InUse.Count; i++)
            {
                if (inventory.InUse[i] != null)
                {
                    _images[i].sprite = inventory.InUse[i].Sprite;
                }
            }
        }

        public void UpdateDisplay()
        {
            var inventory = _player.GetComponent<IInventoryComponent>().Inventory;
            for (int i = 0; i < inventory.InUse.Count; i++)
            {
                if (inventory.InUse[i] != null)
                {
                    _images[i].sprite = inventory.InUse[i].Sprite;
                }

            }
        }
    }
}
