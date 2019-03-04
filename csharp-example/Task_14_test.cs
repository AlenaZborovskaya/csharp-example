using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace csharp_example
{
    [TestFixture]
    public class Task_14_test
    {
        private static IWebDriver driver;
        private WebDriverWait wait;

        [SetUp]
        public void start()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
           
        }


        [Test]
        public void WindowTest()
        {

            driver.Url = "http://localhost/litecart/admin/?app=countries&doc=countries";
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("admin");
            driver.FindElement(By.Name("login")).Click();


            driver.FindElement(By.XPath("//*[@id='content']//*[contains(text(),'Afghanistan')]")).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//td[@id='content']")));
                IList<IWebElement> menu = driver.FindElements(By.XPath("//*[contains(@class, 'fa fa-external-link')]"));
                string mainWindow = driver.CurrentWindowHandle;
                int oldWindowsCount = driver.WindowHandles.ToList().Count;
                foreach (IWebElement element in menu)
                {
                    element.Click();

                    wait.Until(driver => driver.WindowHandles.Count == (oldWindowsCount + 1));

                    foreach (string handle in driver.WindowHandles.ToList())
                    {
                        if (mainWindow != handle)
                        {
                            driver.SwitchTo().Window(handle).Close();
                            driver.SwitchTo().Window(mainWindow);
                        }
                    }
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
