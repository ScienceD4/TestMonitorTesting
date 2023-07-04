using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Core.Common;

public static class WaitHelper
{
    public static void Until(int timeMilliseconds, Func<bool> predicate)
    {
        var timeout = DateTime.Now.AddMilliseconds(timeMilliseconds);

        while (DateTime.Now < timeout)
        {
            if (predicate.Invoke())
                return;
        }
    }

    public static TResult WaitLoad<TResult>(this IWebDriver driver, Func<IWebDriver, TResult> condition, int timeout)
    {
        return new WebDriverWait(driver, TimeSpan.FromMilliseconds(timeout)).Until(condition);
    }
}