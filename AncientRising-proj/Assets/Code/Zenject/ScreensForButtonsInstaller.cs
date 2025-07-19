using UnityEngine;
using Zenject;

namespace Code.Zenject
{
    public class ScreensForButtonsInstaller : MonoInstaller
    {
        [SerializeField] private GameObject _login;
        [SerializeField] private GameObject _pantheon;
        [SerializeField] private GameObject _oracle;
        [SerializeField] private GameObject _agora;
        [SerializeField] private GameObject _settings;
        [SerializeField] private GameObject _progressBar;
        
        public override void InstallBindings()
        {
            Container.Bind<GameObject>().WithId("LoginScreen").FromInstance(_login);
            Container.Bind<GameObject>().WithId("PantheonScreen").FromInstance(_pantheon);
            Container.Bind<GameObject>().WithId("OracleScreen").FromInstance(_oracle);
            Container.Bind<GameObject>().WithId("AgoraScreen").FromInstance(_agora);
            Container.Bind<GameObject>().WithId("SettingsScreen").FromInstance(_settings);
            Container.Bind<GameObject>().WithId("ProgressBar").FromInstance(_progressBar);
        }
    }
}