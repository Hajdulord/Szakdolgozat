using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HMF.Thesis.Interfaces
{
    public interface IInventory
    {
        void AddItem(IItem item, int quantity);
        void RemoveItem(IItem item, int quantity);
        void SetUse(IItem item);
        void RemoveUse(int slotNumber);
        IItem GetItem(int slotNumber);
        void RemoveAll();

        Dictionary<string, (IItem Item, int Quantity)> InventoryShelf {get;}
        Dictionary<int, IItem> InUse {get;}
        IItem MainWeapon {get; set;}
        IItem CurrentItem {get; set;}
        int InUseSize { get; }
    }
}
