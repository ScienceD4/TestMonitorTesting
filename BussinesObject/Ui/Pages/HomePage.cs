using BussinesObject.Ui.UiEntities;
using Core.Common;
using Core.Selenium.WebElements;
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

    public HomePage PostMessage(string message)
    {
        Message.FillIn(message);
        PostButton.Click();
        WaitHelper.Until(2_000, () => Messages.GetMessages().Any(x => x.Content.Equals(message)));

        return this;
    }

    public RequirementsPage OpenRequirements()
    {
        RequirementsButton.Click();

        return new RequirementsPage();
    }
}