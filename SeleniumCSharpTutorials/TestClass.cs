using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumCSharpTutorials.BaseClass;

namespace SeleniumCSharpTutorials
{
    [TestFixture]
    public class TestClass: BaseTest
    {
        [Test, Category("Smoke Testing")]
        public void TestMethod1()
        {
            // Accept cookie
            IWebElement cookiesAcceptButton = driver.FindElement(By.XPath(".//*[@data-cookiebanner='accept_button']"));
            cookiesAcceptButton.Click();

            // Enter password
            IWebElement passwordField = driver.FindElement(By.XPath(".//*[@id='pass']"));
            passwordField.SendKeys("SeleniumCsharpPassword");
            Thread.Sleep(2000);
            
            

        }

        [Test, Category("Regression Testing")]
        public void TestMethod2()
        {
            // Accept cookie
            IWebElement cookiesAcceptButton = driver.FindElement(By.XPath(".//*[@data-cookiebanner='accept_button']"));
            cookiesAcceptButton.Click();

            // Click new account <a> button
            IWebElement newAccountButton = driver.FindElement(By.XPath(".//*[@data-testid='open-registration-form-button']"));
            newAccountButton.SendKeys(Keys.Enter);
            Thread.Sleep(2000); // It takes some time to open a new window

            // Select month
            IWebElement monthDropdownList = driver.FindElement(By.XPath(".//*[@id='month']"));
            SelectElement element = new SelectElement(monthDropdownList);
            element.SelectByIndex(2); //Select by index
            element.SelectByText("cze"); //Select by text
            element.SelectByValue("12"); //Select by value
            Thread.Sleep(2000);

        }

        [Test, Category("Smoke Testing")]
        public void TestMethod3()
        {
            // Enter email
            IWebElement emailTextField = driver.FindElement(By.XPath(".//*[@id='email']"));
            emailTextField.SendKeys("Selenium C#");
            Thread.Sleep(2000);
        }
    }
}
