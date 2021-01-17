using System;
using System.Diagnostics;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Tfl_Test.Interfaces;

namespace Tfl_Test.Pages
{
    class JourneyPlanner:BasePage,IJourneyPlanner
    {
        public JourneyPlanner(IWebDriver driver) : base(driver)
        {
            RetryingElementLocator retry = new RetryingElementLocator(driver, TimeSpan.FromSeconds(30));
            IPageObjectMemberDecorator decor = new DefaultPageObjectMemberDecorator();
            PageFactory.InitElements(retry.SearchContext, this, decor);
        }

        public void EnterFromLocation(string fromLocation)
        {
            EnterInputValue(FromLocation, fromLocation);
            SelectValue(fromLocation);
        }

        public void EnterToLocation(string toLocation)
        {
            EnterInputValue(ToLocation, toLocation);
            SelectValue(toLocation);
        }

        public void clickOnJourneyPlannerButton()
        {
            CookieOverlay();
            ClickElement(Driver.FindElement(By.Id("plan-journey-button")));
        }

        public bool IsResultsPageDisplayed()
        {
            Thread.Sleep(10000);
            CookieOverlay();
            Boolean isJqueryUsed = (Boolean)((IJavaScriptExecutor)Driver).ExecuteScript("return (typeof(jQuery) != 'undefined')");
            if (isJqueryUsed)
            {
                while (true)
                {
                    Boolean ajaxIsComplete = (Boolean)(((IJavaScriptExecutor)Driver).ExecuteScript("return jQuery.active == 0"));
                    if (ajaxIsComplete) break;
                    try
                    {
                        Thread.Sleep(100);
                    }
                    catch (Exception e)
                    {
                        Trace.WriteLine(e.Message);
                    }
                }

            }
            if (Driver.FindElement(By.ClassName("jp-results-headline")).Displayed)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsErrorMessageDisplayed()
        {
            return Driver.FindElement(By.ClassName("headline-container")).Displayed;
        }

        public void UpdateJourney(string toLocation)
        {
            ClickElement(EditJourney);
            EnterToLocation(toLocation);
            clickOnJourneyPlannerButton();
            IsResultsPageDisplayed();
        }

        public void RecentTabClick()
        {
            ClickElement(RecentTabElement);
        }

        public bool CheckIfTheRecentTabDisplaysResults()
        {
            return Driver.FindElement(By.Id("jp-recent-content-jp-")).Displayed;
        }
   
        #region PageElements

        [FindsBy(How = How.Id, Using = "InputFrom")]
        private IWebElement FromLocation { get; set; }

        [FindsBy(How = How.Id, Using = "InputTo")]
        private IWebElement ToLocation { get; set; }

       [FindsBy(How = How.ClassName, Using = "edit-journey")]
        private IWebElement EditJourney { get; set; }

        [FindsBy(How=How.Id, Using = "jp-recent-tab-jp")]
        private IWebElement RecentTabElement { get; set; }

        #endregion PageElements
    }
}
