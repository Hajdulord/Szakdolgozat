using UnityEngine;
using HMF.Thesis.ScriptableObjects;

namespace HMF.Thesis.Misc
{
    /// All of my scripatbleObjects.
    public class AllScriptableObjects : MonoBehaviour 
    {
        [SerializeField] public WeaponData katana = null!; ///< Data of the katana.
        [SerializeField] public WeaponData masamune = null!; ///< Data of the masamune.
        [SerializeField] public WeaponData muramasa = null!; ///< Data of the muramasa.
        [SerializeField] public ConsumableData curePotion = null!; ///< Data of the curePotion.
        [SerializeField] public ConsumableData healthPotion = null!; ///< Data of the healthPotion.
        [SerializeField] public MagicFocusData iceLance = null!; ///< Data of the iceLance.
        [SerializeField] public MagicFocusData fireBurst = null!; ///< Data of the fireBurst.

        /// Singleton instance.
        public static AllScriptableObjects Instance {get; private set;}

        /// Singleton setup.
        private void Awake() 
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

        /// Freeing the singleton instance.
        private void OnDestroy() 
        {
            Instance = null;    
        }
    }
}