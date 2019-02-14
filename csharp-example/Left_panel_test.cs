using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using QAFramework.Elements;

namespace csharp_example
{
    [TestFixture]
    public class Left_panel_test
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

        [Test]
        public void Left_Panel_test()
        {
            driver.Url = "http://localhost/litecart/admin/login.php?redirect_url=%2Flitecart%2Fadmin%2F";
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("admin");
            driver.FindElement(By.Name("login")).Click();
            wait.Until(ExpectedConditions.TitleIs("My Store"));


           int headCount = driver.FindElements(By.XPath("//li[@id='app-']")).Count;

           for (int i = 1; i <= headCount; i++ )
            {
                string headLocator = "//li[@id='app-'][" + i + "]";
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(headLocator)));
                driver.FindElement(By.XPath(headLocator)).Click();

                if (elements.AreElementsPresent(driver, By.TagName("span")) == true)
                {
                    int childCount = driver.FindElements(By.XPath(headLocator + "//li")).Count;

                    for (int a =1; a <= childCount; a++)
                    {
                        string childLocator = headLocator + "//li[" + a + "]";
                        wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(childLocator)));
                        driver.FindElement(By.XPath(childLocator)).Click();

                        Assert.IsTrue(elements.IsElementPresent(driver, By.XPath("//h1")));
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
