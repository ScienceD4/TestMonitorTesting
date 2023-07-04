using OpenQA.Selenium;

namespace Core.Selenium.WebElements;

public class Input : BaseElement
{
    public Input(By locator) : base(locator)
    {
    }

    public void FillIn(string text)
    {
        if (string.IsNullOrEmpty(text)) return;

        Wait();
        WebElement.Clear();
        WebElement.SendKeys(text);
    }
}