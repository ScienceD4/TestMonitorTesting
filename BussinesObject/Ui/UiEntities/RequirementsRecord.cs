using Core.Selenium.Attributes;
using Core.Selenium.WebElements;
using OpenQA.Selenium;

namespace BussinesObject.Ui.UiEntities;

#pragma warning disable CS8618

public class RequirementsRecord : RecordBase
{
    [RecordIndex(1)]
    [RecordLocator(".//strong")]
    public string Code { get; set; }

    [RecordIndex(2)]
    [RecordLocator(".//span")]
    public string Name { get; set; }

    [RecordIndex(3)]
    [RecordLocator(".//span")]
    public string Type { get; set; }

    [RecordIndex(4)]
    [RecordLocator(".//div")]
    public string TestCases { get; set; }

    private ActionRequirements action;
    public ActionRequirements Action
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
                case ActionRequirements.Select:
                    AddAction(new ActionRecord(0, By.XPath(".//input[@type='checkbox']/parent::label")));
                    break;
                case ActionRequirements.Wiew:
                    AddAction(new ActionRecord(5, By.XPath(".//a")));
                    break;
            }
        }
    }

    public enum ActionRequirements
    {
        None,
        Select,
        Wiew
    }

    public override bool Check(RecordBase record)
    {
        if (record is RequirementsRecord item && (item.Code.Equals(Code) || item.Name.Equals(Name)))
                return true;

        return false;
    }
}

#pragma warning restore CS8618