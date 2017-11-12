using System.Configuration;

namespace Data
{
    public class Settings
    {
        private static string _conn;
        public static string GetConn()
        {
            if (string.IsNullOrEmpty(_conn))
                _conn = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            return _conn;
        }
    }
}
