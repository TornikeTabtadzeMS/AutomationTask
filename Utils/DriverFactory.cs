using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace AutomationTask.Utils
{
    public static class DriverFactory
    {
        public static IWebDriver FactorDriver(string driver)
        {
            return driver.ToLower() switch
            {
                "chrome" => new ChromeDriver(),
                "firefox" => new FirefoxDriver(),
                "edge" => new EdgeDriver(),
                _ => throw new ArgumentException("not supported browser"),
            };
        }
    }
}