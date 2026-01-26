namespace RealEstate_Dapper_UI.Services.Helpers
{
    public static class DateHelper
    {
        public static string GetTimeAgo(DateTime dateTime)
        {
            TimeSpan timeSpan = DateTime.Now - dateTime;

            if (timeSpan.TotalSeconds < 1)
                return "Şimdi";

            if (timeSpan.TotalSeconds < 60)
                return $"{(int)timeSpan.TotalSeconds}sn";

            if (timeSpan.TotalMinutes < 60)
                return $"{(int)timeSpan.TotalMinutes}dk";

            if (timeSpan.TotalHours < 24)
                return $"{(int)timeSpan.TotalHours}s";

            if (timeSpan.TotalDays < 30)
                return $"{(int)timeSpan.TotalDays}g";

            if (timeSpan.TotalDays < 365)
                return $"{(int)(timeSpan.TotalDays / 30)}ay";

            return $"{(int)(timeSpan.TotalDays / 365)}y";
        }
    }
}
