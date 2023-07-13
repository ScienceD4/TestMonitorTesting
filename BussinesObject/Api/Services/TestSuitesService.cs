using BussinesObject.Api.RestCore.Clients;
using BussinesObject.Api.RestEntities.TestSuiteModels;
using Core.Api;
using Newtonsoft.Json;
using RestSharp;

namespace BussinesObject.Api.Services;

public class TestSuitesService : BaseService
{
    private static readonly int projectId = Core.Settings.Settings.API.MainProjectId;
    private static readonly string TestSuitesEndpoint = "test-suites";
    private static readonly string TestSuiteByIdEndpoint = "test-suites/{testSuiteId}";
    private static readonly string TestSuiteRestoreEndpoint = "test-suite/{testSuiteId}/restore";

    public TestSuitesService() : base(new TestMonitorClient())
    {
    }

    public RestResponse GetAllTestSuites()
    {
        var request = new RestRequest(TestSuitesEndpoint, Method.Get)
            .AddQueryParameter("project_id", projectId);

        return ApiClient.Execute(request);
    }

    public RestResponse GetTestSuite(int testSuiteId)
    {
        var request = new RestRequest(TestSuiteByIdEndpoint, Method.Get)
            .AddUrlSegment("testSuiteId", testSuiteId);

        return ApiClient.Execute(request);
    }

    public RestResponse DeleteTestSuite(int testSuiteId)
    {
        var request = new RestRequest(TestSuiteByIdEndpoint, Method.Delete)
            .AddUrlSegment("testSuiteId", testSuiteId);

        return ApiClient.Execute(request);
    }

    public RestResponse RestoreTestSuite(int testSuiteId)
    {
        var request = new RestRequest(TestSuiteRestoreEndpoint, Method.Post)
            .AddUrlSegment("testSuiteId", testSuiteId);

        return ApiClient.Execute(request);
    }

    public RestResponse CreateTestSuite(TestSuiteRequestModel model)
    {
        var request = new RestRequest(TestSuitesEndpoint, Method.Post);

        var body = JsonConvert.SerializeObject(model);
        request.AddBody(body);

        return ApiClient.Execute(request);
    }

    public RestResponse UpdateTestSuite(int testSuiteId, TestSuiteRequestModel model)
    {
        var request = new RestRequest(TestSuiteByIdEndpoint, Method.Put)
            .AddUrlSegment("testSuiteId", testSuiteId);

        var body = JsonConvert.SerializeObject(model);
        request.AddBody(body);

        return ApiClient.Execute(request);
    }
}