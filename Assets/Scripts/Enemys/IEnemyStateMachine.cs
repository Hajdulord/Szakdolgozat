using HMF.Thesis.Interfaces;
using HMF.Thesis.ScriptableObjects;
using UnityEngine;

namespace HMF.Thesis.Enemys
{
    /// Interface for enemys.
    public interface IEnemyStateMachine
    {
        /// The current target to attack.
        GameObject Target {get; set;}

        /// The actual main weapon.
        IItem Weapon {get;}

        /// The actual magicFocus.
        IItem MagicFocus {get;}

        /// Getter for Weapon data.
        WeaponData WeaponData { get;}

        /// Getter for the gameObject of this script.
        GameObject ThisGameObject {get;}

        /// Getter for magicFocus data.
        MagicFocusData MagicFocusData {get;}

        /// Property for swordPoint.
        GameObject SwordPoint { get; set; }

        /// Getter for Main audio source.
        AudioSource AudioSource { get; }

        /// Getter for the audio source used for sword clases.
        AudioSource AudioSourceAttack { get; }

        /// Getter for the audio source used for screams.
        AudioSource AudioSourceAttack2 { get; }

        /// Getter for tagsToIgnore layermask.
        LayerMask LayersToTarget { get; }
    }
}
