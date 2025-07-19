using Code.ShowGodsScreen.Interface;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.ShowGodsScreen.Buttons
{
    public class ButtonBack : MonoBehaviour, IHide
    {
        private HandlerScreens _handlerScreens;
        private Button _button;
        [Inject] private DiContainer _diContainer;

        private void Start()
        {
            _handlerScreens = FindObjectOfType<HandlerScreens>();
            _button = GetComponent<Button>();
            _button.onClick.AddListener(HideScreen);
        }

        public void HideScreen()
        {
            _handlerScreens.HideCurrentScreen();
        }
    }
}
