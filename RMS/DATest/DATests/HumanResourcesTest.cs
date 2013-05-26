using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DALayer.DBImpl;
using ResourceManagementSystem.BusinessLogic.Entities;

namespace DATest.DATests
{
    [TestClass]
    public class HumanResourcesTest
    {
        
        public void TestAdd()
        {
            HumanResources h = new HumanResources();
            Member m = new Member(new Role("role", new Feature[]{null, null}), "Andrei", "Pasalau", "andrei.pasalau@test.com", "abcd1234");
            h.addMember(m);
        }

        public void TestUpdate()
        {
            HumanResources h = new HumanResources();
            Member m = new Member(new Role("role", new Feature[] { null, null }), "Marius", "Pasalau", "andrei.pasalau@test.com", "abcd1234");
            h.updateMember("andrei.pasalau@test.com", m);
        }

        [TestMethod]
        public void TestDelete()
        {
            HumanResources h = new HumanResources();
            Member m = new Member(new Role("role", new Feature[] { null, null }), "Marius", "Pasalau", "andrei.pasalau@test.com", "abcd1234");
            h.deleteMember(m.EMail);
        }
    }
}
