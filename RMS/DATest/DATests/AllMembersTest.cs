using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DALayer.DBImpl;
using ResourceManagementSystem.BusinessLogic.Entities;
using ResourceManagementSystem.DataAccess.DAOInterface;

namespace DATest.DATests
{
    [TestClass]
    public class AllMembersTest
    {
        [TestMethod]
        public void TestWhere()
        {
            String email = "gheorghe_admin@test.com";
            String password = "123456";
            IAllMembers members = new AllMembers();
            Member m = members.Where(email, password);
            Assert.AreEqual(m.EMail, email);
            Assert.AreEqual(m.FirstName, "Gheorghe");
            Assert.AreEqual(m.LastName, "Pop");
        }
    }
}
