using SpaceJailRunner.Controller.Interface;
using TMPro;
using UnityEngine;

namespace SpaceJailRunner.Controller.Score
{
    public class ScoreController
    {
        private TextMeshProUGUI _scoreTextField;
        
        public ScoreController(SpaceJailRunner.Score.Score score)
        {
            _scoreTextField = GameObject.Find(NameManager.NameManager.SCORE).GetComponent<TextMeshProUGUI>();
            score.OnScoreChange += ChangeScoreText;

        }

        private void ChangeScoreText(int score)
        {
            _scoreTextField.text = Interpreter(score);
            Debug.Log(score);
        }

        private string Interpreter(int score)
        {
            if (score >= 1000000)
                return $"Score: {((int)(score/1000000)).ToString()}M";
            if (score >= 1000)
                return $"Score: {((int)(score/1000)).ToString()}K";

            return score.ToString();
        }
    }
}