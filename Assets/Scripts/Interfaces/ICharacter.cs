using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HMF.Thesis.Interfaces
{
    /// Interface for a Character.
    public interface ICharacter
    {
        /// The current health of the Character.
        int Health {get; set;}

        /// The max health of the Character.
        int MaxHealth {get;}

        /// The name of the Character.
        string CharacterName {get;}
    }
}