using ResourceManagementSystem.BusinessLogic.Entities;
using ResourceManagementSystem.DAOInterface;
using System;
using System.Collections.Generic;

namespace ResourceManagementSystem.BusinessLogic.Workflow
{
    public class ClassRoomViewModel
    {
        public ClassRoomViewModel(IAllClassRooms allClassRooms)
        {
            if (allClassRooms != null)
            {
                this.allClassRooms = allClassRooms;
            }
            else
                throw new ArgumentNullException("The provided value for allClassRooms cannot be null!");
        }

        public String Name { get; set; }
        
        public String Description { get; set; }


        public bool TryAddClassRoom(out string errorMessage)
        {
            
            errorMessage = string.Empty;
            try
            {
                ClassRoom classRoom = new ClassRoom(Name, Description);
                allClassRooms.Add(classRoom);
                return true;
                
            }
            catch (Exception exception)
            {
                errorMessage = exception.ToString();
                return false;
            }
        }



        public IEnumerable<ClassRoom> TryGetAll(out string error)
        {
            try
            {
                error = null;
                return allClassRooms.AsEnumerable;
            }
            catch (DataAccessException exception)
            {
                error = exception.Message;
                return null;
            }
        }

       
        private IAllClassRooms allClassRooms;
    }
}
