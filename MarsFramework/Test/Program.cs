using MarsFramework.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsFramework
{
    public class Program
    {
        [TestFixture]
        [Category("Sprint1")]
        class Tenant : Global.Base
        {

            //[Test]
            //public void UserAccount()
            //{
            //    // Creates a toggle for the given test, adds all log events under it    
            //    test = extent.StartTest("Search for a Property");

            //    // Create an class and object to call the method
            //    Profile obj = new Profile();
            //    obj.EditProfile();

            //}
            [Test]
            public void ShareSkill()
            {
                // Creates a toggle for the given test, adds all log events under it    
                test = extent.StartTest("Share Skill");

                // Create an class and object to call the method
                ShareSkill obj = new ShareSkill();
                obj.ShareSkillSteps();
            }

            //[Test]
            //public void EditSkillSteps()
            //{
            //    // Creates a toggle for the given test, adds all log events under it    
            //    test = extent.StartTest("Edit Shareskill");

            //    // Create an class and object to call the method
            //    ShareSkill obj = new ShareSkill();
            //    obj.EditSkillSteps();
            //}

            [Test]
            public void ManageListingsEditDetailsTest()
            {
                // Creates a toggle for the given test, adds all log events under it    
                test = extent.StartTest("Edit Listing in Manage Listings");
                // Create an class and object to call the method
                ManageListings obj = new ManageListings();
                obj.ManageListingsEditListingSteps();

            }

            [Test]
            public void ManageListingsDeleteTest()
            {
                // Creates a toggle for the given test, adds all log events under it    
                test = extent.StartTest("Delete Listing in Manage Listings");
                // Create an class and object to call the method
                ManageListings obj = new ManageListings();
                obj.ManageListingsDeleteListingSteps();

            }

            [Test]
            public void ManageListingsViewDetailsTest()
            {
                // Creates a toggle for the given test, adds all log events under it    
                test = extent.StartTest("View Listing in Manage Listings");
                // Create an class and object to call the method
                ManageListings obj = new ManageListings();
                obj.ManageListingsViewDetailsSteps();

            }
        }
    }
}