using BussinesObject.Api.Services;

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
}