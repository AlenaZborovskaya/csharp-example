using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using QAFramework.Elements;

namespace csharp_example
{
    [TestFixture]
    public class SortedCountries_test
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
        public void SortedCountries()
        {
            driver.Url = "http://localhost/litecart/admin/?app=countries&doc=countries";
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("admin");
            driver.FindElement(By.Name("login")).Click();

            // Проверяем что все странны отсортированы
            List<string> countries = new List<string>();
            var elements = driver.FindElements(By.XPath("//form[@name='countries_form']//td[5]"));
            foreach (var element in elements)
            {
                string nameOfCountry = element.GetAttribute("textContent");

                countries.Add(nameOfCountry);
            }

            List<string> sortedCountries = new List<string>();
            sortedCountries.AddRange(countries);
            sortedCountries.Sort();

            Assert.AreEqual(countries, sortedCountries);

            // Проверяем, что если тайм зона отличается от нуля, внутри страницы страны также отсортированы
           
           int countriesZones = driver.FindElements(By.XPath("//form[@name='countries_form']//tr[not(td[6]='0')][td[5]]")).Count;
           for (int i = 1; i <= countriesZones; i++)
            {
                IWebElement scrollElement = driver.FindElement(By.XPath("(//form[@name='countries_form']//tr[not(td[6]='0')][td[5]]/td[5]/a)[" + i + "]"));
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", scrollElement);

                string countryLocator = "(//form[@name='countries_form']//tr[not(td[6]='0')][td[5]]/td[5]/a)[" + i + "]";
                driver.FindElement(By.XPath(countryLocator)).Click();

                List<string> subCountries = new List<string>();
                var cells = driver.FindElements(By.XPath("//*[@id='table-zones']//tr/td[3]"));
                foreach (var element in cells)
                {
                    string subNameOfCountry = element.GetAttribute("textContent");

                    countries.Add(subNameOfCountry);
                }

                List<string> sortedSubCountries = new List<string>();
                sortedCountries.AddRange(subCountries);
                sortedCountries.Sort();

                Assert.AreEqual(subCountries, sortedSubCountries);

                // Выходим из проверяемой страны
                driver.FindElement(By.XPath("//button[@name='cancel']")).Click();
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
