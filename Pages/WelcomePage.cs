using AutomationTask.Utils;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using Serilog;



namespace AutomationTask.Pages
{
    public class WelcomePage : BasePage
    {
        public WelcomePage(string pageUrl) : base(pageUrl)
        {
        }

        public By LoginButtonLocator => By.XPath("//button[@data-testid='header-login']");

        public void ClickLoginButton() => WaitHelper.Wait.Until(ExpectedConditions.ElementToBeClickable(LoginButtonLocator)).Click();

    }
}