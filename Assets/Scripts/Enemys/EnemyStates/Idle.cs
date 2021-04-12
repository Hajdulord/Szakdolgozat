using HMF.HMFUtilities.DesignPatterns.StatePattern;
using UnityEngine;

namespace HMF.Thesis.Enemys.EnemyStates
{
    public class Idle : IState
    {
        public void OnEnter()
        {
            Debug.Log("Enemy Idle");
        }

        public void OnExit()
        {
            
        }

        public void Tick()
        {
            
        }
    }
}
