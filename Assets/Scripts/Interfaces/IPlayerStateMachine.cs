using UnityEngine;

//! Needs corrections for parameters.
namespace HMF.Thesis.Interfaces
{
    public interface IPlayerStateMachine
    {
        Transform CurrentSpawnPoint { get; set; }
        IInventory Inventory { get; }
        IItem CurrentItem { get; set;}
        bool IsJumping { get; set;}
        bool IsDashing { get; set;}
        int MoveDirection { get; }
        float PushBackDir { get; set; }
        float PushBackTime { get; }
        LayerMask LayersToTarget { get; set; }
        bool IsStunned { get; set; }
        LayerMask PickUpLayers { get; set; }
        Vector3 TransformPosition {get; set;}
        GameObject DashDust { get; set; }
        GameObject SwordPoint { get; set; }
        AudioSource AudioSource { get; set; }
        AudioSource AudioSourceAttack { get; set; }
        AudioSource AudioSourceAttack2 { get; set; }
        GameObject ThisGameObject {get; }

        void Load();
    }
}