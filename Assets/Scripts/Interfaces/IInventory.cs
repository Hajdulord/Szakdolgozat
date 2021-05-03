using System.Collections.Generic;

namespace HMF.Thesis.Interfaces
{
    /// The interface for the inventory system.
    public interface IInventory
    {
        /// Adds an item to the InventoryShelf.
        /*!
          \param item is the item to add.
          \param quantity is the quantity of the item to add.
        */
        void AddItem(IItem item, int quantity);
        
        /// removes an item from the InventoryShelf.
        /*!
          \param item is the item to remove.
          \param quantity is the quantity of the item to remove.
        */
        void RemoveItem(IItem item, int quantity);
        
        /// Add an item to the InUse inventory.
        /*!
          \param item is the item that is to be added.
        */
        void SetUse(IItem item);
        
        /// removes an item from the InUse inventory.
        /*!
          \param item is the item that is to be removed.
        */
        void RemoveUse(int slotNumber);
        
        /// Gets an item from the InUse inventory.
        /*!
          \param slotnumber is the place of the item you want to get in the array
        */
        IItem GetItem(int slotNumber);

        /// Removes all items in the InUseInventory.
        void RemoveAll();

        /// The actual inventory.
        Dictionary<string, (IItem Item, int Quantity)> InventoryShelf {get;}
        
        /// The items that is available.
        Dictionary<int, IItem> InUse {get;}

        /// The main weapon.
        IItem MainWeapon {get; set;}

        /// The currently used weapon.
        IItem CurrentItem {get; set;}

        /// The size of the InUse inventory.
        int InUseSize { get; }
    }
}
