using ResourceManagementSystem.BusinessLogic.Entities;
using ResourceManagementSystem.DAOInterface;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using ResourceManagementSystem.BusinessLogic.Entities.Collections;

namespace ResourceManagementSystem.BusinessLogic.Workflow
{
    public class SelectEquipmentsViewModel
    {
        public SelectEquipmentsViewModel(IAllEquipments allEquipments)
        {
            if (allEquipments != null)
            {
                this.allEquipments = allEquipments;
                Equipments = null;
            }
            else
                throw new ArgumentNullException("The provided value for allEquipments cannot be null!");
        }

        public ICollection<Equipment> Equipments { get; private set; }

        public IEnumerable<string> SelectedSerialNumbers { get; set; }

        public IEnumerable<Equipment> TryGetAll(out string errorMessage)
        {
            try
            {
                errorMessage = null;
                localAllEquipments = allEquipments.AsEnumerable;
                return localAllEquipments;
            }
            catch (Exception exception)
            {
                errorMessage = exception.ToString();
                return null;
            }
        }

        private IAllEquipments allEquipments;
        private IEnumerable<Equipment> localAllEquipments;

        public void AddEquipments()
        {
            Equipments = new LinkedList<Equipment>();
            foreach (Equipment eqs in (localAllEquipments.Where((localEquipment) => SelectedSerialNumbers.Contains(localEquipment.SerialNumber))))
                Equipments.Add(eqs);
        }
    }
}
