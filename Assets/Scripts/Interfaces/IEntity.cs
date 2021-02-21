using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HMF.Thesis.Interfaces
{
    /// The Interface for all object that are Interactable.
    /// These objects has Health, Speed and other public properties.
    public interface IEntity
    {
        /// Heaalth of the object.
        int Health {get; set;} 
        /// Speed of the object.
        int Speed {get; set;} 
        /// Jump Force of the object.
        int JumpForce {get; set;} 
    }
}
