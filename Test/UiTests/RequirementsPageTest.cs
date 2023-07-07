using BussinesObject.Ui.Steps;
using BussinesObject.Ui.UiEntities;

namespace Test.UiTests;

[TestFixture]
public class RequirementsPageTest : BaseTest
{
    [Test]
    public void CheckRequirements()
    {
        var records = LoginStep.Login()
            .OpenRequirements()
            .RequirementsTable.GetData().Value;

        Assert.That(records, Is.Not.Empty);
    }

    [Test]
    public void AddAndCheckRequirements()
    {
        var name = Core.Common.DataGenerator.GetSentence();
        var desc = Core.Common.DataGenerator.GetText();

        var records = LoginStep.Login()
            .OpenRequirements()
            .AddRequirement(name, desc)
            .RequirementsTable.GetData().Value;

        Assert.That(records?.Select(x => x.Name), Does.Contain(name));
    }

    [Test]
    public void AddSearchAndCheckRequirements()
    {
        var name = Core.Common.DataGenerator.GetSentence();
        var desc = Core.Common.DataGenerator.GetText();

        var records = LoginStep.Login()
            .OpenRequirements()
            .AddRequirement(name, desc)
            .SearchRequirement(name)
            .RequirementsTable.GetData().Value;

        Assert.That(records?.Select(x => x.Name), Does.Contain(name));
    }

    [Test]
    public void SelectRequirements()
    {
        var code1 = "RQ1";
        var code2 = "RQ2";

        Assert.DoesNotThrow(() =>
        {
            var page = LoginStep.Login()
            .OpenRequirements();

            page.RequirementsTable.Value = new List<RequirementsRecord>
            {
                new RequirementsRecord
                {
                    Code = code1,
                    Action = RequirementsRecord.ActionRequirements.Select
                },
                new RequirementsRecord
                {
                    Code = code2,
                    Action = RequirementsRecord.ActionRequirements.Select
                }
            };

            page.RequirementsTable.FillIn();
        });
    }
}