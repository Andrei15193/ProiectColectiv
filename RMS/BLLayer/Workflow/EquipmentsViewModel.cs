using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using ResourceManagementSystem.BusinessLogic.Entities;
using ResourceManagementSystem.DAOInterface;

namespace ResourceManagementSystem.BusinessLogic.Workflow
{
    public class EquipmentsViewModel
    {
        public EquipmentsViewModel(IAllEquipments allEquipments)
        {
            if (allEquipments != null)
            {
                this.allEquipments = allEquipments;
            
            }
            else
                throw new ArgumentNullException("The provided value for allEquipments cannot be null!");
        }

        public String Brand { get; set; }


        public String Model { get; set; }


        public String SerialNumber { get; set; }


        public String Description { get; set; }
 


        public bool TryAddEquipment(out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                allEquipments.Add(new Equipment(Brand, Model, SerialNumber, Description));
                return true;

            }
            catch (Exception exception)
            {
                errorMessage = exception.ToString();
                return false;
            }
        }

        public IEnumerable<Equipment> TryGetAll(out string errorMessage)
        {
            try
            {
                errorMessage = null;
                return allEquipments.AsEnumerable;
            }
            catch (Exception exception)
            {
                errorMessage = exception.ToString();
                return null;
            }
        }

        private IAllEquipments allEquipments;
        


    }
}
