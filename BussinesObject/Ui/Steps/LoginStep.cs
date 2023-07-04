using BussinesObject.Ui.Pages;

namespace BussinesObject.Ui.Steps;

public class LoginStep
{
    public static LoginPage Login()
    {
        return new LoginPage().Show().LogIn();
    }
}