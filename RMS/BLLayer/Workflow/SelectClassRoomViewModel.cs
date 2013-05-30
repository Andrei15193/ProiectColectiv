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
    public class SelectClassRoomViewModel
    {
        public SelectClassRoomViewModel(IAllClassRooms allClassRooms)
        {
            if (allClassRooms != null)
            {
                this.allClassRooms = allClassRooms;
                ClassRooms = null;
            }
            else
                throw new ArgumentNullException("The provided value for allClassRooms cannot be null!");
        }

        public ICollection<ClassRoom> ClassRooms { get; private set; }

        public IEnumerable<string> SelectedNames { get; set; }

        public IEnumerable<ClassRoom> TryGetAll(out string errorMessage)
        {
            try
            {
                errorMessage = null;
                localAllClassRooms = allClassRooms.AsEnumerable;
                return localAllClassRooms;
            }
            catch (Exception exception)
            {
                errorMessage = exception.ToString();
                return null;
            }
        }

        private IAllClassRooms allClassRooms;
        private IEnumerable<ClassRoom> localAllClassRooms;

        public void AddClassRooms()
        {
            ClassRooms = new LinkedList<ClassRoom>();
            foreach (ClassRoom cls in (localAllClassRooms.Where((localClassRoom) => SelectedNames.Contains(localClassRoom.Name))))
                ClassRooms.Add(cls);
        }
    }
}
