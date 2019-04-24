using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace MarsFramework.Pages
{
    class ManageListings
    {

        public ManageListings()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        //Find Manage Listings button
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[1]/div/a[3]")]
        private IWebElement ManageListingsbutton { get; set; }

        //Find the Eye icon button

        [FindsBy(How = How.XPath, Using = "//*[@id='listing-management-section']/div[2]/div[1]/table/tbody/tr[1]/td[8]/i[contains(@class, 'eye icon')]")]
        private IWebElement EyeIconButton { get; set; }

        //Find Service Detail Page
        [FindsBy(How = How.XPath, Using = "//*[@id='service-detail-section']")]
        private IWebElement ServiceDetailPage { get; set; }

        //Find Delete button
        [FindsBy(How = How.XPath, Using = "//*[@id='listing-management-section']/div[2]/div[1]/table/tbody/tr[1]/td[8]/i[contains(@class, 'remove icon')]")]
        private IWebElement DeleteButton { get; set; }

        //Find Edit button
        [FindsBy(How = How.XPath, Using = "//*[@id='listing-management-section']/div[2]/div[1]/table/tbody/tr[1]/td[8]/i[contains(@class, 'outline write icon')]")]
        private IWebElement EditButton { get; set; }

        //Find Delete confirm button
        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div/div[3]/button[2]")]
        private IWebElement DeleteConfirmButton { get; set; }

        internal void ManageListingsDeleteListingSteps()
        {
            //Click on Manage Listings button
            ManageListingsbutton.Click();
            Thread.Sleep(1500);
            //Populate the Excel sheet
            Global.GlobalDefinitions.ExcelLib.PopulateInCollection(Global.Base.ExcelPath, "ShareSkill");
            int excelRowToRead = 2;
            IWebElement listingTable = Global.GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/table"));
            IList<IWebElement> tableRows = listingTable.FindElements(By.TagName("tr"));

            IWebElement rowToDelete = DeleteButton;
            for (int i = 0; i < tableRows.Count; i++)
            {
                IWebElement row = tableRows[i];
                if (row.Text.Contains(Global.GlobalDefinitions.ExcelLib.ReadData(excelRowToRead, "Title")) && row.Text.Contains(Global.GlobalDefinitions.ExcelLib.ReadData(excelRowToRead, "Description")))
                {
                    rowToDelete = row;
                    break;

                }
            }
            IWebElement DeleteB = rowToDelete.FindElement(By.XPath("//i[contains(@class, 'remove icon')]"));
            //Click on the Delete icon button
            DeleteB.Click();
            //Confirm delete
            DeleteConfirmButton.Click();
            Thread.Sleep(1500);

            //Verify
            IList<IWebElement> tableRowsAfterDelete = listingTable.FindElements(By.TagName("tr"));
            Boolean isListingPresent = false;
            for (int i = 0; i < tableRowsAfterDelete.Count; i++)
            {
                IWebElement row = tableRowsAfterDelete[i];
                if (row.Text.Contains(Global.GlobalDefinitions.ExcelLib.ReadData(excelRowToRead, "Title")) && row.Text.Contains(Global.GlobalDefinitions.ExcelLib.ReadData(excelRowToRead, "Description")))
                {
                    isListingPresent = true;
                    break;

                }
            }
            if (isListingPresent == false)
            {
                Global.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Delete Skill test Successful");
            }
            else
            {
                Global.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Delete Skill test Failed");
            }
        }

        internal void ManageListingsEditListingSteps()
        {
            //Click on Manage Listings button
            ManageListingsbutton.Click();
            Thread.Sleep(1500);

            //Click on Manage Listings edit button
            EditButton.Click();
            Thread.Sleep(1500);
            ShareSkill ShareSkillPage = new ShareSkill();
            ShareSkillPage.EditSkillSteps();
        }


        internal void ManageListingsViewDetailsSteps()
        {
            //Click on Manage Listings button
            ManageListingsbutton.Click();
            Thread.Sleep(1500);
            //Click on the Eye icon button
            EyeIconButton.Click();
            Thread.Sleep(1500);

            //Verify
            if (ServiceDetailPage != null)
            {
                Global.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "View Details Successful");
            }
            else
                Global.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "View Details Unsuccessful");

        }
    }
}