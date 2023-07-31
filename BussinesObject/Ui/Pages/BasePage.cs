using Core.Common;
using Core.Selenium;
using OpenQA.Selenium;

namespace BussinesObject.Ui.Pages;

public class BasePage
{
    protected static IWebDriver Driver => Browser.Instance.Driver;

    protected static TResult Wait<TResult>(Func<IWebDriver, TResult> condition, int timeout)
    {
        return Driver.WaitLoad(condition, timeout);
    }
}