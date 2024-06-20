using AutomationTask.Utils;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using Serilog;

namespace AutomationTask.Pages
{
    public class RegistrerPage : BasePage
    {
        public RegistrerPage(string pageUrl) : base(pageUrl)
        {
        }

        public By PasswordFieldLocator => By.XPath("//input[@data-testid='password-strength-input']");
        public By CreateAccountButtonLocator => By.XPath("//button[@data-testid='register-submit-button']");


        public void InsertPassword(string password) => WaitHelper.Wait.Until(ExpectedConditions.ElementToBeClickable(PasswordFieldLocator)).SendKeys(password);

        public void ClickCreateAccountButton() => WaitHelper.Wait.Until(ExpectedConditions.ElementToBeClickable(CreateAccountButtonLocator)).Click();
    }
}