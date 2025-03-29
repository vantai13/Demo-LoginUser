using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Demo_Login.Classes
{
    public class FirebaseAuthHelper
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        private readonly string ApiKey;

        public FirebaseAuthHelper()
        {
            // Lấy API Key từ ConfigHelper
            ApiKey = ConfigHelper.GetFirebaseApiKey();
        }

        public class SignUpResponse
        {
            [JsonPropertyName("idToken")]
            public string? IdToken { get; set; }

            [JsonPropertyName("email")]
            public string? Email { get; set; }

            [JsonPropertyName("localId")]
            public string? LocalId { get; set; }
        }

        public class SignInResponse
        {
            [JsonPropertyName("idToken")]
            public string? IdToken { get; set; }

            [JsonPropertyName("email")]
            public string? Email { get; set; }

            [JsonPropertyName("localId")]
            public string? LocalId { get; set; }
        }

        public class UserInfoResponse
        {
            [JsonPropertyName("users")]
            public UserInfo[] Users { get; set; } = Array.Empty<UserInfo>();
        }

        public class UserInfo
        {
            [JsonPropertyName("emailVerified")]
            public bool EmailVerified { get; set; }

            [JsonPropertyName("email")]
            public string? Email { get; set; }
        }

        private class FirebaseErrorResponse
        {
            [JsonPropertyName("error")]
            public FirebaseError? Error { get; set; }
        }

        private class FirebaseError
        {
            [JsonPropertyName("message")]
            public string? Message { get; set; }
        }

        public async Task<SignUpResponse> SignUpWithEmailPassword(string email, string password)
        {
            var requestBody = new
            {
                email,
                password,
                returnSecureToken = true
            };
            var content = new StringContent(
                JsonSerializer.Serialize(requestBody),
                Encoding.UTF8,
                "application/json"
            );

            var response = await _httpClient.PostAsync(
                $"https://identitytoolkit.googleapis.com/v1/accounts:signUp?key={ApiKey}",
                content
            );

            if (!response.IsSuccessStatusCode)
            {
                var errorResponse = await response.Content.ReadAsStringAsync();
                var firebaseError = JsonSerializer.Deserialize<FirebaseErrorResponse>(errorResponse);

                string errorMessage = firebaseError?.Error?.Message ?? "Unknown error";
                switch (errorMessage)
                {
                    case "EMAIL_EXISTS":
                        throw new Exception("Email already exists.");
                    case "WEAK_PASSWORD":
                        throw new Exception("Password is too weak. It must be at least 6 characters long.");
                    case "INVALID_EMAIL":
                        throw new Exception("Invalid email format.");
                    default:
                        throw new HttpRequestException($"Response status code does not indicate success: {(int)response.StatusCode} ({response.ReasonPhrase}). Details: {errorResponse}");
                }
            }

            var responseString = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<SignUpResponse>(responseString);
            return result ?? throw new InvalidOperationException("Failed to deserialize SignUpResponse");
        }

        public async Task<SignInResponse> SignInWithEmailPassword(string email, string password)
        {
            var requestBody = new
            {
                email,
                password,
                returnSecureToken = true
            };
            var content = new StringContent(
                JsonSerializer.Serialize(requestBody),
                Encoding.UTF8,
                "application/json"
            );

            var response = await _httpClient.PostAsync(
                $"https://identitytoolkit.googleapis.com/v1/accounts:signInWithPassword?key={ApiKey}",
                content
            );

            if (!response.IsSuccessStatusCode)
            {
                var errorResponse = await response.Content.ReadAsStringAsync();
                var firebaseError = JsonSerializer.Deserialize<FirebaseErrorResponse>(errorResponse);

                string errorMessage = firebaseError?.Error?.Message ?? "Unknown error";
                switch (errorMessage)
                {
                    case "INVALID_LOGIN_CREDENTIALS":
                        throw new Exception("Invalid email or password.");
                    case "INVALID_EMAIL":
                        throw new Exception("Invalid email format.");
                    case "USER_DISABLED":
                        throw new Exception("This account has been disabled.");
                    default:
                        throw new HttpRequestException($"Response status code does not indicate success: {(int)response.StatusCode} ({response.ReasonPhrase}). Details: {errorResponse}");
                }
            }

            var responseString = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<SignInResponse>(responseString);
            return result ?? throw new InvalidOperationException("Failed to deserialize SignInResponse");
        }

        public async Task SendEmailVerification(string idToken)
        {
            var requestBody = new
            {
                requestType = "VERIFY_EMAIL",
                idToken
            };
            var content = new StringContent(
                JsonSerializer.Serialize(requestBody),
                Encoding.UTF8,
                "application/json"
            );

            var response = await _httpClient.PostAsync(
                $"https://identitytoolkit.googleapis.com/v1/accounts:sendOobCode?key={ApiKey}",
                content
            );

            if (!response.IsSuccessStatusCode)
            {
                var errorResponse = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Response status code does not indicate success: {(int)response.StatusCode} ({response.ReasonPhrase}). Details: {errorResponse}");
            }
        }

        public async Task SendPasswordResetEmail(string email)
        {
            var requestBody = new
            {
                requestType = "PASSWORD_RESET",
                email
            };
            var content = new StringContent(
                JsonSerializer.Serialize(requestBody),
                Encoding.UTF8,
                "application/json"
            );

            var response = await _httpClient.PostAsync(
                $"https://identitytoolkit.googleapis.com/v1/accounts:sendOobCode?key={ApiKey}",
                content
            );

            if (!response.IsSuccessStatusCode)
            {
                var errorResponse = await response.Content.ReadAsStringAsync();
                var firebaseError = JsonSerializer.Deserialize<FirebaseErrorResponse>(errorResponse);

                string errorMessage = firebaseError?.Error?.Message ?? "Unknown error";
                switch (errorMessage)
                {
                    case "EMAIL_NOT_FOUND":
                        throw new Exception("Email not found.");
                    default:
                        throw new HttpRequestException($"Response status code does not indicate success: {(int)response.StatusCode} ({response.ReasonPhrase}). Details: {errorResponse}");
                }
            }
        }

        public async Task<bool> IsEmailVerified(string idToken)
        {
            var requestBody = new
            {
                idToken
            };
            var content = new StringContent(
                JsonSerializer.Serialize(requestBody),
                Encoding.UTF8,
                "application/json"
            );

            var response = await _httpClient.PostAsync(
                $"https://identitytoolkit.googleapis.com/v1/accounts:lookup?key={ApiKey}",
                content
            );

            if (!response.IsSuccessStatusCode)
            {
                var errorResponse = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Response status code does not indicate success: {(int)response.StatusCode} ({response.ReasonPhrase}). Details: {errorResponse}");
            }

            var responseString = await response.Content.ReadAsStringAsync();
            var userInfo = JsonSerializer.Deserialize<UserInfoResponse>(responseString);
            return userInfo?.Users.FirstOrDefault()?.EmailVerified ?? false;
        }
    }
}