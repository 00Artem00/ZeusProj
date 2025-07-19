using UnityEngine;
using Zenject;

namespace Code.Zenject
{
    public class ScreensGodsInstaller : MonoInstaller
    {
        [SerializeField] private GameObject _zeus;
        [SerializeField] private GameObject _hera;
        [SerializeField] private GameObject _poseidon;
        [SerializeField] private GameObject _hades;
        [SerializeField] private GameObject _athena;
        [SerializeField] private GameObject _apollo;
        [SerializeField] private GameObject _artemis;
        [SerializeField] private GameObject _ares;
        [SerializeField] private GameObject _aphrodite;
        [SerializeField] private GameObject _hephaestus;
        [SerializeField] private GameObject _hermes;
        [SerializeField] private GameObject _buttonsBackAndAdd;
        
        public override void InstallBindings()
        {
            Container.Bind<GameObject>().WithId("ZeusTemple").FromInstance(_zeus);
            Container.Bind<GameObject>().WithId("HeraTemple").FromInstance(_hera);
            Container.Bind<GameObject>().WithId("PoseidonTemple").FromInstance(_poseidon);
            Container.Bind<GameObject>().WithId("HadesTemple").FromInstance(_hades);
            Container.Bind<GameObject>().WithId("AthenaTemple").FromInstance(_athena);
            Container.Bind<GameObject>().WithId("ApolloTemple").FromInstance(_apollo);
            Container.Bind<GameObject>().WithId("ArtemisTemple").FromInstance(_artemis);
            Container.Bind<GameObject>().WithId("AresTemple").FromInstance(_ares);
            Container.Bind<GameObject>().WithId("AphroditeTemple").FromInstance(_aphrodite);
            Container.Bind<GameObject>().WithId("HephaestusTemple").FromInstance(_hephaestus);
            Container.Bind<GameObject>().WithId("HermesTemple").FromInstance(_hermes);
            Container.Bind<GameObject>().WithId("ButtonsBackAndAdd").FromInstance(_buttonsBackAndAdd);
        }
    }
}