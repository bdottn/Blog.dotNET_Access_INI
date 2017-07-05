using System.Runtime.InteropServices;
using System.Text;

namespace Physical
{
    public sealed class INIAccess
    {
        private readonly string path;

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(
            string lpAppName,
            string lpKeyName,
            string lpDefault,
            StringBuilder lpReturnedString,
            int nSize,
            string lpFileName);

        [DllImport("kernel32")]
        private static extern bool WritePrivateProfileString(
            string lpAppName,
            string lpKeyName,
            string lpString,
            string lpFileName);

        public INIAccess(string path)
        {
            this.path = path;
        }

        public string GetValue(string section, string key)
        {
            var tmpStringBuilder = new StringBuilder(255);

            GetPrivateProfileString(section, key, string.Empty, tmpStringBuilder, 255, this.path);

            var value = tmpStringBuilder.ToString();

            return value;
        }

        public bool ModifyValue(string section, string key, string value)
        {
            return WritePrivateProfileString(section, key, value, this.path);
        }
    }
}