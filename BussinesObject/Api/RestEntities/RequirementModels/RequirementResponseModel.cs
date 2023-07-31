using Newtonsoft.Json;

namespace BussinesObject.Api.RestEntities.RequirementModels;

public class RequirementResponseModel
{
    public int Id { get; set; }

    public string? Code { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    [JsonProperty("project_id")]
    public int ProjectId { get; set; }

    [JsonProperty("requirement_type_id")]
    public int TypeId { get; set; }
}