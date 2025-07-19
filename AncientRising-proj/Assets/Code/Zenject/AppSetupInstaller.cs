using UnityEngine;
using Zenject;

namespace Code.Zenject
{
    public class AppSetupInstaller : MonoInstaller
    {
        [SerializeField] private Canvas _canvas;
        [SerializeField] private Camera _camera;
        [SerializeField] private GameObject _navigation;
        [SerializeField] private AudioSource _sound;
    
        public override void InstallBindings()
        {
            Container.Bind<Canvas>().FromInstance(_canvas);
            Container.Bind<Camera>().FromInstance(_camera);
            Container.Bind<AudioSource>().FromInstance(_sound);
            Container.Bind<GameObject>().WithId("Navigation").FromInstance(_navigation);
        }
    }
}