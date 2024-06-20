using OpenQA.Selenium;


namespace AutomationTask.Utils
{
    public static class DriverManager
    {
        private static IWebDriver? webDriver;

        public static IWebDriver GetDrivater()
        {
            string propertyValue = Hellper.ReadJsonConfig("browser").ToString();

            webDriver ??= DriverFactory.FactorDriver(propertyValue);

            return webDriver;
        }


        public static void NullifyDriver()
        {
            if (webDriver is not null)
            {
                webDriver.Quit();
                webDriver = null;
            }
            return;
        }
    }
}