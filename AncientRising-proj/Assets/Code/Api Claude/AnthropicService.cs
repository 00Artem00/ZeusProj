using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

namespace Code.Api_Claude
{
    public class AnthropicService : MonoBehaviour
    {
        public IEnumerator SendMessageToClaudeCoroutine(string userMessage, System.Action<string> onComplete,
            System.Action<string> onError)
        {
            // Создаем объект запроса
            ModelData.ClaudeRequest request = new ModelData.ClaudeRequest
            {
                model = AnthropicConfig.DefaultModel,
                messages = new ModelData.Message[]
                {
                    new ModelData.Message { role = "user", content = userMessage }
                }
            };

            // Сериализуем запрос в JSON
            string jsonRequest = JsonUtility.ToJson(request);

            // Создаем и настраиваем веб-запрос
            UnityWebRequest webRequest = new UnityWebRequest(AnthropicConfig.BaseUrl + "/v1/messages", "POST");
            byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonRequest);
            webRequest.uploadHandler = new UploadHandlerRaw(bodyRaw);
            webRequest.downloadHandler = new DownloadHandlerBuffer();

            // Устанавливаем заголовки
            webRequest.SetRequestHeader("Content-Type", "application/json");
            webRequest.SetRequestHeader("x-api-key", AnthropicConfig.ApiKey);
            webRequest.SetRequestHeader("anthropic-version", AnthropicConfig.ApiVersion);

            // Отправляем запрос
            yield return webRequest.SendWebRequest();

            // Обрабатываем ответ
            if (webRequest.result != UnityWebRequest.Result.Success)
            {
                onError?.Invoke("Ошибка: " + webRequest.error);
            }
            else
            {
                // Десериализуем ответ
                string jsonResponse = webRequest.downloadHandler.text;
                ModelData.ClaudeResponse response = JsonUtility.FromJson<ModelData.ClaudeResponse>(jsonResponse);

                // Извлекаем текст ответа
                string assistantResponse = "";
                foreach (var item in response.content)
                {
                    if (item.type == "text")
                    {
                        assistantResponse += item.text;
                    }
                }

                onComplete?.Invoke(assistantResponse);
            }
        }
        
        public void SendMessageToClaude(string userMessage, System.Action<string> onComplete, System.Action<string> onError)
        {
            StartCoroutine(SendMessageToClaudeCoroutine(userMessage, onComplete, onError));
        }
    }
}

