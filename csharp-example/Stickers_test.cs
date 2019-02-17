using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using QAFramework.Elements;

namespace csharp_example
{
    [TestFixture]
    public class Stickers_test
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
        public void Stickerstest()
        {
            driver.Url = "http://localhost/litecart/en/";

            // Проверяем, что для каждого товара есть стикер
            if (elements.AreElementsPresent(driver,By.XPath("//*[contains(@class,'product column')]")) == true)
            {
                var stickers = driver.FindElements(By.XPath("//*[contains(@class,'product column')]"));
                foreach (var element in stickers)
                {
                    Assert.IsTrue(elements.IsElementPresent(driver, By.XPath("//*[contains(@class,'sticker')]")));
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
