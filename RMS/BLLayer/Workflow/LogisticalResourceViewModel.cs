
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResourceManagementSystem.DataAccess.DAOInterface;
using ResourceManagementSystem.BusinessLogic.Entities;

namespace ResourceManagementSystem.BusinessLogic.Workflow
{
    public class LogisticalResourceViewModel : Feature
    {
        IEquipment equipmentDAO;
        IClassRoom classRoomDAO;

        public LogisticalResourceViewModel(IEquipment equipmentDAO, IClassRoom classRoomDAO)
            : base("Logistical Resource manager")
        {
            this.equipmentDAO = equipmentDAO;
            this.classRoomDAO = classRoomDAO;
        }

        public void AddClassRoom(string building, uint floor, uint number, string description)
        {
            ClassRoom classRoom = new ClassRoom(building, floor, number, description);
            classRoomDAO.Add(classRoom);
        }

  

        public void AddClassRoom(string building, uint floor, uint number)
        {
            AddClassRoom(building, floor, number, String.Empty);
        }

        

        public void UpdateClassRoom(string building, uint floor, uint number, string newDescription)
        {
            ClassRoom classRoom = new ClassRoom(building, floor, number, newDescription);
            classRoomDAO.Update(building, floor, number, classRoom);
        }

       

        public void UpdateClassRoom(string building, uint floor, uint number)
        {
            UpdateClassRoom(building, floor, number, String.Empty);
        }

     


        // EQUIPMENT

        public void AddEquipment(string brand, string model, string serialNumber, bool isBroken, string description, ClassRoom classRoom)
        {
            Equipment equipment = new Equipment(brand, model, serialNumber, isBroken, description, classRoom);
            equipmentDAO.Add(equipment);
        }

        public void AddEquipment(string brand, string model, string serialNumber, bool isBroken, string description)
        {
            Equipment equipment = new Equipment(brand, model, serialNumber, isBroken, description);
            equipmentDAO.Add(equipment);
        }

        public void AddEquipment(string brand, string model, string serialNumber, bool isBroken)
        {
            AddEquipment(brand, model, serialNumber, isBroken, String.Empty, (ClassRoom)null);
        }

       

        public void AddEquipment(string brand, string model, string serialNumber, bool isBroken, ClassRoom classRoom)
        {
            AddEquipment(brand, model, serialNumber, isBroken, String.Empty, classRoom);
        }

       

        public void UpdateEquipment(string brand, string model, string serialNumber, bool isBroken, string description, ClassRoom classRoom)
        {
            Equipment equipment = new Equipment(brand, model, serialNumber, isBroken, description, classRoom);
            equipmentDAO.Update(serialNumber, equipment);
        }

        public void UpdateEquipment(string brand, string model, string serialNumber, bool isBroken, string description)
        {
            Equipment equipment = new Equipment(brand, model, serialNumber, isBroken, description);
            equipmentDAO.Update(serialNumber, equipment);
        }

        public void UpdateEquipment(string brand, string model, string serialNumber, bool isBroken)
        {
            UpdateEquipment(brand, model, serialNumber, isBroken, String.Empty, (ClassRoom)null);
        }

       

        public void UpdateEquipment(string brand, string model, string serialNumber, bool isBroken, ClassRoom classRoom)
        {
            UpdateEquipment(brand, model, serialNumber, isBroken, String.Empty, classRoom);
        }

       

        public void DeleteEquipment(string serialNumber)
        {
            equipmentDAO.Delete(serialNumber);
        }
    }
}
