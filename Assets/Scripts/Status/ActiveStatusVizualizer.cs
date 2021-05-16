using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

namespace HMF.Thesis.Status
{
    /// A calss for udating the active statues in the UI.
    public class ActiveStatusVizualizer : MonoBehaviour
    {
        [SerializeField] private List<Image> _images = null!; ///< A list for Images in the UI.

        [SerializeField] private List<Sprite> _sprites = null!; ///< The Sprites for the statuses.

        private HashSet<string> _activeStatuses; ///< The set for the currently active statuses.
        
        /// Singleton instance.
        public static ActiveStatusVizualizer Instance {get; private set;}

        /// Sets the singleton instance and initialize the _activeStatuses set.
        private void Awake() 
        {
            /// Singleton check
            if (Instance == null)
            {
                Instance = this;
            }

            _activeStatuses = new HashSet<string>();
        }

        /// Add a new Status to the _activeStatuses set and Updates the images.
        /*!
          \param status is the name of the status.
        */
        public void Add(string status)
        {
            _activeStatuses.Add(status);
            UpdateVisual();
        }

        /// Remove a  Status from the _activeStatuses set and Updates the images.
        /*!
          \param status is the name of the status.
        */
        public void Remove(string status)
        {
            _activeStatuses.Remove(status);
            UpdateVisual();
        }

        /// Updates the UI to represent the _activeStatuses set.
        private void UpdateVisual()
        {
            var i = 0;
                foreach(var status in _activeStatuses)
                {
                    // gets the sprite by the status' name
                    var sprite = _sprites.Where(n => n.name == status);

                    if (sprite.Any())
                    {
                        _images[i].sprite = sprite.First();
                        _images[i].color = Color.white;
                    }
                    else
                    {
                        // if the status is not active sets the image transparent.
                        _images[i].sprite = null;
                        _images[i].color = new Color(0, 0, 0, 0);
                    }
                    ++ i;
                }
            
            // sets the remaining images transparent.
            for (int j = i; i < _images.Count; i++)
            {
                _images[i].sprite = null;
                _images[i].color = new Color(0, 0, 0, 0);
            }
        }

        // If the Object is destroyed sets the Singleton instance null.
        private void OnDestroy() 
        {
            Instance = null;    
        }
    }
}
