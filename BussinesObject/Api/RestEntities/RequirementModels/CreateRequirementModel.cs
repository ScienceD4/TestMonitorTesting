using Newtonsoft.Json;

namespace BussinesObject.Api.RestEntities.RequirementModels;

public class CreateRequirementModel
{
    [JsonProperty("project_id")]
    public int ProjectId { get; set; }

    [JsonProperty("name")]
    public string? Name { get; set; }

    [JsonProperty("requirement_type_id")]
    public int TypeId { get; set; }

    [JsonProperty("description")]
    public string? Description { get; set; }

    [JsonProperty("tags", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public List<string>? Tags { get; set; }
}