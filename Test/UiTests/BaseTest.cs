using Core.Selenium;
using NUnit.Allure.Core;

namespace Test.UiTests;

[AllureNUnit]
[Category("Ui")]
public class BaseTest
{
    [TearDown]
    public virtual void TearDown()
    {
        Core.LogSession.CurrentSession
            .Debug($"TearDown timeout {Core.Settings.Settings.Browser.TimeOutTearDown} sec.");
        Task.Delay(Core.Settings.Settings.Browser.TimeOutTearDown * 1_000).Wait();

        if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
        {
            Browser.Instance.TakeScreenShot("ScreenShotFail");
        }
        else
        {
            Browser.Instance.TakeScreenShot("EndScreenShot");
        }

        Browser.Instance.CloseBrowser();
    }
}
