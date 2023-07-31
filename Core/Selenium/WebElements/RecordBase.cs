using OpenQA.Selenium;

namespace Core.Selenium.WebElements;

public abstract class RecordBase
{
    public ActionRecord? CurrentAction { get; private set; }

    protected void AddAction(ActionRecord action)
    {
        CurrentAction = action;
    }

    public abstract bool Check(RecordBase record);
}

public class ActionRecord
{
    public By Locator { get; private set; }
    public int Index { get; private set; }

    public ActionRecord(int index, By locator)
    {
        Locator = locator;
        Index = index;
    }
}