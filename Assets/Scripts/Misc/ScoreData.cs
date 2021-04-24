using System.Linq;

namespace HMF.Thesis.Misc
{
    [System.Serializable]
    public class ScoreData
    {
        public string[] easyNames;
        public int[] easyScores;
        public string[] mediumNames;
        public int[] mediumScores;
        public string[] hardNames;
        public int[] hardScores;

        public ScoreData()
        {
            easyNames = Score.Instance.GetScoreBoard(0).Select(t => t.Name).ToArray();
            easyScores = Score.Instance.GetScoreBoard(0).Select(t => t.Score).ToArray();

            mediumNames = Score.Instance.GetScoreBoard(1).Select(t => t.Name).ToArray();
            mediumScores = Score.Instance.GetScoreBoard(1).Select(t => t.Score).ToArray();

            hardNames = Score.Instance.GetScoreBoard(2).Select(t => t.Name).ToArray();
            hardScores = Score.Instance.GetScoreBoard(2).Select(t => t.Score).ToArray();
        }
    }
}
