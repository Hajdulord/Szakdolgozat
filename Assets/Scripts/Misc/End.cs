using UnityEngine;
using UnityEngine.InputSystem;
using HMF.Thesis.Status;

namespace HMF.Thesis.Misc
{
    public class End : MonoBehaviour
    {
        [SerializeField] private GameObject _endMenu = null!;
        [SerializeField] private GameObject _enemys = null!;

        private void OnTriggerEnter2D(Collider2D other) 
        {
            if (other.gameObject.tag == "Player")
            {
                Score.Instance.StopTimer();
                Debug.Log($"Name: {Score.Instance.Name}\nTime: {Score.Instance.ElapsedTime}\nKills: {Score.Instance.Kills}\nDeaths: {Score.Instance.Deaths}\nScore: {Score.Instance.CalculatedScore()}");

                other.gameObject.GetComponent<PlayerInput>().enabled = false;
                var dummy = other.gameObject.GetComponent<Dummy>();

                dummy?.StopAllCoroutines();
                dummy.enabled = false;

                _enemys.SetActive(false);
                _endMenu.SetActive(true);
            }
        }
    }
}
