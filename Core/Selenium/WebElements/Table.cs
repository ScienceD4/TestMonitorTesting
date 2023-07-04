using OpenQA.Selenium;

namespace Core.Selenium.WebElements;

public class Table : BaseElement
{
    private static readonly By locatorCol = By.XPath(".//thead//th");
    private static readonly By locatorRows = By.XPath(".//tbody/tr");
    private static readonly By locatorItem = By.XPath("./child::*");

    public List<string> Columns { get; set; }
    public List<Dictionary<string, string>> Rows { get; set; }

    public Table(By locator) : base(locator)
    {
    }

    public Table GetData()
    {
        Parse();

        return this;
    }

    private void Parse()
    {
        Columns = WebElement.FindElements(locatorCol)
            .Select((e, i) =>
                {
                    var text = e.Text.Trim().Replace("\r", "").Replace("\n", "");
                    return string.IsNullOrWhiteSpace(text) ? i.ToString() : text;
                })
            .ToList();
        Rows = new List<Dictionary<string, string>>();

        var webRows = WebElement.FindElements(locatorRows);

        foreach (var webRow in webRows)
        {
            var dict = new Dictionary<string, string>();

            var items = webRow.FindElements(locatorItem).Select(e => e.Text).ToList();

            var itemslen = items.Count;
            for (int i = 0; i < Columns.Count; i++)
            {
                if (i < itemslen)
                {
                    dict.Add(Columns[i], items[i]);
                }
                else
                {
                    dict.Add(Columns[i], string.Empty);
                }
            }

            Rows.Add(dict);
        }
    }
}