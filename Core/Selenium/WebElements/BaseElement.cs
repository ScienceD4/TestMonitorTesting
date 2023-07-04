using Core.Common;
using OpenQA.Selenium;

namespace Core.Selenium.WebElements;

public abstract class BaseElement
{
    private readonly By locator;
    protected static IWebDriver Driver => Browser.Instance.Driver;

    public IWebElement WebElement => Driver.WaitLoad(d => d.FindElement(locator), Settings.Settings.Browser.TimeOutSeconds * 1000);
    public bool IsExist => ElementIsExist();

    protected BaseElement(By locator)
    {
        this.locator = locator;
    }

    protected void Wait()
    {
        Driver.WaitLoad(x => IsExist, Settings.Settings.Browser.TimeOutSeconds * 1000);
    }

    private bool ElementIsExist()
    {
        try
        {
            return WebElement.Displayed;
        }
        catch
        {
            return false;
        }
    }
}