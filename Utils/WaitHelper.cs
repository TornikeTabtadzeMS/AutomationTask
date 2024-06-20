using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;

namespace AutomationTask.Utils
{
    public sealed class WaitHelper
    {
        private static WebDriverWait? wait;

        public static WebDriverWait Wait
        {
            get
            {
                wait ??= new WebDriverWait(DriverManager.GetDrivater(), TimeSpan.FromSeconds(10));
                return wait;
            }
        }

    }
}