using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HMF.Thesis.Misc
{
    public class LoadScenes : MonoBehaviour
    {
        [SerializeField] private GameObject _loadingMenu = null!;
        [SerializeField] private GameObject _mainMenu = null!;
        [SerializeField] private GameObject _instructionsMenu = null!;
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

        private void Awake() 
        {
            if (PersistentData.Instance.Loaded)
            {
                /*if (Pause.gameIsPaused)
                {
                    Pause.Resume();

                    Menu.Menu.flipPausedBool();
                }*/

                Time.timeScale = 1f;

                //Menu.Menu.flipPausedBool();
                Menu.Menu.flipBool();
                
                _mainMenu.SetActive(false);

                _instructionsMenu.SetActive(true);


            }
        }
    }
}
