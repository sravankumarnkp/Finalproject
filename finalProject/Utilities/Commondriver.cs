using System;
using System.Collections.Generic;
using System.Text;
using finalProject.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace finalProject.Utilities
{
  public   class Commondriver
    {
        public IWebDriver driver;

        [OneTimeSetUp]
        public void LoginActions()
        {
            // open chrome browser
            driver = new ChromeDriver();

            // Login page object initialization and definition
            LoginPage loginPageObj = new LoginPage();
            loginPageObj.gotoLoginPage(driver);
            HomePage homePageObj = new HomePage();
            homePageObj.gotoHomePage(driver);

        }

        [OneTimeTearDown]
        public void CloseTestRun()
        {
            driver.Quit();
        }
    }
}
