using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace SeleniumCSharpTutorials
{
    [TestFixture]
    class SeleniumCSharpTutorial04
    {
        // Prepare test data
        private static IEnumerable<TestCaseData> DataDrivenLoginTesting
        {
            get
            {
                yield return new TestCaseData("https://facebook.com/", "id", "email");
                yield return new TestCaseData("https://github.com/login/", "id", "login_field");
                yield return new TestCaseData("https://e.wsei.edu.pl/login/index.php/", "id", "username");
            }
        }

        [Test]
        [Author("Jakub", "Jakub.Augustyn@microsoft.wsei.edu.pl")]
        [Description("Login field Verify")]
        [TestCaseSource("DataDrivenLoginTesting")]
        public void TestLoginFields(string urlName, string IdName, string IdValue)
        {
            IWebDriver driver = null;
            try
            {
                // Enter login on various sites  

                driver = new ChromeDriver();
                //driver.Manage().Window.Maximize();
                driver.Url = urlName;

                var path = $".//*[@{IdName}='{IdValue}']";
                IWebElement loginTextField = driver.FindElement(By.XPath(path));

                loginTextField.SendKeys("Selenium C#");
                driver.Quit();
            }
            catch (Exception e)
            {
                // If it fails take a screen shot  

                ITakesScreenshot ts = driver as ITakesScreenshot;
                Screenshot screenshot = ts.GetScreenshot();

                var path = Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().GetName().CodeBase).LocalPath);
                string fullPath = Path.GetFullPath(Path.Combine(path, @"..\..\Screenshots\Screenshot1.jpeg"));

                screenshot.SaveAsFile(fullPath, ScreenshotImageFormat.Jpeg);

                Console.WriteLine(e.StackTrace);

                throw;
            }
            finally
            {
                if (driver != null)
                {
                    driver.Quit();
                }
            }
        }
        

        [Test]
        [Description("Take screenshot test")]
        public void TestScreenshot()
        {
            IWebDriver driver = null;
            try
            {
                // Enter login on various sites  

                driver = new ChromeDriver();
                //driver.Manage().Window.Maximize();
                driver.Url = "https://e.wsei.edu.pl/login/index.php/";

                var path = $".//*[@idbledne='usernametez']";

                IWebElement loginTextField = driver.FindElement(By.XPath(path));

                loginTextField.SendKeys("Selenium C#");
                driver.Quit();

            }
            catch (Exception e)
            {
                // It fails and takes a screenshot  

                ITakesScreenshot ts = driver as ITakesScreenshot;
                Screenshot screenshot = ts.GetScreenshot();

                var path = Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().GetName().CodeBase).LocalPath);
                var fullPath = Path.Combine(path, $@"..\..\Screenshots\Screenshot{DateTime.Now.ToString("yyyy-MM-dd HH.mm.ss")}.jpeg");

                // Removing screenshots from previous tests
                string[] filePaths = Directory.GetFiles(Path.Combine(path, $@"..\..\Screenshots\"));
                foreach (string filePath in filePaths)
                    File.Delete(filePath);

                // Screenshots have about 100KB, but dont forget to clear the folder sometimes
                screenshot.SaveAsFile(fullPath, ScreenshotImageFormat.Jpeg);
                
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                if (driver != null)
                {
                    driver.Quit();
                }
            }
        }
    }
}
