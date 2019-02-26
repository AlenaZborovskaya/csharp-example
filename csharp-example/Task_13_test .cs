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

                string before = driver.FindElement(By.XPath("//span[@class='quantity']")).Text;
                driver.FindElement(By.XPath("//button[@name='add_cart_product']")).Click();
                wait.Until(ExpectedConditions.InvisibilityOfElementWithText(By.XPath("//div[@id='cart']//span[@class='quantity']"), before));
                string after = driver.FindElement(By.XPath("//span[@class='quantity']")).Text;
                if (after != before)
                {
                    driver.FindElement(By.XPath("//a[@href ='http://localhost/litecart/en/']")).Click();
                }
            }

            driver.FindElement(By.XPath("//a[@class='link'][contains(text(),'Checkout »')]")).Click();
            driver.FindElement(By.XPath("//li[@class='shortcut'][1]")).Click();
            int productsInBusket = driver.FindElements(By.XPath("//*[@id='checkout-summary-wrapper']//tbody/tr/td[contains(@class,'item')]")).Count;
            for (int i = 1; i <= productsInBusket; i++)
            {
                string product = driver.FindElement(By.XPath("//*[@id='checkout-summary-wrapper']//tbody/tr/td[contains(@class,'item')]")).Text;
                driver.FindElement(By.XPath("//button[@type='submit'][contains(text(),'Remove')]")).Click();
                wait.Until(ExpectedConditions.InvisibilityOfElementWithText(By.XPath("//*[@id='checkout-summary-wrapper']//tbody/tr/td[contains(@class,'item')]"), product));
            }
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[contains(text(),'There are no items in your cart.')]")));
        }

        [OneTimeTearDown]
        public void stop()
        {
            driver.Quit();
            driver = null;
        }
    }
}
