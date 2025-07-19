using UnityEngine;
using Zenject;
using DG.Tweening;

namespace Code.MenuButtons
{
    public class ControlButtons : MonoBehaviour
    {
        [Inject(Id = "Navigation")] private GameObject _navigation;
        [Inject(Id = "BigPantheonButton")]  private GameObject _bigPantheonButton;
        [Inject(Id = "BigOracleButton")]  private GameObject _bigOracleButton;
        [Inject(Id = "BigAgoraButton")]  private GameObject _bigAgoraButton;
        [Inject(Id = "BigSettingsButton")]  private GameObject _bigSettingsButton;
        
        private GameObject _pantheonButton;
        private GameObject _oracleButton;
        private GameObject _agoraButton;
        private GameObject _settingsButton;

        private GameObject _createdButton;
        private DiContainer _diContainer;
        
        [Inject]
        private void Construct(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }
        private void Start()
        {
            _pantheonButton = GameObject.FindGameObjectWithTag("PantheonButton");
            _oracleButton = GameObject.FindGameObjectWithTag("OracleButton");
            _agoraButton = GameObject.FindGameObjectWithTag("AgoraButton");
            _settingsButton = GameObject.FindGameObjectWithTag("SettingsButton");
            Pantheon();
        }

        private void CreateButton(GameObject whatCreate, GameObject fromTransform)
        {
            if (_createdButton != null)
            {
                _createdButton.transform.DOKill();
                Destroy(_createdButton);
            }

            var button =
                _diContainer.InstantiatePrefab(whatCreate, fromTransform.transform);
            button.transform.DOScale(1.6f, .5f);
            _createdButton = button;
        }

        public void Pantheon()
        {
            CreateButton(_bigPantheonButton, _pantheonButton);
            _navigation.GetComponent<ChangeScreen.Navigation>().ShowPantheon(false);
        }

        public void Oracle()
        {
            CreateButton(_bigOracleButton, _oracleButton);
            _navigation.GetComponent<ChangeScreen.Navigation>().ShowOracle();
        }

        public void Agora()
        {
            CreateButton(_bigAgoraButton, _agoraButton);
            _navigation.GetComponent<ChangeScreen.Navigation>().ShowAgora();
        }

        public void Settings()
        {
            CreateButton(_bigSettingsButton, _settingsButton);
            _navigation.GetComponent<ChangeScreen.Navigation>().ShowSettings();
        }
    }
}
