using BussinesObject.Api.RestEntities.TestSuiteModels;
using BussinesObject.Api.Services;
using BussinesObject.Api.Steps;
using BussinesObject.Api.Utils;
using Core.Common;

namespace Test.ApiTests;

[TestFixture]
public class TestSuiteServiceTest : BaseTest
{
    private static readonly TestSuitesService service = TestSuitesRequest.Service;

    [Test]
    public void GetAllTestSuites()
    {
        var respon = service.GetAllTestSuites();
        RequestHelper.CheckResponse(respon, false, System.Net.HttpStatusCode.OK);
    }

    [Test]
    public void GetTestSuite()
    {
        var respon = service.GetTestSuite(1);
        RequestHelper.CheckResponse(respon, false, System.Net.HttpStatusCode.OK);
    }

    [Test]
    public void CreateAndDeleteTestSuite()
    {
        var name = DataGenerator.GetSentence();
        var description = DataGenerator.GetText();
        var projectId = Core.Settings.Settings.API.MainProjectId;

        var model = new TestSuiteRequestModel()
        {
            ProjectId = projectId,
            Name = name,
            Description = description
        };

        var responModel = TestSuitesRequest.CreateTestSuite(model);
        Assert.That(responModel.Description, Is.EqualTo(model.Description));

        var respon = service.DeleteTestSuite(responModel.Id);
        RequestHelper.CheckResponse(respon, true, System.Net.HttpStatusCode.NoContent);
    }

    [Test]
    public void UpdateTestSuite()
    {
        var name = DataGenerator.GetSentence();
        var description = DataGenerator.GetText();
        var testSuiteId = 5;

        var model = new TestSuiteRequestModel()
        {
            Name = name,
            Description = description
        };

        var responModel = TestSuitesRequest.UpdateTestSuite(testSuiteId, model);
        Assert.Multiple(() =>
        {
            Assert.That(responModel.Name, Is.EqualTo(model.Name));
            Assert.That(responModel.Description, Is.EqualTo(model.Description));
        });
    }

    [Test]
    public void DeleteAndRestoreTestSuite()
    {
        var testSuiteId = 5;

        var respon = service.DeleteTestSuite(testSuiteId);
        RequestHelper.CheckResponse(respon, true, System.Net.HttpStatusCode.NoContent);

        TestSuitesRequest.RestoreTestSuite(testSuiteId);
    }
}