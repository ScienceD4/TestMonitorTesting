using BussinesObject.Ui.UiEntities;
using Core.Selenium.WebElements;
using OpenQA.Selenium;

namespace BussinesObject.Ui.Pages;

public class RequirementsPage : BasePage
{
    public Button AddRequirementsButton { get; set; }
        = new(By.XPath("//nav[@aria-label='navigation']//button[contains(text(), 'Add Requirement')]"));

    public Button RequirementsButton { get; set; } = new(By.XPath("//a[contains(@href, '/define/requirements')]"));
    public Button RisksButton { get; set; } = new(By.XPath("//a[contains(@href, '/define/risks')]"));
    public Button FilterButton { get; set; } = new(By.XPath("//div[@class='table-filter-component']/button"));
    public Input SearchInput { get; set; } = new(By.XPath("//input[@type='search']"));
    public Table<RequirementsRecord> RequirementsTable { get; set; } = new(By.XPath("//div[@class='card-content']//table"));

    public RequirementsPage AddRequirement(string name, string description)
    {
        AddRequirementsButton.Click();
        new RequirementsAddForm().AddRequirement(name, description);

        return this;
    }

    public RequirementsPage SearchRequirement(string name)
    {
        SearchInput.FillIn(name);

        return this;
    }
}

public class RequirementsAddForm
{
    private static readonly string modalXPath = "//div[@class='modal-card']";
    public Button Type { get; set; } = new(By.XPath(modalXPath + "//div[@class='control']//button[@type='button']"));
    public Input Name { get; set; } = new(By.XPath(modalXPath + "//label[contains(text(), 'Name')]/parent::div//input"));
    public Input Description { get; set; } = new(By.XPath(modalXPath + "//label[contains(text(), 'Description')]/parent::div/div//p"));
    public Button AddButton { get; set; } = new(By.XPath(modalXPath + "//span[text()='Add']/parent::button"));

    public void AddRequirement(string name, string description)
    {
        Name.FillIn(name);
        Description.FillIn(description);
        AddButton.Click();
        AddButton.Wait(x => !x.IsExist);
    }
}