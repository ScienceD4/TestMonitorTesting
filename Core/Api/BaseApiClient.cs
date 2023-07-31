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
        var urlSegments = request.Parameters
            .Where(p => p.Type == ParameterType.UrlSegment)
            .Where(x => !string.IsNullOrEmpty(x.Name)
                    && !string.IsNullOrEmpty(x.Value?.ToString()));
        var queryStrings = request.Parameters
            .Where(p => p.Type == ParameterType.QueryString)
            .Where(x => !string.IsNullOrEmpty(x.Name)
                    && !string.IsNullOrEmpty(x.Value?.ToString()));
        var resource = request.Resource;

        foreach (var urlSegment in urlSegments)
        {
            resource = resource.Replace($"{{{urlSegment.Name}}}", urlSegment.Value?.ToString());
        }
        foreach (var queryString in queryStrings)
        {
            resource += "?" + queryString.ToString();
        }

        LogSession.CurrentSession.Debug($"Resource: '{resource}' Method: '{request.Method}' " +
            $"{request.Parameters.FirstOrDefault(p => p.Type == ParameterType.RequestBody)}");

        var response = client.Execute(request);
        LogSession.CurrentSession.Debug($"StatusCode '{response.StatusCode}'. Content: {response.Content}");

        return response;
    }
}