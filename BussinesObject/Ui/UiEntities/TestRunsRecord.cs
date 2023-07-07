using Core.Selenium.Attributes;
using Core.Selenium.WebElements;
using OpenQA.Selenium;

namespace BussinesObject.Ui.UiEntities;

#pragma warning disable CS8618

public class TestRunsRecord : RecordBase
{
    [RecordIndex(0)]
    [RecordLocator("./child::div")]
    public string Name { get; set; }

    [RecordIndex(1)]
    [RecordLocator(".//div[@class='period']")]
    public string Period { get; set; }

    private ActionTestRun action;
    public ActionTestRun Action
    {
        get
        {
            return action;
        }
        set
        {
            action = value;
            switch (action)
            {
                case ActionTestRun.Run:
                    AddAction(new ActionRecord(4, By.XPath(".//a")));
                    break;
            }
        }
    }

    public enum ActionTestRun
    {
        None,
        Run
    }

    public override bool Check(RecordBase record)
    {
        if (record is TestRunsRecord item && item.Name.Equals(Name))
            return true;

        return false;
    }
}

#pragma warning restore CS8618