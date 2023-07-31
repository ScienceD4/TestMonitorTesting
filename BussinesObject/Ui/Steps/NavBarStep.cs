using BussinesObject.Ui.Pages;

namespace BussinesObject.Ui.Steps;

public static class NavBarStep
{
    public static void SwitchAll()
    {
        var navBar = new NavigationBar();
        navBar.Define.Click();
        navBar.Design.Click();
        navBar.Plan.Click();
        navBar.Run.Click();
        navBar.Track.Click();
        navBar.Resolve.Click();
        navBar.Analyze.Click();
        navBar.Settings.Click();
        navBar.Profile.Click();
        navBar.SwitchToHome();
    }
}