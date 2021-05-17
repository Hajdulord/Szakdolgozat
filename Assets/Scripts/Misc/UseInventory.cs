using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using HMF.Thesis.Interfaces.ComponentInterfaces;
using TMPro;

namespace HMF.Thesis.Misc
{
    /// Updates the quantity and the image of items.
    public class UseInventory : MonoBehaviour
    {
        [SerializeField] private GameObject _player = null!; ///< Referenc to the player.
        [SerializeField] private List<Image> _images = null!; ///< References to the images.
        [SerializeField] private List<TMP_Text> _itemCounter = null!; ///< The textFields for the counters.
        [SerializeField] private Sprite _emptySlot = null; ///< A transparent sprite.
        
        /// Loads the initial items.
        private void Start() 
        {
            var inventory = _player.GetComponent<IInventoryComponent>().Inventory;

            for (int i = 0; i < 4; i++)
            {
                if (inventory.InUse.ContainsKey(i))
                {
                    var item = inventory.InUse[i];

                    // sets the items sprite to the image
                    _images[i].sprite = item.Sprite;

                    // if an item is unique no need for quantity 
                    if (item.Unique)
                    {
                        _itemCounter[i].text = string.Empty;
                    }
                    else
                    {
                        _itemCounter[i].text = inventory.InventoryShelf[item.Name].Quantity.ToString();
                    }
                }
                else
                {
                    _images[i].sprite = _emptySlot;
                    _itemCounter[i].text = string.Empty;
                }
            }
        }

        /// Updates the image and the quantity of the items in the inUse inventory.
        public void UpdateDisplay()
        {
            var inventory = _player.GetComponent<IInventoryComponent>().Inventory;
            for (int i = 0; i < 4; i++)
            {
                if (inventory.InUse.ContainsKey(i))
                {
                    var item = inventory.InUse[i];

                    // sets the items sprite to the image
                    _images[i].sprite = item.Sprite;
                    
                    // if an item is unique no need for quantity 
                    if (item.Unique)
                    {
                        _itemCounter[i].text = string.Empty;
                    }
                    else
                    {
                        _itemCounter[i].text = inventory.InventoryShelf[item.Name].Quantity.ToString();
                    }
                }
                else
                {
                    _images[i].sprite = _emptySlot;
                    _itemCounter[i].text = string.Empty;
                    // stops the cooldown if an item's quantity is zero.
                    ItemCooldownVisualizer.Instance.StopCountdown(i);
                }

            }
        }

        /// When the script is enabled updates the item display.
        private void OnEnable() => UpdateDisplay();
    }
}
