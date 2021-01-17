using System.Configuration;
using System.Diagnostics;

namespace Tfl_Test.Helpers
{
  public class GetAppSettingData
    {
        private const string NavigateUrl = "Url";
        private const string Browser = "Browser";

      public static string GetNavigationUrl()
      {
          var value = GetValue(NavigateUrl);
          return !string.IsNullOrEmpty(value) ? value : null;
        }

        public static string GetBrowser()
        {
            var value = GetValue(Browser);
            return !string.IsNullOrEmpty(value) ? value : null;
        }

        private static string GetValue(string key)
        {
            string result = null;
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                result = appSettings[key] ?? "Key not found";
                return result;
            }
            catch (ConfigurationErrorsException)
            {
                Debug.WriteLine("Error reading app settings");
            }

            return result;
        }
    }
}
