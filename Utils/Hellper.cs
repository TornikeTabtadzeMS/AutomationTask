using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium.Support.UI;
using Serilog;
using Serilog.Sinks.SystemConsole.Themes;

namespace AutomationTask.Utils
{
    public static class Hellper
    {
        public static JToken ReadJsonConfig(string key)
        {
            var jsonFilePath = Path.Combine(Directory.GetCurrentDirectory(), "../../../config.json");

            string jsonString = File.ReadAllText(jsonFilePath);

            JObject jsonObject = JObject.Parse(jsonString);

            JToken propertyValue = jsonObject[key] ?? throw new NullReferenceException($"the value with key {key} could not be found");
            return propertyValue;
        }

        public static void ConfigLogger()
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console(theme: AnsiConsoleTheme.Grayscale)
                .WriteTo.File(
                    Path.Combine(Directory.GetCurrentDirectory(), "../../../Logs/Logs.txt"),
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
                .CreateLogger();
        }

        public static string GenerateEmail()
        {
            string[] domains = { "example.com", "test.com", "sample.org" };
            string chars = "abcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();

            string username = new string(Enumerable.Repeat(chars, 10)
                .Select(s => s[random.Next(s.Length)]).ToArray());
            string domain = domains[random.Next(domains.Length)];

            return $"{username}@{domain}";
        }

    }
}