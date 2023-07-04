namespace Core.Settings;

#pragma warning disable CS8618
public class BrowserSettings : IConfiguration
{
    public string SectionName => "Browser";

    public string Url { get; set; }
    public bool HeadLess { get; set; }
    public int TimeOutSeconds { get; set; }
    public string Type { get; set; }
}
#pragma warning restore CS8618