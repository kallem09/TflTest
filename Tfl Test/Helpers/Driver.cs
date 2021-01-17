using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Tfl_Test.Helpers
{
   public class Driver
    {
        public static IWebDriver Instance { get; set; }
        IWebDriver _driver = new ChromeDriver();

        public static void Initialize()
        {
            string browser = GetAppSettingData.GetBrowser();
            if (browser== "chrome")
            {
                Instance = new ChromeDriver();
                Instance.Manage().Window.Maximize();
                Console.WriteLine("Opened Chrome");
            }
            Instance.Manage().Cookies.DeleteAllCookies();

        }

        public static void Close()
        {
            Instance.Close();
        }
    }
}
