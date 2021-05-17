using System.Linq;

namespace HMF.Thesis.Misc
{
    /// Data of the scoreboards.
    [System.Serializable]
    public class ScoreData
    {
        public string[] easyNames; ///< The names of the players in the easy scoreboard.
        public int[] easyScores; ///< The scores of the players in the easy scoreboard.
        public string[] mediumNames; ///< The names of the players in the medium scoreboard.
        public int[] mediumScores; ///< The scores of the players in the medium scoreboard.
        public string[] hardNames; ///< The names of the players in the hard scoreboard.
        public int[] hardScores; ///< The scores of the players in the hard scoreboard.

        /// Constructor that gets the current scoreboard.
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
