namespace Code.Api_Claude
{
    public class ModelData
    {
        [System.Serializable]
        public class Message
        {
            public string role;
            public string content;
        }

        [System.Serializable]
        public class ClaudeRequest
        {
            public string model;
            public Message[] messages;
            public float temperature = 0.7f;
            public int max_tokens = 1000;
        }

        [System.Serializable]
        public class ClaudeResponse
        {
            public string id;
            public string model;
            public string type;
            public Content[] content;
            public Usage usage;
        }

        [System.Serializable]
        public class Content
        {
            public string type;
            public string text;
        }

        [System.Serializable]
        public class Usage
        {
            public int input_tokens;
            public int output_tokens;
        }
    }

    public static class AnthropicConfig
    {
        // Ваш API-ключ от Anthropic
        public static string ApiKey = "YOUR_API_KEY";

        // URL для API Claude
        public static string BaseUrl = "https://api.anthropic.com";

        // Версия API
        public static string ApiVersion = "2023-06-01";

        // Модель Claude по умолчанию
        public static string DefaultModel = "claude-3-7-sonnet-20250219";

    }
}
