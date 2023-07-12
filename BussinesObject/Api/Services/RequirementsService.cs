using BussinesObject.Api.RestCore.Clients;
using BussinesObject.Api.RestEntities.RequirementModels;
using Core.Api;
using Newtonsoft.Json;
using RestSharp;

namespace BussinesObject.Api.Services;

public class RequirementsService : BaseService
{
    private readonly static int projectId = Core.Settings.Settings.API.MainProjectId;
    private readonly static string RequirementsEndpoint = $"requirements";
    private readonly static string RequirementsTypesEndpoint = "project/{projectId}/requirement-types";
    private readonly static string RequirementByIdEndpoint = "requirements/{requirementId}";
    private readonly static string TagsByReqIdEndpoint = "requirement/{requirementId}/tags";
    private readonly static string TagsEndpoint = $"requirement-tags";
    private readonly static string TestCasesByReqIdEndpoint = "requirement/{requirementId}/test-cases";

    public RequirementsService() : base(new TestMonitorClient())
    {
    }

    public RestResponse GetAllRequirements()
    {
        var request = new RestRequest(RequirementsEndpoint, Method.Get)
            .AddQueryParameter("project_id", projectId);

        return ApiClient.Execute(request);
    }

    public RestResponse CreateRequirement(CreateRequirementModel model)
    {
        var request = new RestRequest(RequirementsEndpoint, Method.Post);

        var body = JsonConvert.SerializeObject(model);
        request.AddBody(body);

        return ApiClient.Execute(request);
    }

    public RestResponse GetRequirement(string requirementId)
    {
        var request = new RestRequest(RequirementByIdEndpoint, Method.Get)
            .AddUrlSegment("requirementId", requirementId);

        return ApiClient.Execute(request);
    }

    public RestResponse DeleteRequirement(string requirementId)
    {
        var request = new RestRequest(RequirementByIdEndpoint, Method.Delete)
            .AddUrlSegment("requirementId", requirementId);

        return ApiClient.Execute(request);
    }

    public RestResponse GetTagsByRequirement(string requirementId)
    {
        var request = new RestRequest(TagsByReqIdEndpoint, Method.Get)
            .AddUrlSegment("requirementId", requirementId);

        return ApiClient.Execute(request);
    }

    public RestResponse GetAllTags()
    {
        var request = new RestRequest(TagsEndpoint, Method.Get)
            .AddQueryParameter("project_id", projectId);

        return ApiClient.Execute(request);
    }

    public RestResponse GetTestCasesByRequirement(string requirementId)
    {
        var request = new RestRequest(TestCasesByReqIdEndpoint, Method.Get)
            .AddUrlSegment("requirementId", requirementId);

        return ApiClient.Execute(request);
    }

    public RestResponse GetRequirementTypes()
    {
        var request = new RestRequest(RequirementsTypesEndpoint, Method.Get)
            .AddUrlSegment("projectId", projectId);

        return ApiClient.Execute(request);
    }
}