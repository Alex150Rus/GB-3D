using UnityEngine;

namespace SpaceJailRunner.HUD
{
    internal abstract class BaseUI: MonoBehaviour
    {
        public abstract void Execute();  
        public abstract void Cancel();
    }
}