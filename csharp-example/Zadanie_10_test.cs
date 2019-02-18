using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using QAFramework.Elements;
using OpenQA.Selenium.IE;

namespace csharp_example
{
    [TestFixture]
    public class Zadanie_10_test
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
        public void Zadanie10()
        {
            driver.Url = "http://localhost/litecart/en/";

            // Проверяем, что  на главной странице и на странице товара совпадает текст названия товара
            string title = driver.FindElement(By.XPath("//*[@id='box-campaigns']//li//div[@class='name']")).Text;

            driver.FindElement(By.XPath("//*[@id='box-campaigns']//a")).Click();
            string innerTitle = driver.FindElement(By.XPath("//*[@id='box-product']//h1[@class='title']")).Text;
            Assert.AreEqual(title, innerTitle);

            // Проверяем, что на главной странице товара совпадают цены (обычная и акционная)
            driver.Url = "http://localhost/litecart/en/";

            string regularPrice = driver.FindElement(By.XPath("//*[@id='box-campaigns']//s[@class='regular-price']")).Text;
            string campaignPrice = driver.FindElement(By.XPath("//*[@id='box-campaigns']//strong[@class='campaign-price']")).Text;

            driver.FindElement(By.XPath("//*[@id='box-campaigns']//a")).Click();
            string regularInnerPrice = driver.FindElement(By.XPath("//*[@id='box-product']//s[@class='regular-price']")).Text;
            string campaignInnerPrice = driver.FindElement(By.XPath("//*[@id='box-product']//strong[@class='campaign-price']")).Text;

            Assert.AreEqual(regularPrice, regularInnerPrice);
            Assert.AreEqual(campaignPrice, campaignInnerPrice);

            // Проверяем что, обычная цена зачёркнутая и серая (можно считать, что "серый" цвет это такой, у которого в RGBa представлении одинаковые значения для каналов R, G и B)
            driver.Url = "http://localhost/litecart/en/";

            string colourRegularPrice = driver.FindElement(By.XPath("//*[@id='box-campaigns']//s[@class='regular-price']")).GetCssValue("color");
            string[] regularPriceChanel = colourRegularPrice.Replace("rgba(", "").Replace(")", "").Split(",".ToCharArray());

            int r = Int32.Parse(regularPriceChanel[0].Trim());
            int g = Int32.Parse(regularPriceChanel[1].Trim());
            int b = Int32.Parse(regularPriceChanel[2].Trim());

            string crossLine = driver.FindElement(By.XPath("//*[@id='box-campaigns']//s[@class='regular-price']")).GetCssValue("text-decoration-line");

            if (r == g && g == b && crossLine == "line-through")
            {
                //проверяем, что  цвет акционной цены красный и выделен жирным
                string colourCampaignPrice = driver.FindElement(By.XPath("//*[@id='box-campaigns']//strong[@class='campaign-price']")).GetCssValue("color");
                string[] campaignPriceChanel = colourCampaignPrice.Replace("rgba(", "").Replace(")", "").Split(",".ToCharArray());
                r = Int32.Parse(campaignPriceChanel[0].Trim());
                g = Int32.Parse(campaignPriceChanel[1].Trim());
                b = Int32.Parse(campaignPriceChanel[2].Trim());

                string boldFont = driver.FindElement(By.XPath("//*[@id='box-campaigns']//strong[@class='campaign-price']")).GetCssValue("font-weight");

                if (g == 0 && g == b && boldFont == "700")
                {
                    string regularPriceSize = driver.FindElement(By.XPath("//*[@id='box-campaigns']//s[@class='regular-price']")).GetAttribute("offsetHeight");
                    string campaignPriceSize = driver.FindElement(By.XPath("//*[@id='box-campaigns']//strong[@class='campaign-price']")).GetAttribute("offsetHeight");
                    int a = Convert.ToInt32(regularPriceSize);
                    int d = Convert.ToInt32(campaignPriceSize);
                    if (a > d)
                    {
                        Assert.Fail("Отображение некорректное");
                    }
                }
            }
            else
                Assert.Fail("Отображение некорректное");

            // Проверяем, что на странице товара совпадают цены (обычная и акционная)

            driver.FindElement(By.XPath("//*[@id='box-campaigns']//a")).Click();

            string colourOtherRegularPrice = driver.FindElement(By.XPath("//*[@id='box-product']//s[@class='regular-price']")).GetCssValue("color");
            string[] regularOtherPriceChanel = colourRegularPrice.Replace("rgba(", "").Replace(")", "").Split(",".ToCharArray());

            int j = Int32.Parse(regularPriceChanel[0].Trim());
            int k = Int32.Parse(regularPriceChanel[1].Trim());
            int l = Int32.Parse(regularPriceChanel[2].Trim());

            string crossOtherLine = driver.FindElement(By.XPath("//*[@id='box-product']//s[@class='regular-price']")).GetCssValue("text-decoration-line");

            if (j == k && k == l && crossOtherLine == "line-through")
            {
                //проверяем, что  цвет акционной цены красный и выделен жирным
                string colourCampaignPrice = driver.FindElement(By.XPath("//*[@id='box-product']//strong[@class='campaign-price']")).GetCssValue("color");
                string[] campaignPriceChanel = colourCampaignPrice.Replace("rgba(", "").Replace(")", "").Split(",".ToCharArray());
                r = Int32.Parse(campaignPriceChanel[0].Trim());
                g = Int32.Parse(campaignPriceChanel[1].Trim());
                b = Int32.Parse(campaignPriceChanel[2].Trim());

                string boldFont = driver.FindElement(By.XPath("//*[@id='box-product']//strong[@class='campaign-price']")).GetCssValue("font-weight");

                if (g == 0 && g == b && boldFont == "700")
                {
                    string regularPriceSize = driver.FindElement(By.XPath("//*[@id='box-product']//s[@class='regular-price']")).GetAttribute("offsetHeight");
                    string campaignPriceSize = driver.FindElement(By.XPath("//*[@id='box-product']//strong[@class='campaign-price']")).GetAttribute("offsetHeight");
                    int a = Convert.ToInt32(regularPriceSize);
                    int d = Convert.ToInt32(campaignPriceSize);
                    if (a > d)
                    {
                        Assert.Fail("Отображение некорректное");
                    }
                }
            }
            else
                Assert.Fail("Отображение некорректное");

        }


        [OneTimeTearDown]
        public void stop()
        {
            driver.Quit();
            driver = null;
        }
    }
}
