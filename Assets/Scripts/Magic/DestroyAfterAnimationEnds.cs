using UnityEngine;

namespace HMF.Thesis.Magic
{
    /// Destroys the animation GameObject after the animation ends.
    public class DestroyAfterAnimationEnds : MonoBehaviour
    {
        [SerializeField] private GameObject _gameObject = null!; ///< Animation's GameObject.
        
        /// Destroys the GameObject.
        public void DestroyAfterAnimation() => Destroy(_gameObject);
    }
}
