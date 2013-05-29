//using ResourceManagementSystem.BusinessLogic.Entities;
//using ResourceManagementSystem.DAOInterface;
//using System;
//using System.Collections.Generic;
//using System.Data.SqlClient;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using BLEntities = ResourceManagementSystem.BusinessLogic.Entities;

//namespace DALayer.DBImpl
//{
//    public class ClassRooms : IClassRoom
//    {
//        public ResourceManagementSystem.BusinessLogic.Entities.ClassRoom getByPK(string building, uint floor, uint number)
//        {
//            ClassRoom classRoom = null;

//            bool validValues = false;

//            int classId = 0;
//            string buildingName = building;
//            string classRoomDescription = string.Empty;
//            uint classFloor = floor;
//            uint classNumber = number;

//            DBConnection dbConnection = new DBConnection();
//            dbConnection.Connection.Open();

//            SqlCommand cmd = new SqlCommand(@"select id, classRoomDescription 
//                                              from ClassRooms 
//                                              where buildingName = @buldingName and classFloor = @classFloor and number = @number",
//                                            dbConnection.Connection);
//            cmd.Parameters.Add(new SqlParameter()
//            {
//                ParameterName = "@buldingName",
//                Value = building
//            });
//            cmd.Parameters.Add(new SqlParameter()
//            {
//                ParameterName = "@classFloor",
//                Value = Convert.ToInt32(floor)
//            });
//            cmd.Parameters.Add(new SqlParameter()
//            {
//                ParameterName = "@number",
//                Value = Convert.ToInt32(number)
//            });

//            SqlDataReader dr = cmd.ExecuteReader();
//            if (dr.Read())
//            {
//                if (!dr.IsDBNull(0))
//                {
//                    classId = dr.GetInt32(0);
//                    validValues = true;
//                }

//                classRoomDescription = dr.IsDBNull(1) ? string.Empty : dr.GetString(1);
//            }

//            if (!validValues)
//            {
//                dr.Close();
//                dbConnection.Connection.Close();
//                return null;
//            }

//            dr.Close();

//            if (string.IsNullOrEmpty(classRoomDescription))
//            {
//                classRoom = new ClassRoom(buildingName, classFloor, classNumber);
//            }
//            else
//            {
//                classRoom = new ClassRoom(buildingName, classFloor, classNumber, classRoomDescription);
//            }

//            cmd = new SqlCommand(@"select e.equipmentDescription, e.brand, e.modelName,
//	                                      e.serialNumber, e.isBroken 
//                                   from Equipments as e 
//                                   where e.classRoomId = @roomId", dbConnection.Connection);

//            cmd.Parameters.Add(new SqlParameter()
//            {
//                ParameterName = "@roomId",
//                Value = classId
//            });

//            dr = cmd.ExecuteReader();

//            while (dr.Read())
//            {
//                string equipementDescription = string.Empty;
//                string brand = string.Empty;
//                string modelName = string.Empty;
//                string serialNumber = string.Empty;
//                bool isBroken = false;

//                if (!dr.IsDBNull(0))
//                {
//                    equipementDescription = dr.GetString(0);
//                }
//                if (!dr.IsDBNull(1))
//                {
//                    brand = dr.GetString(1);
//                }
//                if (!dr.IsDBNull(2))
//                {
//                    modelName = dr.GetString(2);
//                }
//                if (!dr.IsDBNull(3))
//                {
//                    serialNumber = dr.GetString(3);
//                }
//                if (!dr.IsDBNull(4))
//                {
//                    isBroken = dr.GetBoolean(4);
//                }

//                BLEntities.Equipment equipment = new BLEntities.Equipment(brand, modelName, serialNumber, isBroken, equipementDescription);
//                classRoom.Equipments.Add(equipment);
//            }

//            dr.Close();
//            dbConnection.Connection.Close();

//            return classRoom;
//        }

//        public ISet<ResourceManagementSystem.BusinessLogic.Entities.ClassRoom> getByTask(ResourceManagementSystem.BusinessLogic.Entities.ITask task)
//        {
//            throw new NotImplementedException();
//        }

//        public ISet<ClassRoom> getAll()
//        {
//            DBConnection dbConnection = new DBConnection();
//            dbConnection.Connection.Open();

//            SqlCommand cmd = new SqlCommand(@"select cr.BuildingName, cr.ClassFloor, cr.Number from ClassRooms as cr", dbConnection.Connection);
//            SqlDataReader dr = cmd.ExecuteReader();
//            ISet<ClassRoom> classRooms = new HashSet<ClassRoom>();
//            while (dr.Read())
//            {
//                if (!dr.IsDBNull(0) && !dr.IsDBNull(1) && !dr.IsDBNull(2))
//                {
//                    ClassRoom classRoom = this.getByPK(dr.GetString(0), Convert.ToUInt32(dr.GetInt32(1)), Convert.ToUInt32(dr.GetInt32(2)));
//                    if (classRoom != null)
//                    {
//                        classRooms.Add(classRoom);
//                    }
//                }
//            }

//            dr.Close();
//            dbConnection.Connection.Close();

//            return classRooms;
//        }

//        public void Add(ResourceManagementSystem.BusinessLogic.Entities.ClassRoom classRoom)
//        {
//            DBConnection dbConnection = new DBConnection();
//            dbConnection.Connection.Open();

//            SqlCommand cmd = new SqlCommand(@"insert into ClassRooms VALUES (@classRoomDescription, @buildingName, @classFloor , @number)", dbConnection.Connection);
//            cmd.Parameters.Add(new SqlParameter()
//            {
//                ParameterName = "@classRoomDescription",
//                Value = classRoom.Description
//            });
//            cmd.Parameters.Add(new SqlParameter()
//            {
//                ParameterName = "@buildingName",
//                Value = classRoom.Building
//            });
//            cmd.Parameters.Add(new SqlParameter()
//            {
//                ParameterName = "@classFloor",
//                Value = Convert.ToInt32(classRoom.Floor)
//            });
//            cmd.Parameters.Add(new SqlParameter()
//            {
//                ParameterName = "@number",
//                Value = Convert.ToInt32(classRoom.Number)
//            });
//            cmd.ExecuteNonQuery();
//            dbConnection.Connection.Close();
//        }

//        public void Update(string building, uint floor, uint number, ResourceManagementSystem.BusinessLogic.Entities.ClassRoom newClassRoom)
//        {
//            DBConnection dbConnection = new DBConnection();
//            dbConnection.Connection.Open();

//            SqlCommand cmd = new SqlCommand(@"update ClassRooms SET classRoomDescription = @newClassRoomDescription, buildingName = @newBuildingName,
//					  number = @newNumber, classFloor = @newClassFloor where  buildingName = @buildingName and
//							   classFloor = @classFloor and number = @number", dbConnection.Connection);
//            cmd.Parameters.Add(new SqlParameter()
//            {
//                ParameterName = "@newClassRoomDescription",
//                Value = newClassRoom.Description
//            });
//            cmd.Parameters.Add(new SqlParameter()
//            {
//                ParameterName = "@buildingName",
//                Value = building
//            });
//            cmd.Parameters.Add(new SqlParameter()
//            {
//                ParameterName = "@classFloor",
//                Value = Convert.ToInt32(floor)
//            });
//            cmd.Parameters.Add(new SqlParameter()
//            {
//                ParameterName = "@number",
//                Value = Convert.ToInt32(number)
//            });
//            cmd.Parameters.Add(new SqlParameter()
//            {
//                ParameterName = "@newBuildingName",
//                Value = newClassRoom.Building
//            });
//            cmd.Parameters.Add(new SqlParameter()
//            {
//                ParameterName = "@newClassFloor",
//                Value = Convert.ToInt32(newClassRoom.Floor)
//            });
//            cmd.Parameters.Add(new SqlParameter()
//            {
//                ParameterName = "@newNumber",
//                Value = Convert.ToInt32(newClassRoom.Number)
//            });
//            cmd.ExecuteNonQuery();
//            dbConnection.Connection.Close();
//        }

//        public void Delete(string building, uint floor, uint number)
//        {
//            DBConnection dbConnection = new DBConnection();
//            dbConnection.Connection.Open();

//            //TO-DO: implement transactions
//            SqlCommand cmd = new SqlCommand(@"update Equipments SET classRoomId = null 
//	                                where classRoomId in (select id 
//						            from ClassRooms as cr 
//						                where cr.buildingName = @buildingName and 
//                                              classFloor = @classFloor and 
//                                              number = @number)", dbConnection.Connection);
//            cmd.Parameters.Add(new SqlParameter()
//            {
//                ParameterName = "@buildingName",
//                Value = building
//            });
//            cmd.Parameters.Add(new SqlParameter()
//            {
//                ParameterName = "@classFloor",
//                Value = Convert.ToInt32(floor)
//            });
//            cmd.Parameters.Add(new SqlParameter()
//            {
//                ParameterName = "@number",
//                Value = Convert.ToInt32(number)
//            });

//            cmd.ExecuteNonQuery();

//            cmd = new SqlCommand(@"delete from TasksClassRooms where classRoomId in (select id 
//						              from ClassRooms as cr 
//						              where cr.buildingName = 'Sediul central' and classFloor = 1 and number = 2)",
//                                 dbConnection.Connection);

//            cmd.Parameters.Add(new SqlParameter()
//            {
//                ParameterName = "@buildingName",
//                Value = building
//            });
//            cmd.Parameters.Add(new SqlParameter()
//            {
//                ParameterName = "@classFloor",
//                Value = Convert.ToInt32(floor)
//            });
//            cmd.Parameters.Add(new SqlParameter()
//            {
//                ParameterName = "@number",
//                Value = Convert.ToInt32(number)
//            });

//            cmd.ExecuteNonQuery();

//            cmd = new SqlCommand(@"delete from ClassRooms  where   buildingName = @buildingName and
//							   classFloor = @classFloor and number = @number", dbConnection.Connection);

//            cmd.Parameters.Add(new SqlParameter()
//            {
//                ParameterName = "@buildingName",
//                Value = building
//            });
//            cmd.Parameters.Add(new SqlParameter()
//            {
//                ParameterName = "@classFloor",
//                Value = Convert.ToInt32(floor)
//            });
//            cmd.Parameters.Add(new SqlParameter()
//            {
//                ParameterName = "@number",
//                Value = Convert.ToInt32(number)
//            });
//            cmd.ExecuteNonQuery();

//            dbConnection.Connection.Close();
//        }

//        public int getClassRoomIdbyClassRoom(ClassRoom classRoom)
//        {
//            int classId = 0;

//            DBConnection dbConnection = new DBConnection();
//            dbConnection.Connection.Open();

//            SqlCommand cmd = new SqlCommand(@"select id
//                                              from ClassRooms 
//                                              where buildingName = @buldingName and classFloor = @classFloor and number = @number",
//                                            dbConnection.Connection);
//            cmd.Parameters.Add(new SqlParameter()
//            {
//                ParameterName = "@buldingName",
//                Value = classRoom.Building
//            });
//            cmd.Parameters.Add(new SqlParameter()
//            {
//                ParameterName = "@classFloor",
//                Value = Convert.ToInt32(classRoom.Floor)
//            });
//            cmd.Parameters.Add(new SqlParameter()
//            {
//                ParameterName = "@number",
//                Value = Convert.ToInt32(classRoom.Number)
//            });

//            SqlDataReader dr = cmd.ExecuteReader();
//            if (dr.Read())
//            {
//                if (!dr.IsDBNull(0))
//                {
//                    classId = dr.GetInt32(0);
//                }
//                else
//                {
//                    classId = -1;
//                }
//            }
//            return classId;
//        }
//    }
//}
