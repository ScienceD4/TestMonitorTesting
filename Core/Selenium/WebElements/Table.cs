﻿using Core.Selenium.Attributes;
using OpenQA.Selenium;
using System.Reflection;

namespace Core.Selenium.WebElements;

public class Table<TRecord> : BaseElement where TRecord : new()
{
    private static readonly By locatorRows = By.XPath(".//tbody/tr");
    private static readonly By locatorItem = By.XPath("./child::td");

    public List<TRecord>? Value { get; set; }

    public Table(By locator) : base(locator)
    {
    }

    public Table<TRecord> GetData()
    {
        Parse();

        return this;
    }

    private void Parse()
    {
        var webRows = WebElement.FindElements(locatorRows);
        var listRecords = new List<TRecord>();
        var props = typeof(TRecord).GetProperties();

        foreach (var webRow in webRows)
        {
            var record = new TRecord();
            var items = webRow.FindElements(locatorItem);

            for (var i = 0; i < items.Count; i++)
            {
                var propsWithIndex = props.Where(x => x.GetCustomAttribute<RecordIndexAttribute>()?.Index == i);

                foreach (var prop in propsWithIndex)
                {
                    var locator = prop.GetCustomAttribute<RecordLocatorAttribute>()?.Locator;
                    if (locator is null) continue;

                    var content = items[i].FindElement(locator).Text;
                    prop.SetValue(record, content);
                }
            }

            listRecords.Add(record);
        }

        Value = listRecords;
    }
}