using UnityEngine;
using TMPro;
using System.Linq;
using System;

namespace HMF.Thesis.Misc
{
    public class DropDownSetters : MonoBehaviour
    {
        [SerializeField] private TMP_Dropdown _ResolutionsDropdown = null!;
        [SerializeField] private TMP_Dropdown _QualityDropdown = null!;
        [SerializeField] private TMP_Dropdown _ScreenModeDropdown = null!;


        private Resolution[] _resolutions;

        private void Awake() 
        {
            _resolutions = Screen.resolutions.Select(resolution => new Resolution { width = resolution.width, height = resolution.height }).Distinct().ToArray();

            _ResolutionsDropdown.ClearOptions();

            _ResolutionsDropdown.AddOptions(_resolutions.Select(r => $"{r.width} x {r.height}").ToList());
            
            int index = 0;
            var currentResolution = Screen.currentResolution;

            foreach(var res in _resolutions)
            {
                if (res.width == currentResolution.width && 
                    res.height == currentResolution.height)
                {
                    break;
                }
                ++index;
            }
            
            _ResolutionsDropdown.value = index;
            _ResolutionsDropdown.RefreshShownValue();

            //Debug.Log($"Starting index: {index}");
            //Debug.Log($"Starting resolution:{Screen.currentResolution}");

            _QualityDropdown.value = QualitySettings.GetQualityLevel();
            _QualityDropdown.RefreshShownValue();

            switch (Screen.fullScreenMode)
            {
                case FullScreenMode.FullScreenWindow:
                    _ScreenModeDropdown.value = 0;
                    break;

                case FullScreenMode.Windowed:
                    _ScreenModeDropdown.value = 1;
                    break;
                
                default:
                    _ScreenModeDropdown.value = 0;
                    break;
            }
            _ScreenModeDropdown.RefreshShownValue();

            //Debug.Log(_resolutions.Length);
        }

        public void SetResolution(int index)
        {
            if (_resolutions != null)
            {
                var res = _resolutions[index];
                Screen.SetResolution(res.width, res.height, Screen.fullScreenMode);
                //Debug.Log($"Set index: {index}");
                //Debug.Log($"Found resolution: {res}");
                //Debug.Log($"set resolution:{Screen.currentResolution}");
            }
            
        }

        public void SetQuality(int qualityIndex)
        {
            QualitySettings.SetQualityLevel(qualityIndex);
        }

        public void SetScreenOption(int index)
        {
            switch (index)
            {
                case 0:
                    Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
                    break;

                case 1:
                    Screen.fullScreenMode = FullScreenMode.Windowed;
                    break;
                
                default:
                    Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
                    break;
            }
           // Debug.Log(Screen.fullScreenMode);

        }
    }
}
