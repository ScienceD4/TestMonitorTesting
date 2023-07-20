using BussinesObject.Api.RestEntities;
using BussinesObject.Api.RestEntities.RequirementModels;
using BussinesObject.Api.Services;
using BussinesObject.Api.Utils;
using Newtonsoft.Json;
using NUnit.Framework;

namespace BussinesObject.Api.Steps;

public static class RequirementsRequest
{
    public static RequirementsService Service { get; } = new();

    public static RequirementResponseModel RestoreRequirement(int requirementId)
    {
        var respon = Service.RestoreRequirement(requirementId);
        RequestHelper.CheckResponse(respon);

        var responModel = JsonConvert
            .DeserializeObject<CommonResponse<RequirementResponseModel>>(respon.Content!)?.Data;
        Assert.Multiple(() =>
        {
            Assert.That(responModel, Is.Not.Null);
            Assert.That(responModel?.Id, Is.EqualTo(requirementId));
        });

        return responModel!;
    }

    public static RequirementResponseModel CreateRequirement(CreateRequirementModel model)
    {
        var respon = Service.CreateRequirement(model);
        RequestHelper.CheckResponse(respon, false, System.Net.HttpStatusCode.Created);

        var responModel = JsonConvert
            .DeserializeObject<CommonResponse<RequirementResponseModel>>(respon.Content!)?.Data;
        Assert.Multiple(() =>
        {
            Assert.That(responModel, Is.Not.Null);
            Assert.That(responModel?.Name, Is.EqualTo(model.Name));
            Assert.That(responModel?.Description, Is.EqualTo(model.Description));
            Assert.That(responModel?.ProjectId, Is.EqualTo(model.ProjectId));
        });

        return responModel!;
    }

    public static RequirementResponseModel UpdateRequirement(int requirementId, CreateRequirementModel model)
    {
        var respon = Service.UpdateRequirement(requirementId, model);
        RequestHelper.CheckResponse(respon);

        var responModel = JsonConvert
            .DeserializeObject<CommonResponse<RequirementResponseModel>>(respon.Content!)?.Data;
        Assert.Multiple(() =>
        {
            Assert.That(responModel, Is.Not.Null);
            Assert.That(responModel?.Id, Is.EqualTo(requirementId));
        });
        return responModel!;
    }
}