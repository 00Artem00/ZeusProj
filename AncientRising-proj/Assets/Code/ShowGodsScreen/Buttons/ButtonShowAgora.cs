using Code.MenuButtons;
using UnityEngine;

namespace Code.ShowGodsScreen.Buttons
{
    public class ButtonShowAgora : MonoBehaviour
    {
        private ControlButtons _сontrolButtons;
        private void Start()
        {
            _сontrolButtons = FindObjectOfType<ControlButtons>();
        }

        public void ShowAgora()
        {
            _сontrolButtons.Agora();
        }
    }
}
