using BussinesObject.Ui.Pages;

namespace BussinesObject.Ui.Steps;

public static class LoginStep
{
    public static HomePage Login()
    {
        return new LoginPage().Show().LogIn();
    }
}