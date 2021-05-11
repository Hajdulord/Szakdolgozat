using UnityEngine;

namespace HMF.Thesis.Interfaces
{
    /// The interface for the Player's statemachine.
    public interface IPlayerStateMachine
    {
        /// The transfor for the current SpawnPoint.
        Transform CurrentSpawnPoint { get; set; }

        /// The Inventory.
        IInventory Inventory { get; }
        
        /// The Current Item.
        IItem CurrentItem { get; set;}

        /// Is the Player Jumping.
        bool IsJumping { get; set;}

        // Is the player Dashing.
        bool IsDashing { get; set;}

        /// The direction of the movement.
        int MoveDirection { get; }

        /// Is the Player Stunned.
        bool IsStunned { get; set; }

        /// The direction of the pushback.
        float PushBackDir { get; set; }

        /// The time of the pushBack inmunity.
        float PushBackTime { get; }

        /// You can set it to the lyers you want to target. It makes the target finding faster, than just tag based identifying.
        LayerMask LayersToTarget { get; set; }

        /// You can set it to the lyers you want to target for picking up items.
        LayerMask PickUpLayers { get; set; }

        /// The position of the player.
        Vector3 TransformPosition {get; set;}

        /// The gameObject for the dasDust animation.
        GameObject DashDust { get; set; }

        /// The gameObject for the swordPoint.
        GameObject SwordPoint { get; set; }

        /// AudioScource for movement based souns.
        AudioSource AudioSource { get; set; }

        /// AudioSource for sword clashes.
        AudioSource AudioSourceAttack { get; set; }
 
        /// AudioSource for screams.
        AudioSource AudioSourceAttack2 { get; set; }

        /// The Player gameObject.
        GameObject ThisGameObject {get; }

        /// Sets the necessary data from a load.
        void Load();
    }
}