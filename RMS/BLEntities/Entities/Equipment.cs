using System;

namespace ResourceManagementSystem.BusinessLogic.Entities
{
    public class Equipment : LogisticalResource
    {
        public Equipment(string brand, string model, string serialNumber, string description)
            : base(description)
        {
            if (brand != null)
                if (model != null)
                    if (serialNumber != null)
                        if (brand.Length > 2)
                            if (model.Length > 2)
                                if (serialNumber.Length > 2)
                                {
                                    Brand = brand;
                                    Model = model;
                                    SerialNumber = serialNumber;
                                }
                                else
                                    throw new ArgumentException("The provided serial number must be at least 3 characters long!");
                            else
                                throw new ArgumentException("The provided model name must be at least 3 characters long!");
                        else
                            throw new ArgumentException("The provided brand name must be at least 3 characters long!");
                    else
                        throw new ArgumentNullException("The provided value for serial number cannot be null!");
                else
                    throw new ArgumentNullException("The provided value for model name cannot be null!");
            else
                throw new ArgumentNullException("The provided value for brand name cannot be null!");
        }

        public Equipment(string brand, string model, string serialNumber)
            : this(brand, model, serialNumber, string.Empty)
        {
        }

        public string Brand { get; private set; }

        public string Model { get; private set; }

        public string SerialNumber { get; private set; }
    }
}
