using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HMF.Thesis.Magic
{
    public class DestroyAfterAnimationEnds : MonoBehaviour
    {
        [SerializeField] private GameObject _gameObject = null!;
        public void DestroyAfterAnimation()
        {
            Destroy(_gameObject);
        }
    }
}
