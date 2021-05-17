using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HMF.Thesis.Misc
{
    /// Loads the different scenes.
    public class LoadScenes : MonoBehaviour
    {
        [SerializeField] private GameObject _loadingMenu = null!; ///< Reference to the loading menu.
        [SerializeField] private GameObject _mainMenu = null!; ///< Reference to the main menu.
        [SerializeField] private GameObject _instructionsMenu = null!; ///< Reference to the instruction menu.
        
        /// Starts to load a new scene.
        /*!
          \param buildIndex is scene's index in the build settings.
        */
        public void LoadScene(int buildIndex)
        {
            _loadingMenu.SetActive(true);
            PersistentData.Instance.Loaded = true;
            StartCoroutine(LoadAsyncScene(buildIndex));
        }

        /// Loads the scene asynchronously.
        /*!
          \param buildIndex is scene's index in the build settings.
        */
        private IEnumerator LoadAsyncScene(int buildIndex)
        {
            var asyncLoad = SceneManager.LoadSceneAsync(buildIndex);

            while (!asyncLoad.isDone)
            {
                yield return null;
            }
        }

        /// If there was a scene change loads default values.
        private void Awake() 
        {
            if (PersistentData.Instance.Loaded)
            {
                Time.timeScale = 1f;

                Menu.Menu.isEnd = false;

                Menu.Menu.isPaused = false;

                Pause.gameIsPaused = false;
                
                _mainMenu.SetActive(false);
                
                _instructionsMenu.SetActive(true);
            }
        }
    }
}
