using UnityEngine;

//! Needs corrections for parameters.
namespace HMF.Thesis.Interfaces
{
    public interface IPlayerSateMachine
    {
        Transform CurrentSpawnPoint { get; set; }
        IInventory Inventory { get; }
        IItem CurrentItem { get; }
        bool IsJumping { get; }
        bool IsDashing { get; }
        int MoveDirection { get; }
        float PushBackDir { get; set; }
        float PushBackTime { get; }
        LayerMask LayersToTarget { get; set; }
        bool IsStunned { get; set; }
        LayerMask PickUpLayers { get; set; }
        Vector3 TransformPosition {get; set;}
    }
}