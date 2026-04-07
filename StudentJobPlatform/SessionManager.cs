namespace StudentJobPlatform
{
    public static class SessionManager
    {
        public static int CurrentUserId { get; set; }
        public static string CurrentUserName { get; set; } = "";
        public static string CurrentUserRole { get; set; } = "";
        public static bool IsLoggedIn { get; set; }

        public static void Login(int userId, string name, string role)
        {
            CurrentUserId = userId;
            CurrentUserName = name;
            CurrentUserRole = role;
            IsLoggedIn = true;
        }

        public static void Logout()
        {
            CurrentUserId = 0;
            CurrentUserName = "";
            CurrentUserRole = "";
            IsLoggedIn = false;
        }
    }
}