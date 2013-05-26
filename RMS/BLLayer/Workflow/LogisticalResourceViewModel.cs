
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

        public string building { get; set; }
        public uint floor { get; set; }
        public uint number { get; set; }
        public uint newNumber { get; set; }
        public string description { get; set; }
        public string newDescription { get; set; }
        public string brand { get; set; }
        public string model { get; set; }
        public string serialNumber { get; set; }
        public bool isBroken { get; set; }
        public bool newIsBroken { get; set; }


        public LogisticalResourceViewModel(IEquipment equipmentDAO, IClassRoom classRoomDAO)
            : base("Logistical Resource manager")
        {
            this.equipmentDAO = equipmentDAO;
            this.classRoomDAO = classRoomDAO;
        }

        // CLASS ROOM

        
        public void AddClassRooom()
        {
            ClassRoom classRoom = new ClassRoom(building, floor, number);
            classRoomDAO.Add(classRoom);
        }


        public void UpdateClassRoom()
        {
            ClassRoom classRoom = new ClassRoom(building, floor, number);
            classRoomDAO.Update(classRoom, newNumber, newDescription);
        }

        public void DeleteClassRoom()
        {
           
            classRoomDAO.Delete(building, floor, number);
            
        }


        // EQUIPMENT

        public void AddEquipment()
        {
            Equipment equipment = new Equipment(brand, model, serialNumber, isBroken, description);
            equipmentDAO.Add(equipment);
        }

      
      
        public void setEquipmentClassRoom()

        {
            Equipment equipment = new Equipment(brand, model, serialNumber, isBroken);
            ClassRoom classRoom = new ClassRoom(building, floor, number, description);
            equipmentDAO.SetClassRoom(equipment, classRoom);
        }

       

        public void UpdateEquipment()
        {
            Equipment equipment = new Equipment(brand, model, serialNumber, isBroken);
            equipmentDAO.Update(equipment, newIsBroken, newDescription);
        }


        public void DeleteEquipment()
        {
            Equipment equipment = new Equipment(brand, model, serialNumber, isBroken);
            equipmentDAO.Delete(equipment);
        }
    }
}
