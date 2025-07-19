using Code.Api_Claude;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Code.OracleText
{
    public class ChatUIController : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _userInputField;
        [SerializeField] private Button _sendButton;
        [SerializeField] private TextMeshProUGUI _responseText;
        [SerializeField] private GameObject _loadingIndicator;
        
        private AnthropicService _anthropicService;

        private void Start()
        {
            _anthropicService = FindObjectOfType<AnthropicService>();
            _sendButton.onClick.AddListener(SendMessage);
        }

        private void SendMessage()
        {
            string userMessage = _userInputField.text;
            if (string.IsNullOrEmpty(userMessage))
                return;

            _userInputField.text = "";

            _anthropicService.SendMessageToClaude(userMessage, OnMessageReceived, OnMessageError);
        }

        private void OnMessageReceived(string response)
        {
            _responseText.text = response;
        }

        private void OnMessageError(string error)
        {
            _responseText.text = "Error: " + error;
            Debug.LogError(error);
        }
    }
}
