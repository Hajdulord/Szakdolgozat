using UnityEngine;
using HMF.Thesis.ScriptableObjects;

namespace HMF.Thesis.Misc
{
    public class AllScriptableObjects : MonoBehaviour 
    {
        [SerializeField] public WeaponData katana = null!;
        [SerializeField] public WeaponData masamune = null!;
        [SerializeField] public WeaponData muramasa = null!;
        [SerializeField] public ConsumableData curePotion = null!;
        [SerializeField] public ConsumableData healthPotion = null!;
        [SerializeField] public MagicFocusData iceLance = null!;
        [SerializeField] public MagicFocusData fireBurst = null!;

        public static AllScriptableObjects Instance {get; private set;}

        private void Awake() 
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

        private void OnDestroy() 
        {
            Instance = null;    
        }
    }
}