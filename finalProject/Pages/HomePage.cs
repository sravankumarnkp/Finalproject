using System;
using System.Collections.Generic;
using System.Text;
using finalProject.Utilities;
using OpenQA.Selenium;

namespace finalProject.Pages
{
    class HomePage
    {
        public void gotoHomePage(IWebDriver driver)
        {
            //select the Adminstration tab and clck
            IWebElement adminstration = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
            adminstration.Click();
            Wait.WaitForElementToBeClickable(driver, "XPath", "/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a", 3);

            //select the  ""Time and meterial drop downlist
            IWebElement timeAndMetDropbox = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
            timeAndMetDropbox.Click();

        }
    }
}
