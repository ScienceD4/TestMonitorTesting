using BussinesObject.Ui.Steps;

namespace Test.UiTests;

[TestFixture]
public class LoginTest : BaseTest
{
    [Test]
    public void Login()
    {
        LoginStep.Login();
    }
}