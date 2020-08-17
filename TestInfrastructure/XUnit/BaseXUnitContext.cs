using RyłkoWeb_TestFramework.TestInfrastructure.XUnit;
using System;

namespace RyłkoWeb_TestFramework.Rylko_Pages
{
    public class BaseXUnitContext : WebDriverWrapper, IDisposable
    {
        public BaseXUnitContext()
        {
            Page.Navigate().GoToUrl(url);
            Page.Manage().Window.Maximize();
        }

        public void Dispose()
        {
            Page.Close();
        }

        private const string url = "https://www.rylko.com/";
    }
}

