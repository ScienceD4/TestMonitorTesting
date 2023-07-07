using BussinesObject.Ui.Steps;

namespace Test.UiTests;

[TestFixture]
public class HomePageTest : BaseTest
{
    [Test]
    [Retry(3)]
    public void NavBarSwitch()
    {
        Assert.DoesNotThrow(() =>
        {
            LoginStep.Login();
            NavBarStep.SwitchAll();
        });
    }

    [Test]
    public void ClickAllButton()
    {
        Assert.DoesNotThrow(() =>
        {
            var page = LoginStep.Login();
            var navBar = page.NavBar;

            page.RequirementsButton.Click();
            navBar.SwitchToHome();
            page.TestCasesButton.Click();
            navBar.SwitchToHome();
            page.TestResultsButton.Click();
            navBar.SwitchToHome();
            page.RisksButton.Click();
            navBar.SwitchToHome();
            page.TestRunsButton.Click();
            navBar.SwitchToHome();
            page.IssuesButton.Click();
        });
    }

    [Test]
    public void PostCheckAndDeleteMessages()
    {
        var name = "dima dima";
        var message = "hello testing";

        var page = LoginStep.Login()
            .PostMessage(message);

        var messages = page.Messages.GetMessages();

        Assert.Multiple(() =>
        {
            Assert.That(messages.Select(x => x.Content), Does.Contain(message));
            Assert.That(messages.Select(x => x.Author), Does.Contain(name));
        });

        page.Messages.DeleteAllMessage();
        messages = page.Messages.GetMessages();

        Assert.That(messages, Is.Empty);
    }

    [Test]
    public void CheckTestRuns()
    {
        var records = LoginStep.Login()
            .TestRuns.GetData().Value;

        Assert.That(records, Is.Not.Empty);
    }
}