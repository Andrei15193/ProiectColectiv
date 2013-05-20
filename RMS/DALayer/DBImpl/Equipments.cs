using ResourceManagementSystem.BusinessLogic.Entities;
using ResourceManagementSystem.DataAccess.DAOInterface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALayer.DBImpl
{
    public class Equipments : IEquipment
    {

        public ResourceManagementSystem.BusinessLogic.Entities.Equipment getByPK(string serialNumber)
        {
            Equipment equipment = null;
            string brand = null;
            string model = null;
            string description = string.Empty;
            bool isBroken = false;
            int classRoomId = -1;
            ClassRoom classRoom = null;
            DBConnection dbConnection = new DBConnection();
            dbConnection.Connection.Open();

            SqlCommand cmd = new SqlCommand(@"select equipmentDescription, brand, modelName, isBroken, classRoomId from Equipments where serialNumber = @serialNumber",
                                            dbConnection.Connection);
            cmd.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@serialNumber",
                Value = serialNumber
            });
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (!dr.IsDBNull(0))
                {
                    description = dr.GetString(0);
                }
                if (!dr.IsDBNull(1))
                {
                    brand = dr.GetString(1);
                }
                if (!dr.IsDBNull(2))
                {
                    model = dr.GetString(2);
                }
                if (!dr.IsDBNull(3))
                {
                    isBroken = dr.GetBoolean(3);
                }
                if (!dr.IsDBNull(4))
                {
                    classRoomId = dr.GetInt32(4);
                }
            }
            dr.Close();
            cmd = new SqlCommand(@"select cr.BuildingName, cr.ClassFloor, cr.Number from ClassRooms as cr where id = @id", dbConnection.Connection);
            cmd.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@id",
                Value = classRoomId
            });
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (!dr.IsDBNull(0) && !dr.IsDBNull(1) && !dr.IsDBNull(2))
                {
                    classRoom = new ClassRooms().getByPK(dr.GetString(0), Convert.ToUInt32(dr.GetInt32(1)), Convert.ToUInt32(dr.GetInt32(2)));
                }
            }
            dr.Close();
            dbConnection.Connection.Close();
            equipment = new Equipment(brand, model, serialNumber, isBroken, description, classRoom);
            return equipment;
        }

        public ISet<ResourceManagementSystem.BusinessLogic.Entities.Equipment> getAll()
        {
            DBConnection dbConnection = new DBConnection();
            dbConnection.Connection.Open();

            SqlCommand cmd = new SqlCommand(@"select serialNumber from Equipments", dbConnection.Connection);
            SqlDataReader dr = cmd.ExecuteReader();
            ISet<Equipment> equipments = new HashSet<Equipment>();
            while (dr.Read())
            {
                if (!dr.IsDBNull(0))
                {
                    Equipment equipment = this.getByPK(dr.GetString(0));
                    if (equipment != null)
                    {
                        equipments.Add(equipment);
                    }
                }
            }
            dr.Close();
            dbConnection.Connection.Close();

            return equipments;
        }

        public ISet<ResourceManagementSystem.BusinessLogic.Entities.Equipment> getByTask(ResourceManagementSystem.BusinessLogic.Entities.ITask task)
        {
            DBConnection dbConnection = new DBConnection();
            dbConnection.Connection.Open();
            int taskId = -1;
            SqlCommand cmd = new SqlCommand(@"select serialNumber from TasksEquipments where taskId = @taskId", dbConnection.Connection);
            cmd.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@taskId",
                Value = taskId
            });
            SqlDataReader dr = cmd.ExecuteReader();
            ISet<Equipment> equipments = new HashSet<Equipment>();
            while (dr.Read())
            {
                if (!dr.IsDBNull(0))
                {
                    Equipment equipment = this.getByPK(dr.GetString(0));
                    if (equipment != null)
                    {
                        equipments.Add(equipment);
                    }
                }
            }
            dr.Close();
            dbConnection.Connection.Close();

            return equipments;
        }

        public ISet<ResourceManagementSystem.BusinessLogic.Entities.Equipment> getByClassRoom(ResourceManagementSystem.BusinessLogic.Entities.ClassRoom classRoom)
        {
            DBConnection dbConnection = new DBConnection();
            dbConnection.Connection.Open();
            int classRoomId = -1;
            SqlCommand cmd = new SqlCommand(@"select id from ClassRooms where  buildingName = @buildingName and
							   classFloor = @classFloor and number = @number", dbConnection.Connection);

            cmd.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@buildingName",
                Value = classRoom.Building
            });
            cmd.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@classFloor",
                Value = Convert.ToInt32(classRoom.Floor)
            });
            cmd.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@number",
                Value = Convert.ToInt32(classRoom.Number)
            });
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (!dr.IsDBNull(0))
                {
                    classRoomId = dr.GetInt32(0);
                }
            }
            dr.Close();
            cmd = new SqlCommand(@"select serialNumber from Equipments where classRoomId = @classRoomId", dbConnection.Connection);
            cmd.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@classRoomId",
                Value = classRoomId
            });
            dr = cmd.ExecuteReader();
            ISet<Equipment> equipments = new HashSet<Equipment>();
            while (dr.Read())
            {
                if (!dr.IsDBNull(0))
                {
                    Equipment equipment = this.getByPK(dr.GetString(0));
                    if (equipment != null)
                    {
                        equipments.Add(equipment);
                    }
                }
            }
            dr.Close();
            dbConnection.Connection.Close();
            return equipments;
        }

        public void Add(ResourceManagementSystem.BusinessLogic.Entities.Equipment equipment)
        {
            DBConnection dbConnection = new DBConnection();
            dbConnection.Connection.Open();

            SqlCommand cmd = new SqlCommand(@"insert into equipments('equipmentDescription', 'brand', 'serialNumber', 'isBroken', 'classRoomId') 
                                            values(@equipmentDescription, @brand, @serialNumber, @isBroken, @classRoomId)", dbConnection.Connection);
            cmd.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@equipmentDescription",
                Value = equipment.Description
            });
            cmd.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@brand",
                Value = equipment.Brand
            });
            cmd.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@serialNumber",
                Value = equipment.SerialNumber
            });
            cmd.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@isBroken",
                Value = equipment.IsBroken
            });
            cmd.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@classRoomId",
                Value = equipment.ClassRoom
            });
            cmd.ExecuteNonQuery();
            int taskId = -1;
            cmd = new SqlCommand(@"insert into tasksequipments Values(@serialNumber, @taskId)", dbConnection.Connection);
            cmd.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@serialNumber",
                Value = equipment.SerialNumber
            });
            cmd.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@taskId",
                Value = taskId
            });
            cmd.ExecuteNonQuery(); 
            dbConnection.Connection.Close();
        }

        public void Update(string serialNumber, ResourceManagementSystem.BusinessLogic.Entities.Equipment newEquipment)
        {
            throw new NotImplementedException();
        }

        public void Delete(string serialNumber)
        {
            throw new NotImplementedException();
        }
    }
}
