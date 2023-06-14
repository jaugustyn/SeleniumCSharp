using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumCSharpTutorials
{
    [TestFixture]
    class OrderSkipAttribute
    {

        [Test, Order(2), Category("OrderSkipAttribute")]
        public void TestMethod1()
        {
            //Assert.Ignore("Defect 12345");
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://www.facebook.com/";
            IWebElement emailTextField = driver.FindElement(By.XPath(".//*[@id='email']"));
            emailTextField.SendKeys("Selenium C#");
            driver.Close();
        }

        [Test, Order(1), Category("OrderSkipAttribute")]
        public void TestMethod2()
        {
            try
            {
                IWebDriver driver = new FirefoxDriver();
                driver.Url = "https://www.facebook.com/";
                IWebElement emailTextField = driver.FindElement(By.XPath(".//*[@id='email']"));
                emailTextField.SendKeys("Selenium C#");
                driver.Close();
            }
            catch(InvalidOperationException ex)
            {
                Console.WriteLine("Pliki binarne Firefox'a nie zostały znaleziony. Sprawdź czy przeglądarka jest zainstalowana" + ex);
            }
        }

        [Test, Order(0), Category("OrderSkipAttribute")]
        public void TestMethod3()
        {
            try
            {
                IWebDriver driver = new InternetExplorerDriver();
                driver.Url = "https://www.facebook.com/";
                IWebElement emailTextField = driver.FindElement(By.XPath(".//*[@id='email']"));
                emailTextField.SendKeys("Selenium C#");
                driver.Close();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("Pliki binarne InternetExplorera nie zostały znaleziony. Sprawdź czy przeglądarka jest zainstalowana:" + ex);
            }
            catch(Exception ex)
            {
                Console.WriteLine("InternetExplorer nie jest wspieraną przeglądarką przez Facebooka" + ex);
            }
        }
    }
}
