using Newtonsoft.Json;

namespace BussinesObject.Api.RestEntities.TestSuiteModels;

public class TestSuiteRequestModel
{
    [JsonProperty("project_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public int? ProjectId { get; set; }

    [JsonProperty("name", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string? Name { get; set; }

    [JsonProperty("description", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string? Description { get; set; }
}