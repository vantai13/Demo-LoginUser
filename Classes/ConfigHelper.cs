using System;
using System.IO;
using System.Text.Json;

namespace Demo_Login.Classes
{
    public static class ConfigHelper
    {
        private const string SecretsFilePath = "..\\..\\..\\secrets.json";

        public static string GetFirebaseApiKey()
        {
            if (File.Exists(SecretsFilePath))
            {
                string json = File.ReadAllText(SecretsFilePath);
                var config = JsonSerializer.Deserialize<SecretsConfig>(json);
                string apiKey = config?.FirebaseApiKey;

                if (!string.IsNullOrEmpty(apiKey))
                {
                    return apiKey;
                }
            }

            throw new InvalidOperationException(
                $"Firebase API Key not found. Please create a '{SecretsFilePath}' file with the 'FirebaseApiKey' field."
            );
        }

        private class SecretsConfig
        {
            public string FirebaseApiKey { get; set; }
        }
    }
}