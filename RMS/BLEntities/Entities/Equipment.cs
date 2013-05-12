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

        public Equipment(string brand, string model, string serialNumber, bool isBroken, string description, ITask task)
            : base(BuildEquipmentName(brand, model), description, task)
        {
            if (serialNumber != null)
            {
                Brand = brand;
                Model = model;
                SerialNumber = serialNumber;
                IsBroken = isBroken;
                classRoom = null;
                if (Task != null)
                    Task.Equipments.Add(this);
            }
            else
                throw new ArgumentNullException("The provided value for serial number cannot be null!");
        }

        public Equipment(string brand, string model, string serialNumber, bool isBroken)
            : this(brand, model, serialNumber, isBroken, string.Empty, null as ClassRoom)
        {
        }

        public Equipment(string brand, string model, string serialNumber, bool isBroken, string description)
            : this(brand, model, serialNumber, isBroken, description, null as ClassRoom)
        {
        }

        public Equipment(string brand, string model, string serialNumber, bool isBroken, ClassRoom classRoom)
            : this(brand, model, serialNumber, isBroken, string.Empty, classRoom)
        {
        }

        public Equipment(string brand, string model, string serialNumber, bool isBroken, ITask task)
            : this(brand, model, serialNumber, isBroken, string.Empty, task)
        {
        }

        public string Brand { get; private set; }

        public string Model { get; private set; }

        public string SerialNumber { get; private set; }

        public uint TimesUsed { get; private set; }

        public bool IsBroken { get; set; }

        public override ITask Task
        {
            get
            {
               return base.Task;
            }
            set
            {
                if (value == null || ClassRoom == null)
                {
                    base.Task = value;
                    if (value == null && base.Task != null)
                        TimesUsed--;
                    else if (value != null && base.Task == null)
                        TimesUsed++;
                }
                else
                    throw new ArgumentException("The equipment is already placed in a class room!");
            }
        }

        public ClassRoom ClassRoom
        {
            get
            {
                return classRoom;
            }
            set
            {
                if (value == null || Task == null)
                {
                    classRoom = value;
                    if (value == null && classRoom != null)
                        TimesUsed--;
                    else if (value != null && classRoom == null)
                        TimesUsed++;
                }
                else
                    throw new ArgumentException("The equipment is already being used for a task!");
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
