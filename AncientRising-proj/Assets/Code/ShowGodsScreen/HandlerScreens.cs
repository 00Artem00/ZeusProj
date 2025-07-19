using UnityEngine;
using Zenject;
using Code.ChangeScreen;

namespace Code.ShowGodsScreen
{
    public class HandlerScreens : MonoBehaviour
    {
        [Inject(Id = "ZeusTemple")] private GameObject _zeus;
        [Inject(Id = "HeraTemple")] private GameObject _hera;
        [Inject(Id = "PoseidonTemple")] private GameObject _poseidon;
        [Inject(Id = "HadesTemple")] private GameObject _hades;
        [Inject(Id = "AthenaTemple")] private GameObject _athena;
        [Inject(Id = "ApolloTemple")] private GameObject _apollo;
        [Inject(Id = "ArtemisTemple")] private GameObject _artemis;
        [Inject(Id = "AresTemple")] private GameObject _ares;
        [Inject(Id = "AphroditeTemple")] private GameObject _aphrodite;
        [Inject(Id = "HephaestusTemple")] private GameObject _hephaestus;
        [Inject(Id = "HermesTemple")] private GameObject _hermes;
        [Inject(Id = "Navigation")] private GameObject _navigation;
        [Inject(Id = "ButtonsBackAndAdd")] private GameObject _buttonBackAndAdd;
        [Inject(Id = "ProgressBar")] private GameObject _progressBar;

        private DiContainer _diContainer;
        private GameObject _currentScreen;
        private GameObject _currentButtonsBackAndAdd;

        private Navigation _navigationComponent;

        public void ShowZeusTemple() => ShowScreen(_zeus);
        public void ShowHeraTemple() => ShowScreen(_hera);
        public void ShowPoseidonTemple() => ShowScreen(_poseidon);
        public void ShowHadesTemple() => ShowScreen(_hades);
        public void ShowAthenaTemple() => ShowScreen(_athena);
        public void ShowApolloTemple() => ShowScreen(_apollo);
        public void ShowArtemisTemple() => ShowScreen(_artemis);
        public void ShowAresTemple() => ShowScreen(_ares);
        public void ShowAphroditeTemple() => ShowScreen(_aphrodite);
        public void ShowHephaestusTemple() => ShowScreen(_hephaestus);
        public void ShowHermesTemple() => ShowScreen(_hermes);

        [Inject]
        private void Construct(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

        private void Start()
        {
            _navigationComponent = _navigation.GetComponent<Navigation>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
                HideCurrentScreen();
        }

        private void ShowScreen(GameObject screen)
        {
            CreateScreen(screen);
            CreateButtons();
            _navigationComponent.SetupIndexProgressBar();
        }

        private void CreateScreen(GameObject screen)
        {
            var tempScreen = _diContainer.InstantiatePrefab(screen, _navigationComponent.GetCanvas().transform);
            _currentScreen = tempScreen;
        }

        private void CreateButtons()
        {
            var tempButtons =
                _diContainer.InstantiatePrefab(_buttonBackAndAdd, _navigationComponent.GetCanvas().transform);
            _currentButtonsBackAndAdd = tempButtons;
        }

        public void HideCurrentScreen()
        {
            Destroy(_currentScreen);
            Destroy(_currentButtonsBackAndAdd);
        }
    }
}
