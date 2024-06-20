using System;
using System.IO;
using AutomationTask.Utils;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using Serilog;

namespace AutomationTask.Test
{
    [TestFixture]
    public class BaseTest
    {
        private static readonly string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Spark.html");
        protected ExtentReports extent = new();
        private readonly ExtentSparkReporter spark = new("Spark.html");

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            var baseUrl = "https://www.trivago.com/";

            // config reporter
            extent.AttachReporter(spark);

            // config logger
            Hellper.ConfigLogger();

            Log.Information("the tests started");

            DriverManager.GetDrivater().Navigate().GoToUrl(baseUrl);
            DriverManager.GetDrivater().Manage().Window.Maximize();
            Log.Information("the site is opened");
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            DriverManager.NullifyDriver();
            Log.Information("the tests finished");
        }
    }
}