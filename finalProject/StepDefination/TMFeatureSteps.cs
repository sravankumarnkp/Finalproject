using System;
using finalProject.Pages;
using finalProject.Utilities;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace finalProject.StepDefination 
{
    [Binding]
    public class TMFeatureSteps : Commondriver
    {
        //creating the homepage
        HomePage hp = new HomePage();
        //creating the log in page object 
        LoginPage lPage = new LoginPage();

        //creating Time and matterial page
        TMPage tPage = new TMPage();


        [Given(@"I Logged into turnup portal sucessfully")]
        public void GivenILoggedIntoTurnupPortalSucessfully()
        {
            // open chrome browser
            driver = new ChromeDriver();
            
            //go to login page
            lPage.gotoLoginPage(driver);
        }
        
        [Given(@"I nagivate to Time and material page")]
        public void GivenINagivateToTimeAndMaterialPage()
        {
            //navigate to time and meterial page 
            hp.gotoHomePage(driver);
        }
        
        [When(@"I create time and material record\.")]
        public void WhenICreateTimeAndMaterialRecord_()
        {
            //creating the time and meterial data and click on last page 
            tPage.createTM(driver);
        }
        
        
        //updating data values ... using passing two string 
        [When(@"I update '(.*)' '(.*)' '(.*)' on an existing time and material record\.")]
        public void WhenIUpdateOnAnExistingTimeAndMaterialRecord_(string p0, string p1, string p2)
        {
            //Navigating to the last page of Time and metrial page

            tPage.setLastPage(driver);
            //editing last page
            tPage.editTM(driver, p0, p1, p2);
            Console.WriteLine("test",p2);
        }

        [When(@"I delete the time and marerial record")]
        public void WhenIDeleteTheTimeAndMarerialRecord()
        {
            tPage.deleteTM(driver);
        }
        //checking if the data was created same or not using assertions 
        [Then(@"Thre record should be created sucessfully")]
        public void ThenThreRecordShouldBeCreatedSucessfully()
        {
            //Navigating to the last page of Time and metrial page
            tPage.setLastPage(driver);

            //getting the data from tm page last page and last data  
            string chckelement = tPage.getCode(driver);
            string chckTypecode = tPage.getTypecode(driver); 
            string chckDesc = tPage.getDesc(driver); 
            string chckPrice = tPage.getPrice(driver);

            //perform the assertion weather the getting data and expected data are same 

            Assert.That(chckelement == "sep2021", "Actual code and expected code do not match");
            Assert.That(chckTypecode == "T", "Actual type code and expected code do not match");
            Assert.That(chckDesc == "sept2021", "Actual Desc and expected code do not match");
            Assert.That(chckPrice == "$25.00", "Actual Price and expected code do not match");


        }
        //checking data was updated sucessfully or not 
        [Then(@"the record should have the updated '(.*)'")]
        public void ThenTheRecordShouldHaveTheUpdated(string p0)
        {
            //getting the decrtion
            string chckDesc = tPage.getDesc(driver);

            //perform the assertion weather the getting data and expected data are same 
            Assert.That(chckDesc == p0, "Actual Desc and expected code do not match");

        }
        //checking data was deleted sucessfully
        [Then(@"there record should be deleted sucessfully")]
        public void ThenThereRecordShouldBeDeletedSucessfully()
        {
            //getting the data from tm page last page and last data  
            string chckelement = tPage.getCode(driver);
            string chckTypecode = tPage.getTypecode(driver);
            string chckDesc = tPage.getDesc(driver);
            string chckPrice = tPage.getPrice(driver);

            //perform the assertion weather the getting data and expected data are same 

            Assert.That(chckelement != "sep2021", "Actual code and expected code do not match");
            Assert.That(chckTypecode != "T", "Actual code and expected code do not match");
            Assert.That(chckDesc != "sept2021", "Actual Desc and expected code do not match");
            Assert.That(chckPrice != "$25.00", "Actual Price and expected code do not match");

        }
    }
}
