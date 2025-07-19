using UnityEngine;
using Zenject;

namespace Code.Zenject
{
    public class ControlButtonInstaller : MonoInstaller
    {
        [SerializeField] private GameObject _buttons;
        
        [SerializeField] private GameObject _bigPantheonButton;
        [SerializeField] private GameObject _bigOracleButton;
        [SerializeField] private GameObject _bigAgoraButton;
        [SerializeField] private GameObject _bigSettingsButton;
        
        public override void InstallBindings()
        {
            Container.Bind<GameObject>().WithId("Buttons").FromInstance(_buttons);
            
            Container.Bind<GameObject>().WithId("BigPantheonButton").FromInstance(_bigPantheonButton);
            Container.Bind<GameObject>().WithId("BigOracleButton").FromInstance(_bigOracleButton);
            Container.Bind<GameObject>().WithId("BigAgoraButton").FromInstance(_bigAgoraButton);
            Container.Bind<GameObject>().WithId("BigSettingsButton").FromInstance(_bigSettingsButton);
        }
    }
}