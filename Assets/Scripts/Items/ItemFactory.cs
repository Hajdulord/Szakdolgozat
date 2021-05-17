using HMF.Thesis.Interfaces;
using UnityEngine;
using HMF.Thesis.ScriptableObjects;

namespace HMF.Thesis.Items
{
    /// Factory for the current items.
    public static class ItemFactory
    {
        /// Returns an item by its name an data.
        /*!
          \param itemName is the name of the item.
          \param data is the ScriptableObject, that holds the items data.
        */
        public static IItem GetItem(string itemName, ScriptableObject data)
        {

            switch (itemName)
            {
                case "Katana":
                case "Masamune":
                case "Muramasa":
                    if (data is WeaponData)
                        return new Weapon(data as WeaponData);
                    else
                        return null;

                case "Cure Potion":
                    if (data is ConsumableData)
                        return new CurePotion(data as ConsumableData);
                    else
                        return null;

                case "Health Potion":
                    if (data is ConsumableData)
                        return new HealthPotion(data as ConsumableData);
                    else
                        return null;

                case "Fire Burst":
                case "Ice Lance":
                    if (data is MagicFocusData)
                        return new MagicFocus(data as MagicFocusData);
                    else
                        return null;

                default:
                return null;
            }
            
        }
    }
}