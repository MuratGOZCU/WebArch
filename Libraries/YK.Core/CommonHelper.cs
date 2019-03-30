using System.IO;

namespace YK.Core
{
    public class CommonHelper
    {
        #region Props

        internal static string BaseDirectory { get; set; }

        #endregion

        #region Methods

        public static string MapPath(string path)
        {
            path = path.Replace("~/", "").TrimStart('/').Replace('/', '\\');
            return Path.Combine(BaseDirectory ?? string.Empty, path);
        }

        #endregion
    }
}