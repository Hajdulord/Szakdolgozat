using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HMF.HMFUtilities.DesignPatterns.StatePattern;

//! Needs Tests!
//! Needs Comments!
namespace HMF.Thesis.Player.PlayerStates
{
    public class Idle : IState
    {
        public void OnEnter()
        {
            Debug.Log("Idle");
        }

        public void OnExit()
        {
            
        }

        public void Tick()
        {
            //Debug.Log("Idle");
        }
    }
}