namespace Core.Selenium.Attributes;

[AttributeUsage(AttributeTargets.Property)]
public class RecordIndexAttribute : Attribute
{
    public int Index { get; set; }

    public RecordIndexAttribute(int index)
    {
        Index = index;
    }
}