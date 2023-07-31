using OpenQA.Selenium;

namespace Core.Selenium.WebElements;

public class CustomElement : BaseElement
{
    public CustomElement(By locator) : base(locator)
    {
    }

    public CustomElement(By parentLocator, By childLocator) : base(parentLocator, childLocator)
    {
    }
}