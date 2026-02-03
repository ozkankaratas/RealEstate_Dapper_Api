namespace RealEstate_Dapper_UI.Services.Helpers
{
    public static class VideoUrlEmbedHelper
    {
        public static string ConvertToEmbedUrl(string url)
        {
            if (string.IsNullOrEmpty(url)) return "";

            // Eğer link zaten embed içeriyorsa dokunma
            if (url.Contains("embed")) return url;

            // watch?v= formatını kontrol et
            if (url.Contains("watch?v="))
            {
                var videoId = url.Split("v=")[1].Split("&")[0];
                return $"https://www.youtube.com/embed/{videoId}";
            }

            // youtu.be/ formatını kontrol et (kısa link)
            if (url.Contains("youtu.be/"))
            {
                var videoId = url.Split("youtu.be/")[1].Split("?")[0];
                return $"https://www.youtube.com/embed/{videoId}";
            }

            return url;
        }
    }
}
