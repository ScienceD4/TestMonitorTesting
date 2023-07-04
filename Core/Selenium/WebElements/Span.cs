using OpenQA.Selenium;

namespace Core.Selenium.WebElements;

public class Span : BaseElement
{
    public string Text => WebElement.Text;

    public Span(By locator) : base(locator)
    {
    }
}