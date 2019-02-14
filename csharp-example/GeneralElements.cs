using OpenQA.Selenium;

namespace QAFramework.Elements
{
    public class GeneralElements 
    {
        private IWebDriver driver;

        public GeneralElements(IWebDriver driver)
        {
        }

        /// <summary>
        /// Проверяет отображение элемента
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="locator"></param>
        /// <returns></returns>
        public bool IsElementPresent(IWebDriver driver, By locator)
        {
            try
            {
                driver.FindElement(locator);
                return true;
            }
            catch (NoSuchElementException ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Проверяет отображение элементов
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="locator"></param>
        /// <returns></returns>
        public bool AreElementsPresent(IWebDriver driver, By locator)
        {
            return driver.FindElements(locator).Count > 0;
        }
    }
}
