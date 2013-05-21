using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALayer.DBImpl;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BL = ResourceManagementSystem.BusinessLogic.Entities;

namespace DATest.DATests
{
    [TestClass]
    public class TasksTest
    {
        [TestMethod]
        public void GetTaskIdByTaskTest()
        {
            BL.Role role = new BL.Role("Admin", new BL.Feature[1] { new BL.Feature("useless feature")});
            BL.Member member = new BL.Member(role, "George", "Popa", "asdas@abc.com", "sadasda");
            BL.Course course = new BL.Course("Informatica", 6, BL.Language.Romanian, BL.ApplicationDomain.ComputerScience);
            BL.ClassRoom classRoom = new BL.ClassRoom("Sediul central", 1, 2);
            BL.FinancialResource financialResource = new BL.FinancialResource(23, BL.Currency.RON);
            BL.DidacticTask didacticTask = new BL.DidacticTask(course, "descr", new DateTime(2013, 05, 21), 2, BL.ClassType.Course, 
                                                               classRoom, financialResource, member, 
                                                               new BL.GroupFormation(BL.Specialization.ComputerScience, 2, 221));

            //This is not good. Doing a declaration like that just to test a minor thing.

            Tasks tasks = new Tasks();
            int? id = tasks.GetTaksIdByTask(didacticTask);
            Assert.IsTrue(id.HasValue);
            Assert.AreEqual(id.Value, 1);
        }
    }
}
