using Code.ChangeScreen;
using UnityEngine;
using Zenject;

namespace Code.LoginScreen
{
    public class Login : MonoBehaviour
    {
        [Inject(Id = "Navigation")] private GameObject _navigation;

        public void ShowPantheon()
        {
            _navigation.GetComponent<Navigation>().ShowPantheon(true);
        }
    }
}
