using Newtonsoft.Json;

namespace BussinesObject.Api.RestEntities.RequirementModels;

public class CreateRequirementModel
{
    [JsonProperty("project_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public int? ProjectId { get; set; }

    [JsonProperty("name", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string? Name { get; set; }

    [JsonProperty("requirement_type_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public int? TypeId { get; set; }

    [JsonProperty("description", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string? Description { get; set; }

    [JsonProperty("tags", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public List<string>? Tags { get; set; }
}