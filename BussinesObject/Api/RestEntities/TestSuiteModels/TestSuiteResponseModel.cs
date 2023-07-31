using Newtonsoft.Json;

namespace BussinesObject.Api.RestEntities.TestSuiteModels;

public class TestSuiteResponseModel
{
    public int Id { get; set; }

    [JsonProperty("name", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string? Name { get; set; }

    [JsonProperty("description", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string? Description { get; set; }

    [JsonProperty("test_cases_count")]
    public int TestCasesCount { get; set; }

    [JsonProperty("project_id")]
    public int ProjectId { get; set; }

    [JsonProperty("created_at", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public DateTime? CreatedAt { get; set; }

    [JsonProperty("updated_at", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public DateTime? UpdatedAt { get; set; }

    [JsonProperty("deleted_at", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public DateTime? DeletedAt { get; set; }
}