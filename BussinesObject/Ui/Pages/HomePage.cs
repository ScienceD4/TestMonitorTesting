using BussinesObject.Ui.UiEntities;
using Core;
using Core.Common;
using Core.Selenium;
using Core.Selenium.WebElements;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;

namespace BussinesObject.Ui.Pages;

public class HomePage : BasePage
{
    public NavigationBar NavBar { get; set; } = new();
    public Input Message { get; set; } = new(By.XPath("//form//p[not(@class='help')]"));
    public Button PostButton { get; set; } = new(By.XPath("//form//button"));
    public MessageContainer Messages { get; set; } = new();
    public Table<TestRunsRecord> TestRuns { get; set; } = new(By.XPath("//h3[text()='My Test Runs']/parent::div//child::table"));
    public Button RequirementsButton { get; set; } = new(By.XPath("//a[contains(@href, '/define/requirements')]"));
    public Button TestCasesButton { get; set; } = new(By.XPath("//a[contains(@href, '/design/test-suites')]"));
    public Button TestResultsButton { get; set; } = new(By.XPath("//a[contains(@href, '/track/test-cases')]"));
    public Button RisksButton { get; set; } = new(By.XPath("//a[contains(@href, '/define/risks')]"));
    public Button TestRunsButton { get; set; } = new(By.XPath("//a[contains(@href, '/plan/milestones')]"));
    public Button IssuesButton { get; set; } = new(By.XPath("//a[contains(@href, '/issues')]"));

    [AllureStep]
    public HomePage PostMessage(string message)
    {
        Message.FillIn(message);
        Browser.Instance.TakeScreenShot(nameof(Message) + " FillIn");
        LogSession.CurrentSession.Debug("message: " + message);
        PostButton.Click();
        WaitHelper.Until(2_000, () => Messages.GetMessages().Any(x => x.Content.Equals(message)));
        Browser.Instance.TakeScreenShot(nameof(PostButton) + " Click");

        return this;
    }

    [AllureStep]
    public RequirementsPage OpenRequirements()
    {
        RequirementsButton.Click();
        Browser.Instance.TakeScreenShot(nameof(RequirementsButton) +" Click");
        return new RequirementsPage();
    }
}