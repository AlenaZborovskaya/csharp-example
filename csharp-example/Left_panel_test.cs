using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace csharp_example
{
    [TestFixture]
    public class Left_panel_test
    {
        private IWebDriver driver;
        private WebDriverWait wait;


        [SetUp]
        public void start()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [Test]
        public void FirstTest()
        {
            driver.Url = "http://localhost/litecart/admin/login.php?redirect_url=%2Flitecart%2Fadmin%2F";
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("admin");
            driver.FindElement(By.Name("login")).Click();
            wait.Until(ExpectedConditions.TitleIs("My Store"));

            // Прокликиваем все пункты меню слева, включая вложенные пункты
            driver.FindElement(By.XPath("//*[@id='box-apps-menu-wrapper']//*[contains(text(),'Appearence')]")).Click();
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//h1[contains(text(),' Template')]")));
            // Catalog group
            driver.FindElement(By.XPath("//*[@id='doc-template']//*[contains(text(),'Template')]")).Click();
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//h1[contains(text(),' Template')]")));
            driver.FindElement(By.XPath("//*[@id='doc-logotype']//*[contains(text(),'Logotype')]")).Click();
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//h1[contains(text(),' Logotype')]")));
            driver.FindElement(By.XPath("//*[@id='app-']//*[@class='name'][contains(text(),'Catalog')]")).Click();
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//h1[contains(text(),' Catalog')]")));
            driver.FindElement(By.XPath("//*[@id='doc-catalog']")).Click();
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//h1[contains(text(),' Catalog')]")));
            driver.FindElement(By.XPath("//*[@id='doc-product_groups']")).Click();
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//h1[contains(text(),' Product Groups')]")));
            driver.FindElement(By.XPath("//*[@id='doc-option_groups']")).Click();
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//h1[contains(text(),' Option Groups')]")));
            driver.FindElement(By.XPath("//*[@id='doc-manufacturers']")).Click();
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//h1[contains(text(),' Manufacturers')]")));
            driver.FindElement(By.XPath("//*[@id='doc-suppliers']")).Click();
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//h1[contains(text(),' Suppliers')]")));
            driver.FindElement(By.XPath("//*[@id='doc-delivery_statuses']")).Click();
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//h1[contains(text(),' Delivery Statuses')]")));
            driver.FindElement(By.XPath("//*[@id='doc-sold_out_statuses']")).Click();
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//h1[contains(text(),' Sold Out Statuses')]")));
            driver.FindElement(By.XPath("//*[@id='doc-quantity_units']")).Click();
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//h1[contains(text(),' Quantity Units')]")));
            driver.FindElement(By.XPath("//*[@id='doc-csv']")).Click();
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//h1[contains(text(),' CSV Import/Export')]")));
            // Countries
            driver.FindElement(By.XPath("//*[@class='name'][contains(text(),'Countries')]")).Click();
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//h1[contains(text(),' Countries')]")));
            // Currencies
            driver.FindElement(By.XPath("//*[@class='name'][contains(text(),'Currencies')]")).Click();
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//h1[contains(text(),' Currencies')]")));
            // Customers
            driver.FindElement(By.XPath("//*[@class='name'][contains(text(),'Customers')]")).Click();
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//h1[contains(text(),' Customers')]")));
            driver.FindElement(By.XPath("//*[@id='doc-customers']")).Click();
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//h1[contains(text(),' Customers')]")));
            driver.FindElement(By.XPath("//*[@id='doc-csv']")).Click();
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//h1[contains(text(),' CSV Import/Export')]")));
            driver.FindElement(By.XPath("//*[@id='doc-newsletter']")).Click();
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//h1[contains(text(),' Newsletter')]")));
            // Geo Zones
            driver.FindElement(By.XPath("//*[@class='name'][contains(text(),'Geo Zones')]")).Click();
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//h1[contains(text(),' Geo Zones')]")));
            // Languages
            driver.FindElement(By.XPath("//*[@class='name'][contains(text(),'Languages')]")).Click();
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//h1[contains(text(),' Languages')]")));
            driver.FindElement(By.XPath("//*[@id='doc-languages']")).Click();
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//h1[contains(text(),' Languages')]")));
            driver.FindElement(By.XPath("//*[@id='doc-storage_encoding']")).Click();
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//h1[contains(text(),' Storage Encoding')]")));
            // Modules
            driver.FindElement(By.XPath("//*[@class='name'][contains(text(),'Modules')]")).Click();
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//h1[contains(text(),' Job Modules')]")));
            driver.FindElement(By.XPath("//*[@id='doc-jobs']")).Click();
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//h1[contains(text(),' Job Modules')]")));
            driver.FindElement(By.XPath("//*[@id='doc-customer']")).Click();
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//h1[contains(text(),' Customer Modules')]")));
            driver.FindElement(By.XPath("//*[@id='doc-shipping']")).Click();
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//h1[contains(text(),' Shipping Modules')]")));
            driver.FindElement(By.XPath("//*[@id='doc-payment']")).Click();
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//h1[contains(text(),' Payment Modules')]")));
            driver.FindElement(By.XPath("//*[@id='doc-order_total']")).Click();
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//h1[contains(text(),' Order Total Modules')]")));
            driver.FindElement(By.XPath("//*[@id='doc-order_success']")).Click();
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//h1[contains(text(),' Order Success Modules')]")));
            driver.FindElement(By.XPath("//*[@id='doc-order_action']")).Click();
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//h1[contains(text(),' Order Action Modules')]")));
            // Orders
            driver.FindElement(By.XPath("//*[@class='name'][contains(text(),'Orders')]")).Click();
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//h1[contains(text(),' Orders')]")));
            driver.FindElement(By.XPath("//*[@id='doc-orders']")).Click();
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//h1[contains(text(),' Orders')]")));
            driver.FindElement(By.XPath("//*[@id='doc-order_statuses']")).Click();
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//h1[contains(text(),' Order Statuses')]")));
            // Pages
            driver.FindElement(By.XPath("//*[@class='name'][contains(text(),'Pages')]")).Click();
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//h1[contains(text(),' Pages')]")));
            // Reports
            driver.FindElement(By.XPath("//*[@class='name'][contains(text(),'Reports')]")).Click();
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//h1[contains(text(),' Monthly Sales')]")));
            driver.FindElement(By.XPath("//*[@id='doc-monthly_sales']")).Click();
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//h1[contains(text(),' Monthly Sales')]")));
            driver.FindElement(By.XPath("//*[@id='doc-most_sold_products']")).Click();
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//h1[contains(text(),' Most Sold Products')]")));
            driver.FindElement(By.XPath("//*[@id='doc-most_shopping_customers']")).Click();
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//h1[contains(text(),' Most Shopping Customers')]")));
            // Settings
            driver.FindElement(By.XPath("//*[@class='name'][contains(text(),'Settings')]")).Click();
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//h1[contains(text(),' Settings')]")));
            driver.FindElement(By.XPath("//*[@id='doc-store_info']")).Click();
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//h1[contains(text(),' Settings')]")));
            driver.FindElement(By.XPath("//*[@id='doc-general']")).Click();
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//h1[contains(text(),' Settings')]")));
            driver.FindElement(By.XPath("//*[@id='doc-listings']")).Click();
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//h1[contains(text(),' Settings')]")));
            driver.FindElement(By.XPath("//*[@id='doc-images']")).Click();
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//h1[contains(text(),' Settings')]")));
            driver.FindElement(By.XPath("//*[@id='doc-checkout']")).Click();
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//h1[contains(text(),' Settings')]")));
            driver.FindElement(By.XPath("//*[@id='doc-advanced']")).Click();
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//h1[contains(text(),' Settings')]")));
            driver.FindElement(By.XPath("//*[@id='doc-security']")).Click();
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//h1[contains(text(),' Settings')]")));
            // Slides
            driver.FindElement(By.XPath("//*[@class='name'][contains(text(),'Slides')]")).Click();
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//h1[contains(text(),' Slides')]")));
            // Tax
            driver.FindElement(By.XPath("//*[@class='name'][contains(text(),'Tax')]")).Click();
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//h1[contains(text(),' Tax Classes')]")));
            driver.FindElement(By.XPath("//*[@id='doc-tax_classes']")).Click();
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//h1[contains(text(),' Tax Classes')]")));
            driver.FindElement(By.XPath("//*[@id='doc-tax_rates']")).Click();
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//h1[contains(text(),' Tax Rates')]")));
            // Translations
            driver.FindElement(By.XPath("//*[@class='name'][contains(text(),'Translations')]")).Click();
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//h1[contains(text(),' Search Translations')]")));
            driver.FindElement(By.XPath("//*[@id='doc-search']")).Click();
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//h1[contains(text(),' Search Translations')]")));
            driver.FindElement(By.XPath("//*[@id='doc-scan']")).Click();
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//h1[contains(text(),' Scan Files For Translations')]")));
            driver.FindElement(By.XPath("//*[@id='doc-csv']")).Click();
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//h1[contains(text(),' CSV Import/Export')]")));
            // Users
            driver.FindElement(By.XPath("//*[@class='name'][contains(text(),'Users')]")).Click();
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//h1[contains(text(),' Users')]")));
            // vQmods
            driver.FindElement(By.XPath("//*[@class='name'][contains(text(),'vQmods')]")).Click();
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//h1[contains(text(),' vQmods')]")));
            driver.FindElement(By.XPath("//*[@id='doc-vqmods']")).Click();
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//h1[contains(text(),' vQmods')]")));
        }

        [OneTimeTearDown]
        public void stop()
        {
            driver.Quit();
            driver = null;
        }
    }
}
