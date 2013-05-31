using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ResourceManagementSystem.DAOInterface;
using ResourceManagementSystem.DataAccess.Database;
using ResourceManagementSystem.BusinessLogic.Entities;

namespace DATest.DATests
{
    [TestClass]
    public class AllMembersTest
    {
        [TestMethod]
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
    }
}
