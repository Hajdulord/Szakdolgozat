using HMF.Thesis.Interfaces;
using HMF.Thesis.ScriptableObjects;
using UnityEngine;

namespace HMF.Thesis.Enemys
{
    public interface IEnemyStateMachine
    {
        GameObject Target {get;}
        IItem Weapon {get;}
        IItem MagicFocus {get;}
        WeaponData WeaponData { get;}
        GameObject ThisGameObject {get;}
        MagicFocusData MagicFocusData {get;}
        GameObject SwordPoint { get; set; }
    }
}
