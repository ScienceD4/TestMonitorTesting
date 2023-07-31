using Core.Api;
using Core.Settings;
using RestSharp;

namespace BussinesObject.Api.RestCore.Clients;

public class TestMonitorClient : BaseApiClient
{
    public TestMonitorClient() : base(Settings.API.AppUrl)
    {
        AddBearerToken(Settings.API.AppToken);
    }

    public void AddBearerToken(string token)
    {
        client.AddDefaultHeader("Authorization", $"Bearer {token}");
    }
}