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
    public class SavePlayer : MonoBehaviour
    {
        [SerializeField] private GameObject _saveMenu = null!;
        [SerializeField] private GameObject _endMenu = null!;
        [SerializeField] private GameObject _enemys = null!;
        [SerializeField] private GameObject _items = null!;
        [SerializeField] private GameObject _instructionsMenu = null!;
        [SerializeField] private GameObject _loadingMenu = null;
        [SerializeField] private List<TMP_Text> _slots = null;
        [SerializeField] private List<Button> _slotButtons = null;
        [SerializeField] private GameObject _playerGO = null!;
        [SerializeField] private AudioListener _listener = null!;

        private IInventoryComponent _inventory;
        private ICharacterComponent _character;
        private IPlayerStateMachine _player;

        private int _selectedIndex = -1;

        private List<SaveData> _saves;

        private void Awake() 
        {
            _saves = new List<SaveData>();
            _inventory = _playerGO.GetComponent<IInventoryComponent>();
            _character = _playerGO.GetComponent<ICharacterComponent>();
            _player = _playerGO.GetComponent<IPlayerStateMachine>();

            Refress();
        }

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

        public void Selection(int index)
        {
            if (_selectedIndex > -1)
            {
                _slotButtons[_selectedIndex].image.color = new Color(89 / 255f, 17 / 255f, 77 / 255f);
            }

            _selectedIndex = index;

            _slotButtons[index].image.color = new Color(58 / 255f, 11 / 255f, 50 / 255f);
        }

        public void Load()
        {
            //Time.timeScale = 1;
            if (_selectedIndex == -1 || _saves[_selectedIndex] == null)
                return;
            
            PersistentData.Instance.CurrentSave = _saves[_selectedIndex];
            
            if (_saves[_selectedIndex].scene != SceneManager.GetActiveScene().buildIndex)
            {
                _loadingMenu.SetActive(true);
                PersistentData.Instance.Loaded = true;
                StartCoroutine(LoadAsyncScene());
            }
            else
            {
                if (Pause.gameIsPaused)
                {
                    Pause.Resume();

                    Menu.Menu.flipPausedBool();
                }

                if (_playerGO.activeInHierarchy)
                {
                    _player.Load();
                    _playerGO.SetActive(false);
                    _listener.enabled = true;
                }

                //Menu.Menu.flipPausedBool();
                Menu.Menu.flipBool();
                /*_player.TransformPosition  = new Vector3(
                                                    _saves[_selectedIndex].transform[0], 
                                                    _saves[_selectedIndex].transform[1], 
                                                    _saves[_selectedIndex].transform[2]);*/
                
                _instructionsMenu.SetActive(true);

                _saveMenu.SetActive(false);

                _endMenu.SetActive(false);

                _enemys.SetActive(true);

                for (int i = 0; i < _items.transform.childCount; i++)
                {
                    _items.transform.GetChild(i).gameObject.SetActive(true);
                }

            }
        }

        private IEnumerator LoadAsyncScene()
        {
            var asyncLoad = SceneManager.LoadSceneAsync(_saves[_selectedIndex].scene);

            while (!asyncLoad.isDone)
            {
                yield return null;
            }
        }

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
