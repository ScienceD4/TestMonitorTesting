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
        WaitExist();
        WebElement.Click();
    }

    public void ClickByJava()
    {
        WaitExist();
        Browser.Instance.ExecuteScript("arguments[0].click()", WebElement);
    }

    public void ClickWithActions()
    {
        WaitExist();
        new Actions(Driver)
            .MoveToElement(WebElement)
            .Click()
            .Build()
            .Perform();
    }
}