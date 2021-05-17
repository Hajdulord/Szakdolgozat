using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using HMF.Thesis.Interfaces.ComponentInterfaces;
using HMF.Thesis.Interfaces;
using TMPro;

namespace HMF.Thesis.Misc
{
    /// A class for loading and svaing integrated with UI.
    public class SavePlayer : MonoBehaviour
    {
        [SerializeField] private GameObject _loadingMenu = null; ///< Reference to the loading menu.
        [SerializeField] private List<TMP_Text> _slots = null; ///< The textFields for saved data.
        [SerializeField] private List<Button> _slotButtons = null; ///< The buttons for saving and loading.
        [SerializeField] private GameObject _playerGO = null!; ///< Reference for the player.

        private IInventoryComponent _inventory; ///< Reference for the player's inventory.
        private ICharacterComponent _character; ///< Reference for the player's character.
        private IPlayerStateMachine _player; ///< Reference for the player's statemachine.

        private int _selectedIndex = -1; ///< The index of the save slot.

        private List<SaveData> _saves; ///< The loaded save files.

        /// Gets the components from the player and refresses.
        private void Awake() 
        {
            _saves = new List<SaveData>();
            _inventory = _playerGO.GetComponent<IInventoryComponent>();
            _character = _playerGO.GetComponent<ICharacterComponent>();
            _player = _playerGO.GetComponent<IPlayerStateMachine>();

            Refress();
        }

        /// Refresses the loaded data.
        public void Refress() 
        {
            _selectedIndex = -1;

            _saves.Clear();

            for (int i = 0; i < 4; i++)
            {
                var save = SaveSystem.LoadPlayer(i);
                _saves.Add(save);

                if (save == null)
                {
                    _slots[i].text = "Empty";
                }
                else
                {
                    var scene = save.scene switch
                    {
                        0 => "Easy",
                        1 => "Medium",
                        2 => "Hard",
                        _ => string.Empty
                    };

                    _slots[i].text = $"{save.name} on {scene} level with kills: {save.kills} deaths: {save.deaths} time: {save.time} saved at {save.date}";
                }

                _slotButtons[i].image.color = new Color(89 / 255f, 17 / 255f, 77 / 255f);
            }
        }

        /// Changing the color of the selected button.
        /*!
          \param index is the index of the selected button.
        */
        public void Selection(int index)
        {
            if (_selectedIndex > -1)
            {
                _slotButtons[_selectedIndex].image.color = new Color(89 / 255f, 17 / 255f, 77 / 255f);
            }

            _selectedIndex = index;

            _slotButtons[index].image.color = new Color(58 / 255f, 11 / 255f, 50 / 255f);
        }

        /// Loads a sve file.
        public void Load()
        {
            if (_selectedIndex == -1 || _saves[_selectedIndex] == null)
                return;
            
            PersistentData.Instance.CurrentSave = _saves[_selectedIndex];

            _loadingMenu.SetActive(true);
            PersistentData.Instance.Loaded = true;
            StartCoroutine(LoadAsyncScene());
        }

        /// A coroutine for loading scenes async.
        private IEnumerator LoadAsyncScene()
        {
            var asyncLoad = SceneManager.LoadSceneAsync(_saves[_selectedIndex].scene);

            while (!asyncLoad.isDone)
            {
                yield return null;
            }
        }

        /// Saves the current progress.
        public void Save()
        {
            SaveSystem.SavePlayer(_character.Character, 
                _inventory.Inventory, 
                _player.CurrentSpawnPoint, 
                SceneManager.GetActiveScene().buildIndex, 
                _selectedIndex);
        }
    }
}
