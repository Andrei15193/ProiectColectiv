using System;

namespace ResourceManagementSystem.BusinessLogic.Entities
{
    public class Equipment : LogisticalResource
    {
        public Equipment(string brand, string model, string serialNumber, bool isBroken, string description, ClassRoom classRoom)
            : base(BuildEquipmentName(brand, model), description)
        {
            if (serialNumber != null)
            {
                Brand = brand;
                Model = model;
                SerialNumber = serialNumber;
                IsBroken = isBroken;
                this.classRoom = classRoom;
                if (classRoom != null)
                    classRoom.Equipments.Add(this);
            }
            else
                throw new ArgumentNullException("The provided value for serial number cannot be null!");
        }

        public Equipment(string brand, string model, string serialNumber, bool isBroken, string description)
            : base(BuildEquipmentName(brand, model), description)
        {
            if (serialNumber != null)
            {
                Brand = brand;
                Model = model;
                SerialNumber = serialNumber;
                IsBroken = isBroken;
                classRoom = null;
               
            }
            else
                throw new ArgumentNullException("The provided value for serial number cannot be null!");
        }

        public Equipment(string brand, string model, string serialNumber, bool isBroken)
            : this(brand, model, serialNumber, isBroken, string.Empty, null as ClassRoom)
        {
        }

        

        public Equipment(string brand, string model, string serialNumber, bool isBroken, ClassRoom classRoom)
            : this(brand, model, serialNumber, isBroken, string.Empty, classRoom)
        {
        }

        

        public string Brand { get; private set; }

        public string Model { get; private set; }

        public string SerialNumber { get; private set; }

        public uint TimesUsed { get; private set; }

        public bool IsBroken { get; set; }

       

        public ClassRoom ClassRoom
        {
            get
            {
                return classRoom;
            }
            set
            {
                    classRoom = value;
                 
            }
        }

        public bool IsAvailable
        {
            get
            {
                return ClassRoom == null;
            }
        }

        private static string BuildEquipmentName(string brand, string model)
        {
            if (brand != null)
                if (model != null)
                    return string.Join(" ", brand, model);
                else
                    throw new ArgumentNullException("The provided value for model cannot be null!");
            else
                throw new ArgumentNullException("The provided value for brand cannot be null!");
        }

        private ClassRoom classRoom;
    }
}
