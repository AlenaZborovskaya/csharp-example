using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace csharp_example
{
    [TestFixture]
    public class Task_11_test
    {
        private IWebDriver driver;
        private WebDriverWait wait;


        [SetUp]
        public void start()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public string CreateRandormMail()
        {
            Random random = new Random();
            int randomNumber = random.Next(0, 10000);
            return randomNumber + "@mail.ru";
        }
        

        [Test]
        public void NewUserTest()
        {
           
        
            driver.Url = "http://localhost/litecart/en/";
            driver.FindElement(By.XPath("//*[@id='box-account-login']//a[contains(text(),'New customers click here')]")).Click();
           // wait.Until(ExpectedConditions.TitleIs("Create Account"));
            driver.FindElement(By.XPath("//*[@name='customer_form']//*[@name='firstname']")).SendKeys("Alena");
            driver.FindElement(By.XPath("//*[@name='customer_form']//*[@name='lastname']")).SendKeys("Zborovsakya");
            driver.FindElement(By.XPath("//*[@name='customer_form']//*[@name='address1']")).SendKeys("Okskaya");
            driver.FindElement(By.XPath("//*[@name='postcode']")).SendKeys("12345");
            driver.FindElement(By.XPath("//*[@name='city']")).SendKeys("NiNo");
            driver.FindElement(By.XPath("//*[@role='combobox']")).Click();
            driver.FindElement(By.XPath("//*[@type='search']")).SendKeys("United States" + Keys.Enter);
            driver.FindElement(By.XPath("//input[@type='email']")).SendKeys(CreateRandormMail());
            driver.FindElement(By.XPath("//input[@type='tel']")).SendKeys("12345678910");
            driver.FindElement(By.XPath("//input[@name='password']")).SendKeys("qwerty");
            driver.FindElement(By.XPath("//input[@name='confirmed_password']")).SendKeys("qwerty");
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
            driver.FindElement(By.XPath("//*[@id='box-account']//a[contains(text(),'Logout')]")).Click();
            driver.FindElement(By.XPath("//*[@name='email']")).SendKeys("shum-1271@mail.ru");
            driver.FindElement(By.XPath("//input[@type='password']")).SendKeys("qwerty");
            driver.FindElement(By.XPath("//button[@name='login']")).Click();
            driver.FindElement(By.XPath("//*[@id='box-account']//a[contains(text(),'Logout')]")).Click();
        }

        [OneTimeTearDown]
        public void stop()
        {
            driver.Quit();
            driver = null;
        }
    }
}
