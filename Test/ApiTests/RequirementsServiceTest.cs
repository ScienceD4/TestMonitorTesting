using BussinesObject.Api.RestEntities.RequirementModels;
using BussinesObject.Api.Services;
using BussinesObject.Api.Steps;
using BussinesObject.Api.Utils;
using Core.Common;

namespace Test.ApiTests;

[TestFixture]
public class RequirementsServiceTest : BaseTest
{
    private static readonly RequirementsService service = RequirementsRequest.Service;

    [Test]
    public void GetAllRequirements()
    {
        var respon = service.GetAllRequirements();
        RequestHelper.CheckResponse(respon, false, System.Net.HttpStatusCode.OK);
    }

    [Test]
    public void GetTags()
    {
        var respon = service.GetTagsByRequirement(1);
        RequestHelper.CheckResponse(respon, false, System.Net.HttpStatusCode.OK);
    }

    [Test]
    public void GetTestCases()
    {
        var respon = service.GetTestCasesByRequirement(1);
        RequestHelper.CheckResponse(respon, false, System.Net.HttpStatusCode.OK);
    }

    [Test]
    public void GetRequirement()
    {
        var respon = service.GetRequirement(1);
        RequestHelper.CheckResponse(respon, false, System.Net.HttpStatusCode.OK);
    }

    [Test]
    public void GetRequirementTypes()
    {
        var respon = service.GetRequirementTypes();
        RequestHelper.CheckResponse(respon, false, System.Net.HttpStatusCode.OK);
    }

    [Test]
    public void GetAllTags()
    {
        var respon = service.GetAllTags();
        RequestHelper.CheckResponse(respon, false, System.Net.HttpStatusCode.OK);
    }

    [Test]
    public void CreateAndDeleteRequirement()
    {
        var name = DataGenerator.GetSentence();
        var description = DataGenerator.GetText();
        var projectId = Core.Settings.Settings.API.MainProjectId;

        var model = new CreateRequirementModel()
        {
            ProjectId = projectId,
            Name = name,
            Description = description,
            TypeId = 3,
            Tags = new() { "test" }
        };

        var responModel = RequirementsRequest.CreateRequirement(model);

        var respon = service.DeleteRequirement(responModel!.Id);
        RequestHelper.CheckResponse(respon, true, System.Net.HttpStatusCode.NoContent);
    }

    [Test]
    public void UpdateRequirement()
    {
        var name = DataGenerator.GetSentence();
        var description = DataGenerator.GetText();
        var requirementId = 7;

        var model = new CreateRequirementModel()
        {
            Name = name,
            Description = description,
            TypeId = 4,
        };

        var responModel = RequirementsRequest.UpdateRequirement(requirementId, model);
        Assert.Multiple(() =>
        {
            Assert.That(responModel?.Name, Is.EqualTo(model.Name));
            Assert.That(responModel?.TypeId, Is.EqualTo(model.TypeId));
            Assert.That(responModel?.Description, Is.EqualTo(model.Description));
        });
    }

    [Test]
    public void DeleteAndRestoreRequirement()
    {
        var requirementId = 7;

        var respon = service.DeleteRequirement(requirementId);
        RequestHelper.CheckResponse(respon, true, System.Net.HttpStatusCode.NoContent);

        RequirementsRequest.RestoreRequirement(requirementId);
    }
}