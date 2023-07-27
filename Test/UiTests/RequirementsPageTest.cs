using BussinesObject.Ui.Steps;
using BussinesObject.Ui.UiEntities;

namespace Test.UiTests;

[TestFixture]
public class RequirementsPageTest : BaseTest
{
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
}
