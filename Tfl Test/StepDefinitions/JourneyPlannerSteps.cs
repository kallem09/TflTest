using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;
using Tfl_Test.Interfaces;

namespace Tfl_Test.StepDefinitions
{
    [Binding]
    public class JourneyPlannerSteps
    {
        public IJourneyPlanner JourneyPlanner;

        public JourneyPlannerSteps(IJourneyPlanner journeyPlanner)
        {
            JourneyPlanner = journeyPlanner;
        }

        [Given(@"I am on plan a journey page")]
        public void GivenIAmOnPlanAJourneyPage()
        {
            JourneyPlanner.NavigateToUrl();
        }

        [When(@"I enter from ""(.*)"" and to ""(.*)"" locations and click on plan my journey")]
        public void WhenIEnterFromAndToAndClickOnPlanAJourneyButton(string fromLocation, string toLocation)
        {
            JourneyPlanner.EnterFromLocation(fromLocation);
            JourneyPlanner.EnterToLocation(toLocation);
            JourneyPlanner.clickOnJourneyPlannerButton();
        }

        [Then(@"I should see my journey results")]
        public void ThenIShouldSeeMyJourneyResults()
        {
            Assert.AreEqual(true, JourneyPlanner.IsResultsPageDisplayed());
        }


        [Then(@"I should not see any journey results")]
        public void ThenIShouldNotSeeAnyJourneyResults()
        {
            Assert.AreEqual(true, JourneyPlanner.IsResultsPageDisplayed());
            Assert.AreEqual(true, JourneyPlanner.IsErrorMessageDisplayed());
        }

        [Then(@"I should get following field validation error message ""(.*)""")]
        public void ThenIShouldGetFieldValidationError(string errorMessage)
        {
            Assert.AreEqual("The From field is required.", errorMessage);
        }

        [Then(@"I amend the to location as ""(.*)""")]
        public void ThenIAmendToLocationAs(string toLocation)
        {
            JourneyPlanner.UpdateJourney(toLocation);
        }

        [When(@"I click on recent tab")]
        public void WhenIclickOnRecentTab()
        {
            JourneyPlanner.RecentTabClick();
        }

        [Then(@"I should see results on the recent tab")]
        public void ThenTheRecentTabShouldDisplayResults()
        {
            JourneyPlanner.CheckIfTheRecentTabDisplaysResults();
        }

    }
    }
