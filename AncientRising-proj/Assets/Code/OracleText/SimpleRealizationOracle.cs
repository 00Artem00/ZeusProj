using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Code.OracleText
{
    public class SimpleRealizationOracle : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _userInputField;
        [SerializeField] private Button _sendButton;
        [SerializeField] private TextMeshProUGUI _responseText;

        [SerializeField] private List<string> _listAsk;
        private int _index;

        private void Start()
        {
            _sendButton.onClick.AddListener(SendMessage);
        }

        private void SendMessage()
        {
            _userInputField.text = "";

            GetAsk();
        }

        private void GetAsk()
        {
            _responseText.text = _listAsk[_index];
            SetupIndexForList();
        }

        private void SetupIndexForList()
        {
            _index++;
            if (_index ==_listAsk.Count)
                _index = 0;
        }
    }
}
