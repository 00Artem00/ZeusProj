using Code.ChangeScreen;
using UnityEngine;
using Zenject;

namespace Code
{
    public class AppSetup : MonoBehaviour
    {
        [Inject] private Canvas _canvas;
        [Inject(Id = "LoginScreen")] private GameObject _login;
        [Inject] private Camera _camera;
        [Inject(Id = "Navigation")] private GameObject _navigation;
        [Inject] private DiContainer _diContainer;
        [Inject] private AudioSource _sound;

        private void Awake()
        {   
            Instantiate(_camera);
            var canvas = _diContainer.InstantiatePrefab(_canvas);
            var tempLogin = _diContainer.InstantiatePrefab(_login, canvas.transform);
            var temp = _navigation.GetComponent<Navigation>();
            _diContainer.InstantiatePrefab(_sound);
            temp.SetCurrentScreen(tempLogin);
            temp.SetCanvas(canvas);
        }
    }
}
