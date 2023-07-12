using BussinesObject.Api.RestEntities;
using BussinesObject.Api.RestEntities.RequirementModels;
using BussinesObject.Api.Services;
using Core.Common;
using Newtonsoft.Json;

namespace Test.ApiTests;

[TestFixture]
public class RequirementsServiceTest : BaseTest
{
    [Test]
    public void GetAllRequirements()
    {
        var respon = new RequirementsService().GetAllRequirements();

        Assert.Multiple(() =>
        {
            Assert.That(respon, Is.Not.Null);
            Assert.That(respon.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
        });
    }

    [Test]
    public void GetTags()
    {
        var respon = new RequirementsService().GetTagsByRequirement("1");

        Assert.Multiple(() =>
        {
            Assert.That(respon, Is.Not.Null);
            Assert.That(respon.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
        });
    }

    [Test]
    public void GetTestCases()
    {
        var respon = new RequirementsService().GetTestCasesByRequirement("1");

        Assert.Multiple(() =>
        {
            Assert.That(respon, Is.Not.Null);
            Assert.That(respon.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
        });
    }

    [Test]
    public void GetRequirement()
    {
        var respon = new RequirementsService().GetRequirement("1");

        Assert.Multiple(() =>
        {
            Assert.That(respon, Is.Not.Null);
            Assert.That(respon.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
        });
    }

    [Test]
    public void GetRequirementTypes()
    {
        var respon = new RequirementsService().GetRequirementTypes();

        Assert.Multiple(() =>
        {
            Assert.That(respon, Is.Not.Null);
            Assert.That(respon.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
        });
    }

    [Test]
    public void GetAllTags()
    {
        var respon = new RequirementsService().GetAllTags();

        Assert.Multiple(() =>
        {
            Assert.That(respon, Is.Not.Null);
            Assert.That(respon.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
        });
    }


    [Test]
    public void CreateAndDeleteRequirement()
    {
        var service = new RequirementsService();
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

        var respon = service.CreateRequirement(model);
        Assert.Multiple(() =>
        {
            Assert.That(respon, Is.Not.Null);
            Assert.That(respon.Content, Is.Not.Null);
            Assert.That(respon.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.Created));
        });

        var responModel = JsonConvert
            .DeserializeObject<CommonResponse<RequirementResponseModel>>(respon.Content!)?.Data;
        Assert.Multiple(() =>
        {
            Assert.That(responModel, Is.Not.Null);
            Assert.That(responModel?.Name, Is.EqualTo(name));
            Assert.That(responModel?.Description, Is.EqualTo(description));
            Assert.That(responModel?.ProjectId, Is.EqualTo(projectId));
        });

        respon = service.DeleteRequirement(responModel!.Id.ToString());
        Assert.Multiple(() =>
        {
            Assert.That(respon, Is.Not.Null);
            Assert.That(respon.Content, Is.Empty);
            Assert.That(respon.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.NoContent));
        });
    }
}