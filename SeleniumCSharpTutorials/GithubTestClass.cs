using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumCSharpTutorials
{
    class GithubTestClass
    {
        public IWebDriver driver;

        [SetUp]
        public void Open()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://www.github.com/login";
        }

        [TearDown]
        public void Close()
        {
            driver.Quit();
        }


        [Test, Category("Regression Testing")]
        public void TestMethod1()
        {
            IWebElement loginField = driver.FindElement(By.XPath(".//*[@id='login_field']"));
            loginField.SendKeys("SeleniumCsharpLOGIN");
        }

        [Test, Category("Smoke Testing")]
        public void TestMethod2()
        {
            IWebElement loginField = driver.FindElement(By.XPath(".//*[@id='login_field']"));
            loginField.SendKeys("SeleniumCsharpLOGIN");
            Thread.Sleep(5000);
        }
    }
}
