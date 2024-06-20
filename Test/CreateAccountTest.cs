using System;
using AutomationTask.Pages;
using AutomationTask.Utils;
using NUnit.Framework;
using Serilog;

namespace AutomationTask.Test
{
    [TestFixture]
    public class CreateAccountTest : BaseTest
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestRegistrationShouldCreateNewUser()
        {
            Log.Information("the registrate positive test has started");

            var test = extent.CreateTest("registration positive");
            var correctEmail = Hellper.GenerateEmail();
            var correctPassword = "TheCorrectPassword";

            WelcomePage welcomePage = new("https://www.trivago.com/");
            LoginSignupPage loginSignupPage = new("https://auth.trivago.com/en-US");
            RegistrerPage registrerPage = new("https://auth.trivago.com/en-US/register");
            MyAccountPage myAccountPage = new("https://www.trivago.com/en-US/profile/account-settings");
            try
            {
                Assert.IsTrue(welcomePage.CheckIfWrightPage(), "the welcome page is not visible");
                Log.Information("Asserted if Welocme page was open");

                welcomePage.ClickLoginButton();
                Log.Information("Clicked Loging Button in welcome page");

                Assert.IsTrue(loginSignupPage.CheckIfWrightPage(), "the login/signup page is not visible");
                Log.Information("Asserted if Login/Signup page was open");

                loginSignupPage.InsertEmailValue(correctEmail);
                Log.Information($"Inserted email: {correctEmail}");

                loginSignupPage.ClickContinueButton();
                Log.Information("Clicked Continue button");

                Assert.IsTrue(registrerPage.CheckIfWrightPage(), "the register page is not visible");
                Log.Information("Asserted if register page was open");

                registrerPage.InsertPassword(correctPassword);
                Log.Information($"inserted correct password: {correctPassword}");

                registrerPage.ClickCreateAccountButton();
                Log.Information("clicked 'create account' button");

                Assert.IsTrue(welcomePage.CheckIfWrightPage(), "something went wrong with registration, welcome page is not visible");
                Log.Information("asserted if welcome page was opened");

                test.Pass($"test case: {nameof(TestRegistrationShouldCreateNewUser)} passed");
                extent.Flush();
            }
            catch (Exception e)
            {
                test.Fail($"test case: {nameof(TestRegistrationShouldCreateNewUser)} failed\n {e.StackTrace}");
                extent.Flush();

                Log.Error($"test case: {nameof(TestRegistrationShouldCreateNewUser)} failed\n {e.StackTrace}");

                throw new Exception(e.StackTrace);
            }
        }


        [TearDown]
        public void TearDown()
        {
        }
    }
}

