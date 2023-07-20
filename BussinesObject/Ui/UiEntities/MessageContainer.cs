using Core.Common;
using Core.Selenium;
using Core.Selenium.WebElements;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace BussinesObject.Ui.UiEntities;

public class MessageContainer
{
    private static readonly string messageXPath = "//div[@class='comments-component']/child::*[2]//article";
    private static readonly string deleteXPath = "//a[text()='Delete']";
    private static readonly By authorLocator = By.XPath(".//strong");
    private static readonly By contentLocator = By.XPath(".//div[@class='media-content']//p");

    private ReadOnlyCollection<IWebElement> Messages => Browser.Instance.Driver.WaitLoad(x => x.FindElements(By.XPath(messageXPath)));
    private readonly Button deleteMessage = new(By.XPath(messageXPath + deleteXPath));
    private readonly Button deleteConfirm = new(By.XPath("//footer//span[text()='Delete']/parent::button"));

    public Message[] GetMessages()
    {
        var messageElements = Messages;
        if (!messageElements.Any()) return Array.Empty<Message>();

        var count = messageElements.Count;
        var messages = new Message[count];
        for (int i = 0; i < count; i++)
        {
            var author = messageElements[i].FindElement(authorLocator).Text;
            var content = messageElements[i].FindElement(contentLocator).Text;
            messages[i] = new(author, content);
        }

        return messages;
    }

    [AllureStep]
    public void DeleteAllMessage()
    {
        while (Messages.Any())
        {
            deleteMessage.Click();
            Browser.Instance.TakeScreenShot(nameof(deleteMessage) + "Click");
            deleteConfirm.Click();
            Browser.Instance.TakeScreenShot(nameof(deleteConfirm) + "Click");
            deleteConfirm.Wait(x => !x.IsExist);
        }
    }
}

public class Message
{
    public string Author { get; set; }
    public string Content { get; set; }

    public Message(string author, string content)
    {
        Author = author;
        Content = content;
    }
}