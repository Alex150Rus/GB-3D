using UnityEngine;
using UnityEngine.UI;

namespace SpaceJailRunner.HUD
{
    internal class PanelOne: BaseUI
    {
        [SerializeField] private Text _text;
        
        public override void Execute()
        {
            _text.text = nameof(PanelOne);
            gameObject.SetActive(true);
        }

        public override void Cancel()
        {
            gameObject.SetActive(false);
        }
    }
}