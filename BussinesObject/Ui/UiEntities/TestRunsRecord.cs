using Core.Selenium.Attributes;

namespace BussinesObject.Ui.UiEntities;

#pragma warning disable CS8618

public class TestRunsRecord
{
    [RecordIndex(0)]
    [RecordLocator("./child::div")]
    public string Name { get; set; }

    [RecordIndex(1)]
    [RecordLocator(".//div[@class='period']")]
    public string Period { get; set; }
}

#pragma warning restore CS8618