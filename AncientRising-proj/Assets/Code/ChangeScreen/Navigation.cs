using UnityEngine;
using Zenject;

namespace Code.ChangeScreen
{
    public class Navigation : MonoBehaviour
    {
        [Inject(Id = "LoginScreen")] private GameObject _login;
        [Inject(Id = "PantheonScreen")] private GameObject _pantheon;
        [Inject(Id = "OracleScreen")] private GameObject _oracle;
        [Inject(Id = "AgoraScreen")] private GameObject _agora;
        [Inject(Id = "SettingsScreen")] private GameObject _settings;
        [Inject(Id = "Buttons")] private GameObject _buttons;
        [Inject(Id = "ProgressBar")] private GameObject _progressBar;
        [Inject] private DiContainer _diContainer;

        private GameObject _currentScreen;
        private GameObject _canvas;
        private GameObject _createdProgressBar;
        
        public void ShowPantheon(bool flag) => ShowPanel(_pantheon, false, flag);
        public void ShowOracle() => ShowPanel(_oracle, true, false);
        public void ShowAgora() => ShowPanel(_agora, true, false);
        public void ShowSettings() => ShowPanel(_settings, true, false);


        private void ShowPanel(GameObject panel, bool deleteProgressBar, bool createButtons)
        {
            DeleteCurrentScreen();
            if (deleteProgressBar)
                DeleteProgressBar();
            else
                CreateProgressBar();
            var tempPanel = _diContainer.InstantiatePrefab(panel, _canvas.transform);
            tempPanel.transform.SetSiblingIndex(0);
            SetCurrentScreen(tempPanel);
            if (createButtons)
                _diContainer.InstantiatePrefab(_buttons, _canvas.transform);
        }

        public void SetCurrentScreen(GameObject screen)
        {
            _currentScreen = screen;
        }

        public void SetCanvas(GameObject canvas)
        {
            _canvas = canvas;
        }

        public GameObject GetCanvas()
        {
            return _canvas != null ? _canvas : null;
        }

        private void DeleteCurrentScreen()
        {
            Destroy(_currentScreen);
        }

        private void CreateProgressBar()
        {
            if (_createdProgressBar != null) return;
            var tempProgressBar =_diContainer.InstantiatePrefab(_progressBar, _canvas.transform);
            tempProgressBar.transform.SetSiblingIndex(_canvas.transform.childCount - 1);
            _createdProgressBar = tempProgressBar;
        }

        public void SetupIndexProgressBar()
        {
            _createdProgressBar.transform.SetSiblingIndex(_canvas.transform.childCount - 1);
        }

        private void DeleteProgressBar()
        {
            Destroy(_createdProgressBar);
        }
    }
}
