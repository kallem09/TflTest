using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using Tfl_Test.Helpers;
using Tfl_Test.Interfaces;

namespace Tfl_Test.Pages
{
    class BasePage : IBasePage
    {
        protected IWebDriver Driver;

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
            try
            {
                RetryingElementLocator retry = new RetryingElementLocator(Driver, TimeSpan.FromSeconds(30));
                IPageObjectMemberDecorator decor = new DefaultPageObjectMemberDecorator();
                PageFactory.InitElements(retry.SearchContext, this, decor);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void NavigateToUrl()
        {
            var url = GetAppSettingData.GetNavigationUrl();
            Console.WriteLine(url);
            Driver.Navigate().GoToUrl(url);
        }

        public void EnterInputValue(IWebElement inputElement, string value)
        {
            inputElement.Clear();
            inputElement.SendKeys(value);
        }

        public void ClickElement(IWebElement element)
        {
            CookieOverlay();
            Wait(element);
            element.Click();
        }
        /// <summary>
        /// This method removes cookie banner
        /// </summary>
        public void CookieOverlay()
        {
            var js = (IJavaScriptExecutor) Driver;
            try
            {
                Boolean flag = (Boolean) js.ExecuteScript("return window.jQuery('#cb-cookieoverlay').is(':visible')");
                if (flag == true)
                    js.ExecuteScript("window.jQuery('#cb-cookieoverlay', window.parent.document).remove()");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        private void Wait(IWebElement element)
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(60));
            wait.Until(drv => element);
            CookieOverlay();
        }

        /// <summary>
        /// Selects value from the drop down
        /// </summary>
        /// <param name="fromLocation"></param>
        public void SelectValue(string fromLocation)
        {
            CookieOverlay();
            IList<IWebElement> stops = Driver.FindElements(By.ClassName("stop-name"));
            foreach (var el in stops)
            {
                var text = el.Text;
                if (text.Contains(fromLocation))
                {
                    try
                    {
                        Thread.Sleep(5000);
                    }
                    catch (Exception e)
                    {
                        Trace.WriteLine(e.Message);
                    }

                    ((IJavaScriptExecutor) Driver).ExecuteScript("arguments[0].click();", el);
                    break;
                }
            }
        }
    }
}
