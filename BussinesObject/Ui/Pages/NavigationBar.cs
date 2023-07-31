using Core.Selenium.WebElements;
using OpenQA.Selenium;

namespace BussinesObject.Ui.Pages;

public class NavigationBar : BasePage
{
    private static readonly string navLocator = "//div[@id='navMenu']";

    private Button Home { get; set; } = new(By.XPath("//div[@class='navbar-brand']/a"));
    public Button Define { get; set; } = new(By.XPath(navLocator + "//a[text()='Define']"));
    public Button Design { get; set; } = new(By.XPath(navLocator + "//a[text()='Design']"));
    public Button Plan { get; set; } = new(By.XPath(navLocator + "//a[text()='Plan']"));
    public Button Run { get; set; } = new(By.XPath(navLocator + "//a[text()='Run']"));
    public Button Track { get; set; } = new(By.XPath(navLocator + "//a[text()='Track']"));
    public Button Resolve { get; set; } = new(By.XPath(navLocator + "//a[text()='Resolve']"));
    public Button Analyze { get; set; } = new(By.XPath(navLocator + "//a[text()='Analyze']"));
    public Button Settings { get; set; } = new(By.XPath(navLocator + "//a[@class='navbar-item' and contains(@href, 'settings')]"));
    public Button Profile { get; set; } = new(By.XPath(navLocator + "//figure//parent::a[@class='navbar-link']"));

    public HomePage SwitchToHome()
    {
        Home.Click();

        return new HomePage();
    }
}