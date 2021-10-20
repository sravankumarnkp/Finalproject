using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;

namespace finalProject.Pages
{
    public class TMPage
    {
		//creating Time and metrial page functionalities 
		public void createTM(IWebDriver driver)
		{
			//Finding the creat button and click on create new  button
			IWebElement createButton = driver.FindElement(By.XPath("//*[@id='container']/p/a"));
			createButton.Click();
			//checking where the page request went and location of the currnet url
			Console.WriteLine("currnet url after clicking the creat button",driver.Url);
			Thread.Sleep(2000);
			//select the time from type code droplist
			IWebElement typecodedropdown = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span/span[2]/span"));
			typecodedropdown.Click();
			Thread.Sleep(5000);
			//select the time select to T
			IWebElement timeselect = driver.FindElement(By.XPath("//*[@id='TypeCode_listbox']/li[2]"));
			timeselect.Click();


			//identify "code" textbox and sending the code or inputing the  code using sendkeysmethod
			IWebElement codeTBX = driver.FindElement(By.Id("Code"));
			codeTBX.SendKeys("sep2021");

			// identify the "descrtion" textbox and input description
			IWebElement desTextbox = driver.FindElement(By.Id("Description"));
			desTextbox.SendKeys("sept2021");

			//identify the "price" textbox and input the price
			//we have two class for the price textbox so we need to go to first field and click on that then,
			//we need idenitify the Price texbox and send the keys 
			driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]")).Click();
			IWebElement priceText = driver.FindElement(By.Id("Price"));
			priceText.SendKeys("25");

			//click on save button
			IWebElement saveBttn = driver.FindElement(By.Id("SaveButton"));
			saveBttn.Click();
			//check time and meterial cereated 
			Thread.Sleep(5000);
			

		}

		// creating getter and setter for the class TMPage
		public string getCode(IWebDriver driver)
		{
			IWebElement chckelement = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
			return chckelement.Text;

		}
		public string getTypecode(IWebDriver driver)
		{
			IWebElement chckTypecode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[2]"));
			return chckTypecode.Text;

		}
		public string getDesc(IWebDriver driver)
		{
			IWebElement chckDesc = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[3]"));
			return chckDesc.Text;

		}
		public string getPrice(IWebDriver driver)
		{
			IWebElement chckPrice = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[4]"));
			return chckPrice.Text;

		}
		public void setLastPage(IWebDriver driver)
        {
			//Navigating to the last page of Time and metrial page

			IWebElement lastpagebutton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
			lastpagebutton.Click();

		}

		//creating the edit method or updated method 
		public void editTM(IWebDriver driver, string p0, string typeCode, string nPrice)
		{
			Thread.Sleep(2000);
			//Navigating to the last page of Time and metrial page
			setLastPage(driver);
			//click on the last page button
			//checking the last name of the time and metrial page first data 
			IWebElement chckcode1 = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
			//comparing if the code is just created code

			if (chckcode1.Text == "sep2021")
			{
				//then we need to edit that code 
				IWebElement editbutton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
				editbutton.Click();
				// Click on "TypeCode" from dropdown list and set the Type Code
				IWebElement typeCodeDropdown1 = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span/span[2]/span"));
				typeCodeDropdown1.Click();
				Thread.Sleep(2000);

				if (typeCode == "M")
				{
					IWebElement selectMaterial = driver.FindElement(By.XPath("//*[@id='TypeCode_listbox']/li[1]"));
					selectMaterial.Click();
					Thread.Sleep(2000);
				}
				else
				{
					IWebElement selectTime = driver.FindElement(By.XPath("//*[@id='TypeCode_listbox']/li[2]"));
					selectTime.Click();
					Thread.Sleep(2000);
				}

				//edit description first we need to go to that location and clear and value then send the new value

				IWebElement nDs = driver.FindElement(By.Id("Description"));
				nDs.Clear();
				nDs.SendKeys(p0);

				//edit price first we need to go to first class and after that we need go to price text  location and clear
				//the value then send the new value
				driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]")).Click();
				IWebElement nPs = driver.FindElement(By.XPath("//*[@id='Price']"));
				nPs.Clear();
				Console.WriteLine(nPrice);
				nPs.SendKeys("54");
				//driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]")).Click();
				

				//saveing the updated data 
				driver.FindElement(By.Id("SaveButton")).Click();
				Console.WriteLine("data updated  sucessfully test passed");

				Thread.Sleep(2000);
				// and go to last page of the time and material page
				IWebElement lastpagebutton1 = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
				lastpagebutton1.Click();
				//do assertion for nuinit test here
			}

			else
			{
				Assert.Fail("cannot find edited data, delete test case failed");

			}

		}
		public string GetDescription(IWebDriver driver)
			{
				IWebElement newDescription = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[3]"));
				return newDescription.Text;
			}

		public void deleteTM(IWebDriver driver)
		{
			//delete the data what is saved 


			Console.WriteLine("data deleted stated test ");


			Thread.Sleep(2000);
			//delete
			driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span")).Click();
			IWebElement chckcode1 = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
			if (chckcode1.Text == "sep2021")
			{
				IWebElement deletebutton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
				Thread.Sleep(2000);
				//*[@id="tmsGrid"]/div[3]/table/tbody/tr/td[5]/a[2]
				deletebutton.Click();
				driver.SwitchTo().Alert().Accept();
				Console.WriteLine("data deleted sucessfully ..... ");

				Thread.Sleep(2000);
				IWebElement lastpagebutton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
				lastpagebutton.Click();
				Thread.Sleep(2000);
				//do assertion for nuinit test here
			}
			else
			{
				Assert.Fail("cannot find edited data, delete test case failed");
			}

		}


	}

	}

