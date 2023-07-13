using BussinesObject.Api.RestEntities;
using BussinesObject.Api.RestEntities.TestSuiteModels;
using BussinesObject.Api.Services;
using BussinesObject.Api.Utils;
using Newtonsoft.Json;
using NUnit.Framework;

namespace BussinesObject.Api.Steps;

public static class TestSuitesRequest
{
    public static TestSuitesService Service { get; } = new();

    public static TestSuiteResponseModel RestoreTestSuite(int testSuiteId)
    {
        var respon = Service.RestoreTestSuite(testSuiteId);
        RequestHelper.CheckResponse(respon, false, System.Net.HttpStatusCode.OK);

        var responModel = JsonConvert
            .DeserializeObject<CommonResponse<TestSuiteResponseModel>>(respon.Content!)?.Data;
        Assert.Multiple(() =>
        {
            Assert.That(responModel, Is.Not.Null);
            Assert.That(responModel?.Id, Is.EqualTo(testSuiteId));
        });

        return responModel!;
    }

    public static TestSuiteResponseModel CreateTestSuite(TestSuiteRequestModel model)
    {
        var respon = Service.CreateTestSuite(model);
        RequestHelper.CheckResponse(respon, false, System.Net.HttpStatusCode.Created);

        var responModel = JsonConvert
            .DeserializeObject<CommonResponse<TestSuiteResponseModel>>(respon.Content!)?.Data;
        Assert.Multiple(() =>
        {
            Assert.That(responModel, Is.Not.Null);
            Assert.That(responModel?.Name, Is.EqualTo(model.Name));
            Assert.That(responModel?.ProjectId, Is.EqualTo(model.ProjectId));
        });

        return responModel!;
    }

    public static TestSuiteResponseModel UpdateTestSuite(int testSuiteId, TestSuiteRequestModel model)
    {
        var respon = Service.UpdateTestSuite(testSuiteId, model);
        RequestHelper.CheckResponse(respon);

        var responModel = JsonConvert
            .DeserializeObject<CommonResponse<TestSuiteResponseModel>>(respon.Content!)?.Data;
        Assert.Multiple(() =>
        {
            Assert.That(responModel, Is.Not.Null);
            Assert.That(responModel?.Id, Is.EqualTo(testSuiteId));
        });

        return responModel!;
    }
}