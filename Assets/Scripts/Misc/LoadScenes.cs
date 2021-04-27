using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HMF.Thesis.Misc
{
    public class LoadScenes : MonoBehaviour
    {
        [SerializeField] private GameObject _loadingMenu = null!;
        public void LoadScene(int buildIndex)
        {
            _loadingMenu.SetActive(true);
            StartCoroutine(LoadAsyncScene(buildIndex));
        }

        private IEnumerator LoadAsyncScene(int buildIndex)
        {
            var asyncLoad = SceneManager.LoadSceneAsync(buildIndex);

            while (!asyncLoad.isDone)
            {
                yield return null;
            }
        }
    }
}
