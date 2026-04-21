namespace StudentJobPlatform.Services
{
    public static class ValidationHelper
    {
        public static bool IsInvalidId(int id)
        {
            return id <= 0;
        }

        public static bool IsNullOrWhiteSpace(string? value)
        {
            return string.IsNullOrWhiteSpace(value);
        }
    }
}