using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ResourceManagementSystem.DAOInterface;
using ResourceManagementSystem.DataAccess.Database;
using ResourceManagementSystem.BusinessLogic.Entities;
using ResourceManagementSystem.BusinessLogic.Entities.Collections;

namespace DATest.DATests
{
    [TestClass]
    public class AllMembersTest
    {
        public void TestWhere()
        {
            String email = "gabis@cs.ubbcluj.ro";
            String password = "123456";
            IAllMembers members = new AllMembers();
            Member m = members.Where(email, password);
            Assert.AreEqual(m.EMail, email);
            Assert.AreEqual(m.Name, "Czibula Gabriela");
            Assert.AreEqual(m.EMail, "gabis@cs.ubbcluj.ro");
        }
        
        public void AddResearchProject()
        {
        }
    }
}
