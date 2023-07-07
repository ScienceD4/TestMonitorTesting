using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace Core.Selenium;

public static class DriverFactory
{
    public static IWebDriver GetDriver()
    {
        var browser = Settings.Settings.Browser.Type;

        IWebDriver webDriver;

        switch (browser)
        {
            case "chrome":
                var options = new ChromeOptions();

                if (Settings.Settings.Browser.HeadLess)
                {
                    options.AddArgument("--headless");
                }

                options.AddArgument("--no-sandbox");
                options.AddArgument("--disable-extensions");

                webDriver = new ChromeDriver(options);
                break;

            default:
                webDriver = new ChromeDriver();
                break;
        }

        webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Settings.Settings.Browser.ImplicitTimeOutSeconds);
        webDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(Settings.Settings.Browser.TimeOutSeconds * 3);
        webDriver.Manage().Window.Size = new System.Drawing.Size(1920, 1080);

        return webDriver;
    }
}