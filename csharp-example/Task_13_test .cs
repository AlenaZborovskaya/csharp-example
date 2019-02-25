using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using QAFramework.Elements;
using System.Collections.Generic;
using System.IO;
using System;

namespace csharp_example
{
    [TestFixture]
    public class Task_13_test
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
        public void BusketTest()
        {
            driver.Url = "http://localhost/litecart/en/";

            // Добавляем товары в корзину
            for (int i=1; i <= 3; i++)
            {
                driver.FindElement(By.XPath("//*[@id='box-most-popular']//li["+ i +"]")).Click();
                if (elements.IsElementPresent(driver, By.XPath("//*[@id='box-product']//select")) == true)
                {
                    driver.FindElement(By.XPath("//*[@id='box-product']//select")).SendKeys("large" + Keys.Enter);
                }
                //countBefore = driver.FindElement(By.XPath("//span[@class='quantity']")).GetAttribute("textContent");
                driver.FindElement(By.XPath("//button[@name='add_cart_product']")).Click();
                driver.Navigate().Refresh();
                string countAfter = driver.FindElement(By.XPath("//span[@class='quantity']")).GetAttribute("textContent");

                //wait.Until(ExpectedConditions.StalenessOf(countBefore));
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
