using Microsoft.Extensions.Configuration;

namespace Core.Settings;

public static class Settings
{
    private static string SettingsDirectory => @"\Settings\Files\";
    private static readonly IConfigurationRoot configurationRoot = GetConfigurationRoot();

    public static BrowserSettings Browser { get; } = BindConfiguration<BrowserSettings>();
    public static UserDataSettings UserData { get; } = BindConfiguration<UserDataSettings>();
    public static ApiSettings API { get; } = BindConfiguration<ApiSettings>();

    private static T BindConfiguration<T>() where T : IConfiguration, new()
    {
        var config = new T();
        configurationRoot.GetSection(config.SectionName).Bind(config);
        return config;
    }

    private static IConfigurationRoot GetConfigurationRoot() => new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory() + SettingsDirectory)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddJsonFile("appsettings.custom.json", optional: true, reloadOnChange: true)
            .Build();
}