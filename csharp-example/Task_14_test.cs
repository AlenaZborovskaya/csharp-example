using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using QAFramework.Elements;
using System.Collections.Generic;
using System.IO;
using System;
using System.Collections.ObjectModel;

namespace csharp_example
{
    [TestFixture]
    public class Task_14_test
    {
        private static IWebDriver driver;
        private WebDriverWait wait;

        GeneralElements elements = new GeneralElements(driver);

        [SetUp]
        public void start()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
           
        }

        public Func<IWebDriver, string> ThereIsWindowOtherThan(ICollection<string> windows)
        {
            ICollection<string> newWindows = driver.WindowHandles;

            foreach (var oldWindow in windows)
            {
                newWindows.Remove(oldWindow);
            }
            if (newWindows.Count > 0)
            {
               newWindows.GetEnumerator().MoveNext();
            }
           return null;
        }

        [Test]
        public void WindowTest()
        {

            driver.Url = "http://localhost/litecart/admin/?app=countries&doc=countries";
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("admin");
            driver.FindElement(By.Name("login")).Click();

            driver.FindElement(By.XPath("//*[@id='content']//*[contains(text(),'Afghanistan')]")).Click();
            int MenuCount = driver.FindElements(By.XPath("//*[contains(@class, 'fa fa-external-link')]")).Count;
            var menu = driver.FindElements(By.XPath("//*[contains(@class, 'fa fa-external-link')]"));
            string mainWindow = driver.CurrentWindowHandle;
            ICollection<string> oldWindows = driver.WindowHandles;
            for (int i = 0; i <= MenuCount - 1; i++)
            {
                menu[i].Click();
                string newWindow = wait.Until(ThereIsWindowOtherThan(oldWindows));
                driver.SwitchTo().Window(driver.WindowHandles[1]);
                driver.Close();
                driver.SwitchTo().Window(mainWindow);
            }
        }

        

        [OneTimeTearDown]
        public void stop()
        {
            driver.Quit();
            driver = null;
        }
    }
}
