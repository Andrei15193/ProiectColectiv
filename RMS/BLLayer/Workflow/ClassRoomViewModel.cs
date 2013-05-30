//using ResourceManagementSystem.BusinessLogic.Entities;
//using ResourceManagementSystem.DAOInterface;
//using System;
//using System.Collections.Generic;

//namespace ResourceManagementSystem.BusinessLogic.Workflow
//{
//    public class ClassRoomViewModel
//    {
//        public IEnumerable<ClassRoom> TryGetAll(out string error)
//        {
//            try
//            {
//                error = null;
//                return allClassRooms.AsEnumerable;
//            }
//            catch (DataAccessException exception)
//            {
//                error = exception.Message;
//                return null;
//            }
//        }

//        public string Name { get; set; }

//        public string Description { get; set; }

//        private IAllClassRooms allClassRooms;
//    }
//}
