using RestSharp;

namespace Core.Api;

public class BaseApiClient
{
    protected readonly RestClient client;

    public BaseApiClient(string url)
    {
        var options = new RestClientOptions(url)
        {
            MaxTimeout = 10_000,
            ThrowOnAnyError = false,
        };

        client = new RestClient(options);
        client.AddDefaultHeader("Content-Type", "application/json");
    }

    public void AddToken(string token)
    {
        client.AddDefaultHeader("Token", token);
    }

    public RestResponse Execute(RestRequest request)
    {
        LogSession.CurrentSession.Debug($"Resource: '{request.Resource}' Method: '{request.Method}' " +
            $"{request.Parameters.FirstOrDefault(p => p.Type == ParameterType.RequestBody)}");

        var response = client.Execute(request);
        LogSession.CurrentSession.Debug($"StatusCode '{response.StatusCode}'. Content: {response.Content}");

        return response;
    }
}