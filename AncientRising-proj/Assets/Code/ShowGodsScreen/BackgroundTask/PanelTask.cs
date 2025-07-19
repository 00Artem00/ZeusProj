using TMPro;
using UnityEngine;

namespace Code.ShowGodsScreen.BackgroundTask
{
    public class PanelTask : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _whosePanel;
        [SerializeField] private GameObject _secondTask;
        [SerializeField] private TextMeshProUGUI _secondTaskText;
        [SerializeField] private TMP_InputField _inputField;
        [SerializeField] private GameObject _panelTextSecondTask;
        [SerializeField] private GameObject _doneTask;
        [SerializeField] private TextMeshProUGUI _score;

        public void SetNamePanel(string _name)
        {
            _whosePanel.text = "Task " + _name;
        }

        public void AddSecondTask()
        {
            _panelTextSecondTask.SetActive(true);
        }

        public void ButtonOk()
        {
            if (_inputField.text == "") return;
            _secondTaskText.text = _inputField.text;
            _doneTask.SetActive(false);
            _secondTask.SetActive(true);

            _panelTextSecondTask.SetActive(false);
        }

        public void AddScore()
        {
            _score.text = (PlayerPrefs.GetInt(_whosePanel.text) + 10).ToString();
        }
    }
}
