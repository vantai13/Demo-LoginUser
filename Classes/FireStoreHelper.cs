using Google.Cloud.Firestore;

public static class FireStoreHelper
{
    static string fireconfig = @"
{
    ""type"": ""service_account"",
    ""project_id"": ""fir-login-4f488"",
    ""private_key_id"": ""1be9cbdc7675fb9f0cbf539fd6c32ac6f1726d4e"",
    ""private_key"": ""-----BEGIN PRIVATE KEY-----\nMIIEvgIBADANBgkqhkiG9w0BAQEFAASCBKgwggSkAgEAAoIBAQCTOTXEBBMcQZ1A\nDJYQzfKldjEPCCTngNVfv68e0YkVFynm1gnxIOGVHCiafQNxCJvZsc27/XVMwHuM\n58q026AMLgMtsfHmqa7W3Gz4zH3UHc6op3Zbu7witSr7j8YsiuW/lztgXBNGoY0C\nR1Y9VCKXEmJSQbiEiyTW04scDWvZfregPEVbzgTYUfV+HPoa7JoMpxGKP87Fomjm\n+hF+vW61VDu498F/ib5N8NeA5qxGkIEQchXOJhCZTcrX1vMzziGrfzV43zoRevx2\neeSHI1yzJpIbJsOWq9tNJfjG7655BO/JKirl6Ba06l9qhgC7c9+xY1DZnjHzT4ge\nYrFK44RhAgMBAAECggEAOp6AZGxU6Z7MjHiWddlywGQHk5skCpN3IhkyEpzOrrma\n4wEdU0fK2jKsjhqxuJt7ZpoPt0broiRP7WJLiWibWM4nUNX14eh1J7L7prLRdRhr\nNSb8jvj4p38oPqLX/ttNMFR4fV0cBbcEbMBXu7KY1TsqL+NgI1I92FXBoWlMpHvf\n6h15huQ3wiSxRaZi6633VtQARvCVhuaV7eucBYCgQ+suJbYAnA6JNDWBrdyxE7xk\nCCQ0Elmrcz4qpqNCAP2cT2ehPyeFLrltOR0kDCvOxfVCA9qkkwsSZlRp04n20jwy\nAxgufThT+g/HOh82dBW7DRXvwj89rOPakg8PB7r2owKBgQDDbxNPq96FS3p+kQCd\ngfpp5d7/0sb6wrES52/wGxMvf8ay6kLrGouqAaJix6lAiHHxr+EPNuDlXZ494udc\no6v5h4OdqRrHhrAsQipNHmzchyfaUO0u7Pfk+1cTA+jNCmft091Jt1XDf6Uw6KKE\nR7IkwDysQfCgbTTPfutEJAhXuwKBgQDA2VFh6b3SQkhJPYLbLn+U6Ya+ty8WgJWr\nFuhlKLyhEETDr6tfQpmyG3kAEXoPZaxUNHOIhoa1uVAa9zP4hzgu7eSo1HvNY83j\nsAXJFhmhogKS3zfEN6tTGTBRsUWdfM8Wepp61brBzswO9nPfEv03AJ9J/uOrUHma\nkb7JfD8skwKBgGhUYbDEhZQPCSOL8RIkkzP5PSTAtuyjBriayI0bRxCyW7ajjHnJ\nwAlPugqVn+sNbBaj17exijmn0pQjD3PLBEG/cCm4Xs1pP59A6ygkN+U6WbIYRaYp\nZuTcsE08ZwkepwC1e4qgzq4A9IS5jBil1Zn87ebfhL9/zROAI8RKoBGFAoGBALjb\nV8R4j2mN+cai/N1nHAq9M1l7NNroFQ+0XL4jJ3Vop9HAgZBFwhhVd05Wcl9yAZeR\n07Fp6pUldqDyl1HDJFrv1MD1NVszMTfxEgqocZdbOgZZjBY9mq+ENKoKOIX3Dnco\nvQ3D9Eo1Fau+GGIbzLe9k/MVLl2YPYip7m0q+U+bAoGBAIwENTazlt1BQXpwxE7Q\nSdlhqFohZjC0esGs1ysHoOja9c3gW5SvGBTzJWZbYt4HvaT6Y72fmwL17UAB3tAC\nhdl0w41VVB2XO0mrV1b/8Pd3LMv8oEIkDEmM8j5jn72ESNkxwHFg3CxjMwV4gr/K\n45r0BPTiOGyxkLieXrbUlxC+\n-----END PRIVATE KEY-----\n"",
    ""client_email"": ""firebase-adminsdk-fbsvc@fir-login-4f488.iam.gserviceaccount.com"",
    ""client_id"": ""114536999730249781069"",
    ""auth_uri"": ""https://accounts.google.com/o/oauth2/auth"",
    ""token_uri"": ""https://oauth2.googleapis.com/token"",
    ""auth_provider_x509_cert_url"": ""https://www.googleapis.com/oauth2/v1/certs"",
    ""client_x509_cert_url"": ""https://www.googleapis.com/robot/v1/metadata/x509/firebase-adminsdk-fbsvc%40fir-login-4f488.iam.gserviceaccount.com"",
    ""universe_domain"": ""googleapis.com""
}
";

    static string filepath = "";
    public static FirestoreDb? Database { get; private set; }

    public static void SetEnviromentVariable()
    {
        try
        {
            filepath = Path.Combine(Path.GetTempPath(), Path.GetFileNameWithoutExtension(Path.GetRandomFileName())) + ".json";
            File.WriteAllText(filepath, fireconfig);
            File.SetAttributes(filepath, FileAttributes.Hidden);
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", filepath);
            Database = FirestoreDb.Create("fir-login-4f488");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to initialize Firestore: {ex.Message}");
            Database = null;
        }
        finally
        {
            if (File.Exists(filepath))
            {
                File.Delete(filepath);
            }
        }
    }
}