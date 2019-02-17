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
    public class Zadanie9_2_test
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
        public void Zadanie9_2()
        {
            driver.Url = "http://localhost/litecart/admin/?app=geo_zones&doc=geo_zones";
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("admin");
            driver.FindElement(By.Name("login")).Click();

            
           int editGeoZones = driver.FindElements(By.XPath("//form[@name='geo_zones_form']//td[3]/a")).Count;
           for (int i = 1; i <= editGeoZones; i++)
            {
                string newCountryLocator = "(//form[@name='geo_zones_form']//td[3]/a)[" + i + "]";
                driver.FindElement(By.XPath(newCountryLocator)).Click();

                List<string> geoZones = new List<string>();
                var cells = driver.FindElements(By.XPath("//form[@name='form_geo_zone']//td[3]//option[@selected='selected']"));
                foreach (var element in cells)
                {
                    string zone = element.GetAttribute("innerText");

                    geoZones.Add(zone);
                }

                List<string> sortedZones = new List<string>();
                sortedZones.AddRange(geoZones);
                sortedZones.Sort();
                Assert.AreEqual(geoZones, sortedZones);

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
