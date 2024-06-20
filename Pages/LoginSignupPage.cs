using AutomationTask.Utils;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using Serilog;

namespace AutomationTask.Pages
{
    public class LoginSignupPage : BasePage
    {
        public LoginSignupPage(string pageUrl) : base(pageUrl)
        {
        }

        public By EmailInputLocator => By.XPath("//input[@data-testid='email-input']");
        public By ContinueButtonLocator => By.XPath("//button[@data-testid='login-next-button']");

        public void InsertEmailValue(string email) => WaitHelper.Wait.Until(ExpectedConditions.ElementToBeClickable(EmailInputLocator)).SendKeys(email);

        public void ClickContinueButton() => WaitHelper.Wait.Until(ExpectedConditions.ElementToBeClickable(ContinueButtonLocator)).Click();
    }
}