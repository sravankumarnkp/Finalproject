using System;
using System.Collections.Generic;
using System.Text;
using finalProject.Pages;
using finalProject.Utilities;
using NUnit.Framework;

namespace finalProject.Tests
{
    class TM_Tests : Commondriver
    {



        [Test, Order(1001), Description("Check if user is able to create Material record")]
        public void createTMTest()
        {
            //tm page
            TMPage tmobj = new TMPage();
            tmobj.createTM(driver);

        }
        [Test, Order(1002), Description("Check if user is able to edit  Material record")]
        public void editTMTest()
        {
            //tm page
            TMPage tmobj = new TMPage();
            tmobj.editTM(driver,"dummy edit","M","39");
            

        }

        [Test, Order(1003), Description("Check if user is able to delete Material record")]
        public void deleteTMTest()
        {
            //tm page
            TMPage tmobj = new TMPage();
            tmobj.deleteTM(driver);

        }

    }


}
