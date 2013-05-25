using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using DALayer.DBImpl;
using ResourceManagementSystem.BusinessLogic.Entities;

namespace DATest.DATests
{
    [TestClass]
    public class EquipmentsTest
    {
        
        public void AddTest()
        {
            Equipment e = new Equipment("acer", "a6920", "12347890-456", false, new ClassRoom("CCCCC", 2, 1));
            new Equipments().Add(e);
        }

        public void UpdateTest()
        {
            Equipment e = new Equipment("acsaser", "a6sdsd920", "12347890-456", false, new ClassRoom("CCCCC", 2, 1));
            new Equipments().Update(e.SerialNumber, e);
        }

        public void DeleteTest()
        {
            Equipment e = new Equipment("acsaser", "a6sdsd920", "12347890-456", false, new ClassRoom("CCCCC", 2, 1));
            new Equipments().Delete(e.SerialNumber);
        }

        public void GetByPKTest()
        {
            Equipment e = new Equipment("acer", "a6920", "12347890-456", false, new ClassRoom("CCCCC", 2, 1));
            new Equipments().Add(e);
            Equipment e1 =  new Equipments().getByPK(e.SerialNumber);
            Assert.AreEqual(e1.Name, e.Name);
            Assert.AreEqual(e1.Brand, e.Brand);
            Assert.AreEqual(e1.ClassRoom.Name, e.ClassRoom.Name);
        }

        public void GetByClassRoomTest()
        {
            ClassRoom c = new ClassRoom("CCCCC", 2, 1);
            Equipment e = new Equipment("acer", "a6920", "12347890-456", false, c);
            new Equipments().Add(e);
            ISet<Equipment> set = new Equipments().getByClassRoom(c);

        }

        public void GetAllTest()
        {
            ClassRoom c = new ClassRoom("CCCCC", 2, 1);
            Equipment e = new Equipment("acer", "a6920", "123470-456", false, c);
            new Equipments().Add(e);
            ISet<Equipment> set = new Equipments().getByClassRoom(c);
        }
    }
}
