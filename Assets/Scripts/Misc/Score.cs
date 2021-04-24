using System.Collections;
using System.Collections.Generic;
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
        public List<(string Name, int Score)> ScoreBoard {get;} = new List<(string Name, int Score)>();

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

        public void CalculateScoreBoard()
        {
            ScoreBoard.Add((Name, CalculatedScore()));
        }
    }
}
