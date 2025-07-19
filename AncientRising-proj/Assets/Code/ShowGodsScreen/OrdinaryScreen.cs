using Code.ShowGodsScreen.BackgroundTask;
using UnityEngine;

namespace Code.ShowGodsScreen
{
    public class OrdinaryScreen : MonoBehaviour
    {
        [SerializeField] private string _whoseScreen;
        private PanelTask _panelTask;
        private ProgressBar.ProgressBar _progressBar;

        private void Start()
        {
            _panelTask = FindObjectOfType<PanelTask>();
            _panelTask.SetNamePanel(_whoseScreen);
            _progressBar = FindObjectOfType<ProgressBar.ProgressBar>();
            _progressBar.SetupProgressBar(PlayerPrefs.GetInt(_whoseScreen, 0));
        }
    }
}
