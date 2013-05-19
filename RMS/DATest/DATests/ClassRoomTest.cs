using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using DALayer.DBImpl;
using ResourceManagementSystem.BusinessLogic.Entities;

namespace DATest.DATests
{
    [TestClass]
    public class ClassRoomTest
    {
        [TestMethod]
        public void AddTest()
        {
            ClassRooms rc = new ClassRooms();
            ClassRoom c = new ClassRoom("Cladire Centrala", 2, 6, "Sala de curs");
            rc.Add(c);
            ISet<ClassRoom> cs = rc.getAll();
            bool b = false;
            foreach (ClassRoom room in cs)
            {
                if (room.Number == c.Number && room.Floor == c.Floor && room.Description == c.Description)
                {
                    b = true;
                }
            }
            Assert.IsTrue(b);
        }

        [TestMethod]
        public void UpdateTest()
        {
            ClassRooms rc = new ClassRooms();
            ClassRoom c = new ClassRoom("Cladire Centrala", 2, 6, "Sala de curs si seminar");
            rc.Update(c.Building, c.Floor, c.Number, c);
            ISet<ClassRoom> cs = rc.getAll();
            bool b = false;
            foreach (ClassRoom room in cs)
            {
                if (room.Number == c.Number && room.Floor == c.Floor && room.Description == c.Description)
                {
                    b = true;
                }
            }
            Assert.IsTrue(b);
        }

        [TestMethod]
        public void DeleteTest()
        {
            ClassRooms rc = new ClassRooms();
            ClassRoom c = new ClassRoom("Sediul central UBB", 1, 2, "Sala de curs si seminar");
            rc.Delete(c.Building, c.Floor, c.Number);
            ISet<ClassRoom> cs = rc.getAll();
            bool b = true;
            foreach (ClassRoom room in cs)
            {
                if (room.Number == c.Number && room.Floor == c.Floor && room.Description == c.Description)
                {
                    b = false;
                }
            }
            Assert.IsTrue(b);
        }

        [TestMethod]
        public void GetByPKTest()
        {
            ClassRooms rc = new ClassRooms();
            ClassRoom room = rc.getByPK("Sediul central UBB", 1, 2);

            Assert.IsNotNull(room);
        }
    }
}
