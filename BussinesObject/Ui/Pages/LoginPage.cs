using Core.Selenium;
using Core.Selenium.WebElements;
using Core.Settings;
using OpenQA.Selenium;

namespace BussinesObject.Ui.Pages;

public class LoginPage : BasePage
{
    private readonly string url = Settings.Browser.Url;
    private readonly string USER_NAME = Settings.Browser.Login;
    private readonly string PASSWORD = Settings.Browser.Password;

    private Input Email { get; set; } = new(By.Id("email"));
    private Input Password { get; set; } = new(By.Id("password"));
    private Button Login { get; set; } = new(By.XPath("//button[@type='submit']"));

    public LoginPage Show()
    {
        Browser.Instance.NavigateToUrl(url);

        return this;
    }

    public LoginPage LogIn()
    {
        Email.FillIn(USER_NAME);
        Password.FillIn(PASSWORD);
        Login.Click();

        return new LoginPage();
    }
}