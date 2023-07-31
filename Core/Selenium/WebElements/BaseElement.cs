using Core.Common;
using OpenQA.Selenium;

namespace Core.Selenium.WebElements;

public abstract class BaseElement
{
    protected readonly By? locator;
    private readonly By? childLocator;
    protected static IWebDriver Driver => Browser.Instance.Driver;

    public IWebElement WebElement => Find();
    public bool IsExist => ElementIsExist();

    protected BaseElement(By locator)
    {
        this.locator = locator;
    }

    protected BaseElement(By parentLocator, By childLocator)
    {
        this.locator = parentLocator;
        this.childLocator = childLocator;
    }

    private IWebElement Find()
    {
        IWebElement webElement;

        if (childLocator != null && locator != null)
        {
            webElement = Driver.FindElement(locator).FindElement(childLocator);
        }
        else if (locator != null)
        {
            webElement = Driver.FindElement(locator);
        }
        else
        {
            throw new Exception("locator is null");
        }

        return webElement;
    }

    public void WaitExist()
    {
        Wait(x => IsExist);
    }

    public void Wait(Predicate<BaseElement> condition)
    {
        Driver.WaitLoad(x => condition(this), Settings.Settings.Browser.TimeOutSeconds * 1000);
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