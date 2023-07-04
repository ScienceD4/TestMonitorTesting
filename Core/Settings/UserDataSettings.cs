namespace Core.Settings;

#pragma warning disable CS8618
public class UserDataSettings : IConfiguration
{
    public string SectionName => "UserData";

    public string Login { get; set; }
    public string Password { get; set; }
}
#pragma warning restore CS8618