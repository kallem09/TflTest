using System.Diagnostics;
using BoDi;
using TechTalk.SpecFlow;
using Tfl_Test.Helpers;
using Tfl_Test.Interfaces;
using Tfl_Test.Pages;

namespace Tfl_Test.StepDefinitions
{
    [Binding]
    public class ScenarioHooks
    {
        private readonly IObjectContainer _objectContainer;
        private IJourneyPlanner _journeyPlanner;

        public ScenarioHooks(IObjectContainer objectContainer)
        {
            this._objectContainer = objectContainer;

         }

        [BeforeScenario]
        public void Initialize()
        {
            if (GetAppSettingData.GetBrowser() != "")
            {
                if (Driver.Instance == null)
                    Driver.Initialize();
                else
                {
                    Driver.Instance.Manage().Cookies.DeleteAllCookies();
                }
            }

            _journeyPlanner = new JourneyPlanner(Driver.Instance);
            _objectContainer.RegisterInstanceAs<IJourneyPlanner>(_journeyPlanner);
        }


        [AfterTestRun]
        public static void CloseDriver()
        {
            Driver.Close();
            foreach (var process in Process.GetProcesses())
            {
                if (process.ProcessName == "chromedriver")
                {
                    process.Kill();
                }
            }
        }
    }
}
