using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using HMF.Thesis.Interfaces.ComponentInterfaces;
using HMF.Thesis.Interfaces;
using TMPro;

namespace HMF.Thesis.Misc
{
    public class SavePlayer : MonoBehaviour
    {
        [SerializeField] private GameObject _saveMenu = null!;
        [SerializeField] private GameObject _instructionsMenu = null!;
        [SerializeField] private GameObject _loadingMenu = null;
        [SerializeField] private List<TMP_Text> _slots = null;
        [SerializeField] private IInventoryComponent _inventory = null!;
        [SerializeField] private ICharacterComponent _character = null!;
        [SerializeField] private IPlayerSateMachine _player = null!;

        private int _selectedIndex = -1;

        public List<SaveData> saves;

        private void Awake() 
        {
            saves = new List<SaveData>();

            for (int i = 0; i < 4; i++)
            {
                var save = SaveSystem.LoadPlayer(i);
                saves.Add(save);

                if (save == null)
                {
                    _slots[i].text = "Empty";
                }
                else
                {
                    _slots[i].text = $"{save.name} with kills: {save.kills} deaths: {save.deaths} time: {save.time} saved at {save.date}";
                }
            }
        }

        public void Selection(int index)
        {
            _selectedIndex = index;
        }

        public void Load()
        {
            if (_selectedIndex == -1)
                return;
            
            PersistentData.Instance.CurrentSave = saves[_selectedIndex];
            if (saves[_selectedIndex].scene != SceneManager.GetActiveScene().buildIndex)
            {
                StartCoroutine(LoadAsyncScene());
                _loadingMenu.SetActive(true);
            }
            else
            {
                _instructionsMenu.SetActive(true);
                _saveMenu.SetActive(false);

                var pos = new Vector3(saves[_selectedIndex].transform[0], saves[_selectedIndex].transform[1], saves[_selectedIndex].transform[2]);

                _player.TransformPosition = pos;
            }
        }

        private IEnumerator LoadAsyncScene()
        {
            var asyncLoad = SceneManager.LoadSceneAsync(saves[_selectedIndex].scene);

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
