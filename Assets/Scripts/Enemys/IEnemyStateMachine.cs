using HMF.Thesis.Interfaces;
using HMF.Thesis.ScriptableObjects;
using UnityEngine;

namespace HMF.Thesis.Enemys
{
    public interface IEnemyStateMachine
    {
        GameObject Target {get;}
        IItem Weapon {get;}
        WeaponData WeaponData { get;}
        GameObject ThisGameObject {get; }
    }
}
