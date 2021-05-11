using UnityEngine;

namespace HMF.Thesis.Interfaces
{
    /// Interface for a Character.
    public interface ICharacter
    {
        /// The current health of the Character.
        float Health {get; set;}

        /// The max health of the Character.
        int MaxHealth {get;}

        /// The name of the Character.
        string CharacterName {get;}

        /// The Sprite of the Character.
        Sprite CharacterSprite{get;}
    }
}
