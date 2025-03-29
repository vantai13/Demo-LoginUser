using Google.Cloud.Firestore;
using System;

namespace Demo_Login.Classes
{
    [FirestoreData]
    internal class UserData
    {
        [FirestoreProperty]
        public string? Username { get; set; }

        [FirestoreProperty]
        public string? Password { get; set; }

        [FirestoreProperty]
        public string? Gender { get; set; }

        [FirestoreProperty]
        public string? Email { get; set; }
    }
}