using Core;
using Core.Selenium;
using Core.Selenium.WebElements;
using Core.Settings;
using NUnit.Allure.Attributes;
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

    [AllureStep]
    public LoginPage Show()
    {
        Browser.Instance.NavigateToUrl(url);
        LogSession.CurrentSession.Debug("URL: " + url);
        Browser.Instance.TakeScreenShot("Open " + nameof(LoginPage));

        return this;
    }

    [AllureStep]
    public HomePage LogIn()
    {
        Email.FillIn(USER_NAME);
        LogSession.CurrentSession.Debug("Email: " + USER_NAME);
        Password.FillIn(PASSWORD);
        LogSession.CurrentSession.Debug("Password: " + PASSWORD);
        Browser.Instance.TakeScreenShot("FillIn credentials");
        Login.Click();
        Browser.Instance.TakeScreenShot(nameof(Login) + "Click");

        return new HomePage();
    }
}