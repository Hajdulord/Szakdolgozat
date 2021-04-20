using UnityEngine;
using UnityEngine.InputSystem;

namespace HMF.Thesis.Misc
{
    public class End : MonoBehaviour
    {
        [SerializeField] private GameObject _endMenu = null!;

        private void OnTriggerEnter2D(Collider2D other) 
        {
            if (other.gameObject.tag == "Player")
            {
                other.gameObject.GetComponent<PlayerInput>().enabled = false;
                _endMenu.SetActive(true);
            }
        }
    }
}
