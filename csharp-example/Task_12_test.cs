using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.IO;
using System;

namespace csharp_example
{
    [TestFixture]
    public class Task_12_test
    {
        private IWebDriver driver;
        private WebDriverWait wait;


        [SetUp]
        public void start()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public static string MakeRelative(string filePath, string referencePath)
        {
            var fileUri = new Uri(filePath);
            var referenceUri = new Uri(referencePath);
            return referenceUri.MakeRelativeUri(fileUri).ToString();
        }

        [Test]
        public void ProductCreation()
        {
            driver.Url = "http://localhost/litecart/admin";

            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("admin");
            driver.FindElement(By.Name("login")).Click();
            wait.Until(ExpectedConditions.TitleIs("My Store"));

            //D:\selenium_courses\csharp - example\csharp - example\1.jpg
            var link = MakeRelative(@"D:\selenium_courses\csharp-example\csharp-example\1.jpg", @"D:\selenium_courses\csharp-example\");
            var test = @"..\..\";
            string file = Path.GetFullPath(link);

            

            // Заполняем форму товара на вкладке General
            driver.FindElement(By.XPath("//li[@id='app-']//*[contains(text(),'Catalog')]")).Click();
            driver.FindElement(By.XPath("//a[@class='button'][contains(text(),' Add New Product')]")).Click();
            driver.FindElement(By.Name("name[en]")).SendKeys("Tonic");
            driver.FindElement(By.Name("code")).SendKeys("123456");
            driver.FindElement(By.XPath("//input[@type='checkbox'][@name='categories[]'][@data-name='Rubber Ducks']")).Click();
            driver.FindElement(By.XPath("//input[@type='checkbox'][@name='product_groups[]'][@value='1-2']")).Click();
            driver.FindElement(By.XPath("//*[@name='quantity']")).Clear();
            driver.FindElement(By.XPath("//*[@name='quantity']")).SendKeys("150");
            driver.FindElement(By.Name("new_images[]")).SendKeys(link);
            driver.FindElement(By.XPath("//*[@name='date_valid_from']")).SendKeys("22.02.2019");
            driver.FindElement(By.XPath("//*[@name='date_valid_to']")).SendKeys("23.02.2019");

            // Переходим на вкладку Information
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//a[contains(text(),'Information')]")));
            driver.FindElement(By.XPath("//a[contains(text(),'Information')]")).Click();
            driver.FindElement(By.XPath("//select[@name='manufacturer_id']")).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//option[@value='1'][contains(text(),'ACME Corp.')]")));
            driver.FindElement(By.XPath("//option[@value='1'][contains(text(),'ACME Corp.')]")).Click();
            driver.FindElement(By.Name("keywords")).SendKeys("Cosmetica");
            driver.FindElement(By.Name("short_description[en]")).SendKeys("Short Description");
            driver.FindElement(By.ClassName("trumbowyg-editor")).SendKeys("Description");
            driver.FindElement(By.Name("head_title[en]")).SendKeys("Tonic");
            driver.FindElement(By.Name("meta_description[en]")).SendKeys("T");

            // Переходим на вкладку Prices
            wait.Until(ExpectedConditions.ElementExists(By.Name("purchase_price_currency_code")));
            driver.FindElement(By.XPath("//a[contains(text(),'Prices')]")).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@name='purchase_price']")));
            driver.FindElement(By.XPath("//*[@name='purchase_price']")).Clear();
            driver.FindElement(By.XPath("//*[@name='purchase_price']")).SendKeys("100");
            driver.FindElement(By.Name("purchase_price_currency_code")).Click();
            driver.FindElement(By.XPath("//option[contains(text(),'US Dollars')]")).Click();
            driver.FindElement(By.Name("prices[USD]")).SendKeys("500");

            //Сохраняем
            driver.FindElement(By.Name("save")).Click();
            driver.FindElement(By.XPath("//*[@id='content']//a[contains(text(),'Tonic')]"));

        }

        [OneTimeTearDown]
        public void stop()
        {
            driver.Quit();
            driver = null;
        }
    }
}
