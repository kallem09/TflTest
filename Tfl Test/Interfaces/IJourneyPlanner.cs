namespace Tfl_Test.Interfaces
{
   public interface IJourneyPlanner:IBasePage
    {
        void EnterFromLocation(string fromLocation);
        void EnterToLocation(string toLocation);
        void clickOnJourneyPlannerButton();
        bool IsResultsPageDisplayed();
        bool IsErrorMessageDisplayed();
        void UpdateJourney(string toLocation);
        void RecentTabClick();
        bool CheckIfTheRecentTabDisplaysResults();
    }
}
