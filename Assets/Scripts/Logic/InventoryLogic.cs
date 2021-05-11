using System.Collections.Generic;
using HMF.Thesis.Interfaces;
using UnityEngine;

namespace HMF.Thesis.Logic
{
    public class InventoryLogic : IInventory
    {
        public Dictionary<string, (IItem Item, int Quantity)> InventoryShelf { get; private set;}
        
        private int _inUseNextIndex;
        private int _inUseSize;

        public IItem MainWeapon { get; set; }
        public IItem CurrentItem { get; set; }

        public Dictionary<int, IItem> InUse {get; private set;}
        public int InUseSize { get => _inUseSize;}

        public InventoryLogic(int inUseSize, 
                            IItem mainWeapon, 
                            Dictionary<string, (IItem Item, int Quantity)> inventory = null, 
                            Dictionary<int, IItem> inUse = null, 
                            IItem currentItem = null)
        {
            if (inventory != null)
            {
                InventoryShelf = inventory;
            }
            else
            {
                InventoryShelf = new Dictionary<string, (IItem Item, int Quantity)>();    
            }

            if (inUse != null)
            {
                InUse = inUse;
                _inUseNextIndex = inUse.Count;
            }
            else
            {
                InUse = new Dictionary<int, IItem>();
                _inUseNextIndex = 0;
            }

            _inUseSize = inUseSize;
            
            CurrentItem = currentItem;

            MainWeapon = mainWeapon;
        }

        public void AddItem(IItem item, int quantity)
        {
            if (InventoryShelf.ContainsKey(item.Name))
            {
                InventoryShelf[item.Name] = (InventoryShelf[item.Name].Item, InventoryShelf[item.Name].Quantity + quantity);
            }
            else
            {
                InventoryShelf.Add(item.Name, (item ,quantity));
            }
        }

        public void RemoveItem(IItem item, int quantity)
        {
            if (InventoryShelf.ContainsKey(item.Name))
            {
                if (InventoryShelf[item.Name].Quantity - quantity > 0)
                {
                    InventoryShelf[item.Name] = (InventoryShelf[item.Name].Item, InventoryShelf[item.Name].Quantity - quantity);
                }
                else
                {
                    InventoryShelf.Remove(item.Name);
                }
            }
        }

        public void SetUse(IItem item)
        {
            if (InUse.ContainsKey(_inUseNextIndex))
            {
                _inUseNextIndex = InUse.Count;
            }

            if (InventoryShelf.ContainsKey(item.Name) && _inUseSize > _inUseNextIndex && !InUse.ContainsKey(_inUseNextIndex))
            {
                InUse.Add(_inUseNextIndex, item);
                ++_inUseNextIndex;
            }
        }

        public void RemoveUse(int slotNumber)
        {
            if (InUse.ContainsKey(slotNumber))
            {
                _inUseNextIndex = Mathf.Min(slotNumber, _inUseNextIndex);

                InUse.Remove(slotNumber);
            }
        }

        public IItem GetItem(int slotNumber)
        {
            IItem item = null;

            if (InUse.ContainsKey(slotNumber))
            {
                item = InUse[slotNumber];

                if(!item.Unique)
                {
                    RemoveItem(InUse[slotNumber], 1);
                    if (!InventoryShelf.ContainsKey(InUse[slotNumber].Name))
                    {
                        RemoveUse(slotNumber);
                    }
                }   
            }

            return item;
        }

        public void RemoveAll()
        {
            _inUseNextIndex = 0;

            InventoryShelf.Clear();

            InUse.Clear();
        }
    }
}
