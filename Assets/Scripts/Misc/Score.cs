using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace HMF.Thesis.Misc
{
    public class Score : MonoBehaviour
    {
        private bool _timer = false;
        private float _elapsedTime = 0f;
        private  int _kills = 0;
        private int _deaths = 0;

        public int Deaths { get => _deaths;}
        public int Kills { get => _kills;}
        public float ElapsedTime { get => _elapsedTime;}
        public string Name { get; set;} = "Anonymus";
        private List<(string Name, int Score)> _scoreBoardEasy  = new List<(string Name, int Score)>();
        private List<(string Name, int Score)> _scoreBoardMedium  = new List<(string Name, int Score)>();
        private List<(string Name, int Score)> _scoreBoardHard  = new List<(string Name, int Score)>();

        public static Score Instance {get; private set;}

        private void Awake() 
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

        private void Update()
        {
            if (_timer)
            {
                _elapsedTime += Time.deltaTime;
            }
        }

        public void ResetData()
        {
            _elapsedTime = 0f;
            _kills = 0;
            _deaths = 0;
        }

        public void IncreaseKills() => ++_kills;

        public void IncreaseDeaths() => ++_deaths;

        public void StartTimer() => _timer = true;
        public void StopTimer() => _timer = false;

        public int CalculatedScore()
        {
            var score = 0;

            if (_deaths != 0)
            {
                if (Mathf.RoundToInt(_elapsedTime) > 0)
                {
                    if ((Mathf.RoundToInt(_elapsedTime) / 60) == 0)
                    {
                        score = Mathf.FloorToInt(_kills / _deaths);
                    }
                    else
                    {  
                        score = Mathf.FloorToInt(_kills / _deaths) * Mathf.RoundToInt(_elapsedTime) / 60 + 1000;
                    }
                }
                else
                {
                    score = 100000000;
                }
            }
            else
            {
                if (Mathf.RoundToInt(_elapsedTime) > 0)
                {
                    if ((Mathf.RoundToInt(_elapsedTime) / 60) == 0)
                    {
                        score = _kills + 1000;
                    }
                    else
                    {  
                        score = _kills * Mathf.RoundToInt(_elapsedTime) / 60 + 1000;
                    }
                }
                else
                {
                    score = 100000000;
                }
            }

            return score;
        }

        public List<(string Name, int Score)> GetScoreBoard(int level)
        {
            switch (level)
            {
                case 0:
                    return _scoreBoardEasy.OrderBy(s => s.Score).Take(10).ToList();
                case 1:
                    return _scoreBoardMedium.OrderBy(s => s.Score).Take(10).ToList();
                case 2:
                    return _scoreBoardHard.OrderBy(s => s.Score).Take(10).ToList();
                
                default:
                    return null;
            }
            
        }

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
    }
}
