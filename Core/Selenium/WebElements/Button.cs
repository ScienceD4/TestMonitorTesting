using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Core.Selenium.WebElements;

public class Button : BaseElement
{
    public Button(By locator) : base(locator)
    {
    }

    public void Click()
    {
        Wait();
        WebElement.Click();
    }

    public void ClickByJava()
    {
        Wait();
        Browser.Instance.ExecuteScript("arguments[0].click()", WebElement);
    }

    public void ClickWithActions()
    {
        Wait();
        new Actions(Driver)
            .MoveToElement(WebElement)
            .Click()
            .Build()
            .Perform();
    }
}