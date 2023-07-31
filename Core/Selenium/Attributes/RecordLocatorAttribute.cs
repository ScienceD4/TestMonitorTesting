using OpenQA.Selenium;

namespace Core.Selenium.Attributes;

[AttributeUsage(AttributeTargets.Property)]
public class RecordLocatorAttribute : Attribute
{
    public By Locator { get; set; }

    public RecordLocatorAttribute(string xPath)
    {
        Locator = By.XPath(xPath);
    }
}