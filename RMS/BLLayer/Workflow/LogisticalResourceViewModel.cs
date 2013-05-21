
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

        public void AddClassRoom(string building, uint floor, uint number, string description, ITask task)
        {
            ClassRoom classRoom = new ClassRoom(building, floor, number, description, task);
            classRoomDAO.Add(classRoom);
        }

        public void AddClassRoom(string building, uint floor, uint number, string description)
        {
            AddClassRoom(building, floor, number, description, null);
        }

        public void AddClassRoom(string building, uint floor, uint number, ITask task)
        {
            AddClassRoom(building, floor, number, String.Empty, task);
        }

        public void AddClassRoom(string building, uint floor, uint number)
        {
            AddClassRoom(building, floor, number, String.Empty, null);
        }

        public void UpdateClassRoom(string building, uint floor, uint number, string newDescription, ITask newTask)
        {
            ClassRoom classRoom = new ClassRoom(building, floor, number, newDescription, newTask);
            classRoomDAO.Update(building, floor, number, classRoom);
        }

        public void UpdateClassRoom(string building, uint floor, uint number, string newDescription)
        {
            UpdateClassRoom(building, floor, number, newDescription, null);
        }

        public void UpdateClassRoom(string building, uint floor, uint number, ITask newTask)
        {
            UpdateClassRoom(building, floor, number, String.Empty, newTask);
        }

        public void DeleteClassRoom(string building, uint floor, uint number)
        {
            classRoomDAO.Delete(building, floor, number);
        }


        // EQUIPMENT

        public void AddEquipment(string brand, string model, string serialNumber, bool isBroken, string description, ClassRoom classRoom)
        {
            Equipment equipment = new Equipment(brand, model, serialNumber, isBroken, description, classRoom);
            equipmentDAO.Add(equipment);
        }

        public void AddEquipment(string brand, string model, string serialNumber, bool isBroken, string description, ITask task)
        {
            Equipment equipment = new Equipment(brand, model, serialNumber, isBroken, description, task);
            equipmentDAO.Add(equipment);
        }

        public void AddEquipment(string brand, string model, string serialNumber, bool isBroken)
        {
            AddEquipment(brand, model, serialNumber, isBroken, String.Empty, (ClassRoom)null);
        }

        public void AddEquipment(string brand, string model, string serialNumber, bool isBroken, string description)
        {
            AddEquipment(brand, model, serialNumber, isBroken, description, (ClassRoom)null);
        }

        public void AddEquipment(string brand, string model, string serialNumber, bool isBroken, ClassRoom classRoom)
        {
            AddEquipment(brand, model, serialNumber, isBroken, String.Empty, classRoom);
        }

        public void AddEquipment(string brand, string model, string serialNumber, bool isBroken, ITask task)
        {
            AddEquipment(brand, model, serialNumber, isBroken, String.Empty, task);
        }

        public void UpdateEquipment(string brand, string model, string serialNumber, bool isBroken, string description, ClassRoom classRoom)
        {
            Equipment equipment = new Equipment(brand, model, serialNumber, isBroken, description, classRoom);
            equipmentDAO.Update(serialNumber, equipment);
        }

        public void UpdateEquipment(string brand, string model, string serialNumber, bool isBroken, string description, ITask task)
        {
            Equipment equipment = new Equipment(brand, model, serialNumber, isBroken, description, task);
            equipmentDAO.Update(serialNumber, equipment);
        }

        public void UpdateEquipment(string brand, string model, string serialNumber, bool isBroken)
        {
            UpdateEquipment(brand, model, serialNumber, isBroken, String.Empty, (ClassRoom)null);
        }

        public void UpdateEquipment(string brand, string model, string serialNumber, bool isBroken, string description)
        {
            UpdateEquipment(brand, model, serialNumber, isBroken, description, (ClassRoom)null);
        }

        public void UpdateEquipment(string brand, string model, string serialNumber, bool isBroken, ClassRoom classRoom)
        {
            UpdateEquipment(brand, model, serialNumber, isBroken, String.Empty, classRoom);
        }

        public void UpdateEquipment(string brand, string model, string serialNumber, bool isBroken, ITask task)
        {
            UpdateEquipment(brand, model, serialNumber, isBroken, String.Empty, task);
        }

        public void DeleteEquipment(string serialNumber)
        {
            equipmentDAO.Delete(serialNumber);
        }
    }
}
