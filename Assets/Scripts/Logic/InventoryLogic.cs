using System.Collections.Generic;
using HMF.Thesis.Interfaces;

namespace HMF.Thesis.Logic
{
    public class InventoryLogic : IInventory
    {
        public Dictionary<IItem, int> InventoryShelf { get; private set;}

        private List<IItem> _inUse;
        
        private int _inUseNextIndex;

        private int _inUseSize;

        public IItem MainWeapon { get; set; }
        public IItem CurrentItem { get; set; }

        public Dictionary<int, IItem> InUse {get; private set;}

        public InventoryLogic(int inUseSize, IItem mainWeapon, Dictionary<IItem, int> inventory = null, Dictionary<int, IItem> inUse = null, IItem currentItem = null)
        {
            if (inventory != null)
            {
                InventoryShelf = inventory;
            }
            else
            {
                InventoryShelf = new Dictionary<IItem, int>();    
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
            if (InventoryShelf.ContainsKey(item))
            {
                InventoryShelf[item] += quantity;
            }
            else
            {
                InventoryShelf.Add(item, quantity);
            }
        }

        public void RemoveItem(IItem item, int quantity)
        {
            if (InventoryShelf.ContainsKey(item))
            {
                if (InventoryShelf[item] - quantity > 0)
                {
                    InventoryShelf[item] -= quantity;
                }
                else
                {
                    InventoryShelf.Remove(item);
                }
            }
        }

        public void SetUse(IItem item)
        {
            if (InUse.ContainsKey(_inUseNextIndex))
            {
                _inUseNextIndex = InUse.Count;
            }


            if (InventoryShelf.ContainsKey(item) && _inUseSize > _inUseNextIndex && !InUse.ContainsKey(_inUseNextIndex))
            {
                InUse.Add(_inUseNextIndex, item);
                ++_inUseNextIndex;
            }
        }

        public void RemoveUse(int slotNumber)
        {
            if (InUse.ContainsKey(slotNumber))
            {
                _inUseNextIndex = slotNumber;
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
                    if (!InventoryShelf.ContainsKey(InUse[slotNumber]))
                    {
                        RemoveUse(slotNumber);
                    }
                }   
            }

            return item;
        }
    }
}
