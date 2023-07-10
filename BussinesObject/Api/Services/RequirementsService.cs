using BussinesObject.Api.RestCore.Clients;
using Core.Api;
using RestSharp;

namespace BussinesObject.Api.Services;

public class RequirementsService : BaseService
{
    private readonly static string RequirementsEndpoint = "requirements?project_id=1";
    private readonly static string RequirementByIdEndpoint = "requirements/{requirementId}";
    private readonly static string TagsByReqIdEndpoint = "requirement/{requirementId}/tags";
    private readonly static string TestCasesByReqIdEndpoint = "requirement/{requirementId}/test-cases";

    public RequirementsService() : base(new TestMonitorClient())
    {
    }

    public RestResponse GetAllRequirements()
    {
        var request = new RestRequest(RequirementsEndpoint, Method.Get);
        return ApiClient.Execute(request);
    }

    public RestResponse GetRequirement(string requirementId)
    {
        var request = new RestRequest(RequirementByIdEndpoint, Method.Get).AddUrlSegment("requirementId", requirementId);
        return ApiClient.Execute(request);
    }

    public RestResponse GetTagsByRequirement(string requirementId)
    {
        var request = new RestRequest(TagsByReqIdEndpoint, Method.Get).AddUrlSegment("requirementId", requirementId);
        return ApiClient.Execute(request);
    }

    public RestResponse GetTestCasesByRequirement(string requirementId)
    {
        var request = new RestRequest(TestCasesByReqIdEndpoint, Method.Get).AddUrlSegment("requirementId", requirementId);
        return ApiClient.Execute(request);
    }
}