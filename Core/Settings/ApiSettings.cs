namespace Core.Settings;

#pragma warning disable CS8618
public class ApiSettings : IConfiguration
{
    public string SectionName => "API";
    public string AppUrl { get; set; }
    public string AppToken { get; set; }
}
#pragma warning restore CS8618
