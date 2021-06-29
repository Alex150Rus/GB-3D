using System;

namespace SpaceJailRunner.Score.Interface
{
    internal interface IScoreInformer
    {
        public event Action<int> OnScoreChange;
    }
}