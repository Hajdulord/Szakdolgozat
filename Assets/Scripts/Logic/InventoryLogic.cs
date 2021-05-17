using System.Collections.Generic;
using HMF.Thesis.Interfaces;
using UnityEngine;

namespace HMF.Thesis.Logic
{
    /// The logic behind the inventory.
    public class InventoryLogic : IInventory
    {
        public Dictionary<string, (IItem Item, int Quantity)> InventoryShelf { get; private set;} ///< Property for the actual inventory.
        
        private int _inUseNextIndex; ///< the next index in the inUse inventory.
        private int _inUseSize; ///< the actual size of the inUse inventory

        /// Property for the main weapon.
        public IItem MainWeapon { get; set; }

        /// Property for the currently used item.
        public IItem CurrentItem { get; set; }

        /// Property for the usable item inventory.
        public Dictionary<int, IItem> InUse {get; private set;}

        /// Getter for the InUse inventory's size.
        public int InUseSize { get => _inUseSize;}

        /// Constructor for initialization of fields.
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

        /// Adds an item to the InventoryShelf.
        /*!
          \param item is the IItem to add.
          \param quantity is the amount to add.
        */
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

        /// Removes an item from the InventoryShelf if the quantity is zero if not just a decrease.
        /*!
          \param item is the IItem to remove.
          \param quantity is the amount to remove.
        */
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

        /// Adds an item to the InUse inventory.
        /*!
          \param item is the IItem to add.
        */
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

        /// Removes an item from the InUse inventory.
        /*!
          \param slotNumber is the index in the inUse inventory.
        */
        public void RemoveUse(int slotNumber)
        {
            if (InUse.ContainsKey(slotNumber))
            {
                _inUseNextIndex = Mathf.Min(slotNumber, _inUseNextIndex);

                InUse.Remove(slotNumber);
            }
        }

        /// Get an item from the inUse inventory.
        /*!
          \param slotNumber is the index in the inUse inventory.
          \returns IItem.
        */
        public IItem GetItem(int slotNumber)
        {
            IItem item = null;

            if (InUse.ContainsKey(slotNumber))
            {
                item = InUse[slotNumber];

                // only decrease the quantity if not unique
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

        /// Removes all items.
        public void RemoveAll()
        {
            _inUseNextIndex = 0;

            InventoryShelf.Clear();

            InUse.Clear();
        }
    }
}
