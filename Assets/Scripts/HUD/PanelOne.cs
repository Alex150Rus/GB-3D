using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace SpaceJailRunner.HUD
{
    internal class PanelOne: BaseUI, IEventSystemHandler
    {
        [SerializeField] private Text _text;
        private int _counter = 0;
        
        public override void Execute()
        {
            //_text.text = nameof(PanelOne);
            gameObject.SetActive(true);
        }

        public override void Cancel()
        {
            gameObject.SetActive(false);
        }

        public void Message1()
        {
            _counter++;
            _text.text = $"Enemies destroyed: {_counter}";
        }
    }
}