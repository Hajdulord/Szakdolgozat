using UnityEngine;
using TMPro;
using System.Linq;

namespace HMF.Thesis.Misc
{
    /// Class for the dropdown menu's logic.
    public class DropDownSetters : MonoBehaviour
    {
        [SerializeField] private TMP_Dropdown _ResolutionsDropdown = null!; ///< The dropwdown for the resolutions.
        [SerializeField] private TMP_Dropdown _QualityDropdown = null!; ///< The dropwdown for the quality settings.
        [SerializeField] private TMP_Dropdown _ScreenModeDropdown = null!; ///< The dropwdown for the screen modes.

        private Resolution[] _resolutions; ///< All resolutions.

        /// Setting the default values of the dropdowns.
        private void Awake()
        {
            // getting the distinct resolutions (no refresh rate)
            _resolutions = Screen.resolutions.Select(resolution => new Resolution { width = resolution.width, height = resolution.height }).Distinct().ToArray();

            _ResolutionsDropdown.ClearOptions();

            _ResolutionsDropdown.AddOptions(_resolutions.Select(r => $"{r.width} x {r.height}").ToList());
            
            int index = 0;
            var currentResolution = Screen.currentResolution;
            
            // getting the index of the current resolution
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

            // quality dropdown setup
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
        }

        /// Setting the resolutions.
        public void SetResolution(int index)
        {
            if (_resolutions != null)
            {
                var res = _resolutions[index];
                Screen.SetResolution(res.width, res.height, Screen.fullScreenMode);
            }
            
        }

        /// Setting the quality.
        public void SetQuality(int qualityIndex)
        {
            QualitySettings.SetQualityLevel(qualityIndex);
        }

        /// Setting the Screen mode.
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
        }
    }
}
