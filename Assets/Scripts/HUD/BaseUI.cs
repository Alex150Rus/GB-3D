using UnityEngine;
using UnityEngine.EventSystems;

namespace SpaceJailRunner.HUD
{
    internal abstract class BaseUI: MonoBehaviour
    {
        public abstract void Execute();  
        public abstract void Cancel();
    }
}