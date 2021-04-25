using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using HMF.Thesis.Interfaces.ComponentInterfaces;
using TMPro;

namespace HMF.Thesis.Misc
{
    public class UseInventory : MonoBehaviour
    {
        [SerializeField] private GameObject _player = null!;
        [SerializeField] private List<Image> _images = null!;
        [SerializeField] private List<TMP_Text> _itemCounter = null!;
        [SerializeField] private Sprite _emptySlot = null;
        private void Start() 
        {
            var inventory = _player.GetComponent<IInventoryComponent>().Inventory;

            for (int i = 0; i < 4; i++)
            {
                if (inventory.InUse.ContainsKey(i))
                {
                    var item = inventory.InUse[i];

                    _images[i].sprite = item.Sprite;

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

        public void UpdateDisplay()
        {
            var inventory = _player.GetComponent<IInventoryComponent>().Inventory;
            for (int i = 0; i < 4; i++)
            {
                if (inventory.InUse.ContainsKey(i))
                {
                    var item = inventory.InUse[i];

                    _images[i].sprite = item.Sprite;
                    
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
                    ItemCooldownVisualizer.Instance.StopCountdown(i);
                }

            }
        }

        private void OnEnable() => UpdateDisplay();
    }
}
