using AutomationTask.Utils;
using OpenQA.Selenium;
using Serilog;

namespace AutomationTask.Pages
{
    public class BasePage
    {
        private string _expectedUrl;

        public BasePage(string pageUrl)
        {
            _expectedUrl = pageUrl;
        }

        public virtual bool CheckIfWrightPage() => WaitHelper.Wait.Until(d => d.Url == _expectedUrl);
    }
}