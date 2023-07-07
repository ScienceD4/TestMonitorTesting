using Allure.Net.Commons;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.Extensions;

namespace Core.Selenium;

public class Browser
{
    private static readonly ThreadLocal<Browser?> browserInstances = new();
    private readonly IWebDriver driver;

    public bool IsSaveOnAllure { get; set; } = true;
    public bool IsSaveOnDisk { get; set; } = false;

    public IWebDriver Driver => driver;

    public static Browser Instance => browserInstances.Value ??= new Browser();

    protected AllureLifecycle allure = AllureLifecycle.Instance;

    private Browser()
    {
        driver = DriverFactory.GetDriver();
    }

    public void NavigateToUrl(string url)
    {
        Driver.Navigate().GoToUrl(url);
    }

    public void SwitchToFrame(IWebElement frame)
    {
        Driver.SwitchTo().Frame(frame);
    }

    public void SwitchToDefaultContent()
    {
        Driver.SwitchTo().DefaultContent();
    }

    public void ExecuteScript(string script, params object[] arg)
    {
        Driver.ExecuteJavaScript(script, arg);
    }

    public void CloseBrowser()
    {
        Driver?.Dispose();
        browserInstances.Value = null;
    }

    public void ContextClickElement(IWebElement element)
    {
        new Actions(Driver)
            .ContextClick(element)
            .Perform();
    }

    public void TakeScreenShot(string title = "screenShot")
    {
        var screen = Driver.TakeScreenshot();
        var screenBytes = screen.AsByteArray;

        if (IsSaveOnAllure)
        {
            allure.AddAttachment(title, "image/png", screenBytes);
        }

        if (IsSaveOnDisk)
        {
            SaveScreen(title, screenBytes);
        }
    }

    private static void SaveScreen(string title, byte[] bytes)
    {
        var directory = "screen";
        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }
        var files = Directory.GetFiles(directory);
        var time = DateTime.Now.ToString("HHmmss");

        File.WriteAllBytes($@"{directory}\{files.Length + 1}_{time}_{title}.png", bytes);
    }
}