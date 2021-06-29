using System;
using SpaceJailRunner.Score.Interface;

namespace SpaceJailRunner.Score
{
    public class Score : IScoreInformer
    {
        private int _score = 0;
        
        public int ScorePoints
        {
            get => _score;
            set
            {
                _score += value;
                OnScoreChange?.Invoke(_score);
            }
        }

        public event Action<int> OnScoreChange;
    }
}