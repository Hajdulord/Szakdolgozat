using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

namespace HMF.Thesis.Status
{
    public class ActiveStatusVizualizer : MonoBehaviour
    {
        [SerializeField] private List<Image> _images = null!;

        [SerializeField] private List<Sprite> _sprites = null!;

        private HashSet<string> _activeStatuses;
        
        public static ActiveStatusVizualizer Instance {get; private set;}

        private void Awake() 
        {
            if (Instance == null)
            {
                Instance = this;
            }
            _activeStatuses = new HashSet<string>();
        }

        public void Add(string status)
        {
            _activeStatuses.Add(status);
            //Debug.Log(status);
            UpdateVisual();
        }

        public void Remove(string status)
        {
            _activeStatuses.Remove(status);
            UpdateVisual();
        }

        private void UpdateVisual()
        {
            var i = 0;
                foreach(var status in _activeStatuses)
                {
                    var sprite = _sprites.Where(n => n.name == status);

                    if (sprite.Any())
                    {
                        _images[i].sprite = sprite.First();
                        _images[i].color = Color.white;
                        //Debug.Log("set");
                    }
                    else
                    {
                        _images[i].sprite = null;
                        _images[i].color = new Color(0, 0, 0, 0);
                        //Debug.Log("not set");
                    }
                    ++ i;
                }
            
            for (int j = i; i < _images.Count; i++)
            {
                _images[i].sprite = null;
                _images[i].color = new Color(0, 0, 0, 0);
            }
        }
    }
}
