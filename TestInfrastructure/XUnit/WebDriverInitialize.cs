using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace RyłkoWeb_TestFramework.TestInfrastructure.XUnit
{
   public class WebDriverInitialize
    {
        public WebDriverInitialize()
        {
            driver = new ChromeDriver();
        }
        public IWebDriver driver;
    }
}
