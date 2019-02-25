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
                string before = driver.FindElement(By.XPath("//span[@class='quantity']")).GetAttribute("textContent");
                int countBefore = Convert.ToInt32(before);
                driver.FindElement(By.XPath("//button[@name='add_cart_product']")).Click();
                string after = driver.FindElement(By.XPath("//span[@class='quantity']")).GetAttribute("textContent");
                int countAfter = Convert.ToInt32(before);

                if (countAfter > countBefore)
                {
                    driver.FindElement(By.XPath("//a[contains(text(),'Checkout »')]")).Click();
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
