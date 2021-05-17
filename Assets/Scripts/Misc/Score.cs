using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace HMF.Thesis.Misc
{
    /// The calss for dealing with the scores and scoreboards.
    public class Score : MonoBehaviour
    {
        private bool _timer = false; ///< Sould the timer be runnig.
        private float _elapsedTime = 0f; ///< Elapsed time wile the timer is running.
        private  int _kills = 0; ///< The player's kills.
        private int _deaths = 0; ///< The player's death.

        /// Propery for the _deaths.
        public int Deaths { get => _deaths; set => _deaths = value; }

        /// Propery for the _kills.
        public int Kills { get => _kills; set => _kills = value; }

        /// Propery for the _elapsedTime.
        public float ElapsedTime { get => _elapsedTime; set => _elapsedTime = value; }

        /// Propery for the player's name.
        public string Name { get; set;} = "Anonymus";
        private List<(string Name, int Score)> _scoreBoardEasy  = new List<(string Name, int Score)>(); ///< Scores of the easy scoreboard.
        private List<(string Name, int Score)> _scoreBoardMedium  = new List<(string Name, int Score)>(); ///< Scores of the medium scoreboard.
        private List<(string Name, int Score)> _scoreBoardHard  = new List<(string Name, int Score)>(); ///< Scores of the hard scoreboard.

        /// Singleton instance.
        public static Score Instance {get; private set;}

        /// Sets the singleton instance and loads the existing scores.
        private void Awake() 
        {
            if (Instance == null)
            {
                Instance = this;
            }

            var data = SaveSystem.LoadScore();
            
            if (data != null)
            {
              for (int i = 0; i < data.easyNames.Length; i++)
                {
                    _scoreBoardEasy.Add((data.easyNames[i], data.easyScores[i]));
                }

                for (int i = 0; i < data.mediumNames.Length; i++)
                {
                    _scoreBoardMedium.Add((data.mediumNames[i], data.mediumScores[i]));
                }

                for (int i = 0; i < data.hardNames.Length; i++)
                {
                    _scoreBoardHard.Add((data.hardNames[i], data.hardScores[i]));
                }  
            }

            var name = PersistentData.Instance.Name;

            if (name != string.Empty)
            {
                Name = name;
            }
        }

        /// Increases the _elapsedTime.
        private void Update()
        {
            if (_timer)
            {
                _elapsedTime += Time.deltaTime;
            }
        }

        /// Resets data to zero.
        public void ResetData()
        {
            _elapsedTime = 0f;
            _kills = 0;
            _deaths = 0;
        }

        /// Incement the _kills by one.
        public void IncreaseKills() => ++_kills;

        /// Incement the _deaths by one.
        public void IncreaseDeaths() => ++_deaths;

        /// Set _timer to true.
        public void StartTimer() => _timer = true;

        /// Set _timer to false.
        public void StopTimer() => _timer = false;

        /// Calculates the player's score.
        public int CalculatedScore()
        {
            var score = 0;

            if (_deaths != 0)
            {
                if (Mathf.RoundToInt(_elapsedTime) > 0)
                {
                    if ((Mathf.RoundToInt(_elapsedTime) / 60) == 0)
                    {
                        score = Mathf.FloorToInt(10 *_kills / (_deaths + 1)) + 100;
                    }
                    else
                    {  
                        score = Mathf.FloorToInt(10 * _kills / (_deaths + 1)) * ((Mathf.RoundToInt(_elapsedTime) / 60) + 1);
                    }
                }
            }
            else
            {
                if (Mathf.RoundToInt(_elapsedTime) > 0)
                {
                    if ((Mathf.RoundToInt(_elapsedTime) / 60) == 0)
                    {
                        score = 10 *_kills + 200;
                    }
                    else
                    {  
                        score = 10 * _kills * ((Mathf.RoundToInt(_elapsedTime) / 60 ) + 1) + 10;
                    }
                }
            }

            return score;
        }

        /// Gets the scoreboard of a level.
        /*!
          \param level is levels index.
          \returns List<(string Name, int Score)> the name and the score orderd by the score.
        */
        public List<(string Name, int Score)> GetScoreBoard(int level)
        {
            switch (level)
            {
                case 0:
                    return _scoreBoardEasy.OrderByDescending(s => s.Score).Take(10).ToList();
                case 1:
                    return _scoreBoardMedium.OrderByDescending(s => s.Score).Take(10).ToList();
                case 2:
                    return _scoreBoardHard.OrderByDescending(s => s.Score).Take(10).ToList();
                
                default:
                    return null;
            }
            
        }

        /// Adds a player and its score to the relevent scoreboard.
        /*!
          \param level is levels index.
        */
        public void AddToScoreBoard(int level)
        {
            switch (level)
            {
                case 0:
                    _scoreBoardEasy.Add((Name, CalculatedScore()));
                    break;
                case 1:
                    _scoreBoardMedium.Add((Name, CalculatedScore()));
                    break;
                case 2:
                    _scoreBoardHard.Add((Name, CalculatedScore()));
                    break;
                
                default:
                    break;
            }
        }

        /// Free the singleton instance.
        private void OnDestroy() 
        {
            Instance = null;    
        }
    }
}
