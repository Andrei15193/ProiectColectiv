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
    public class ClassRooms: IClassRoom
    {
        public ResourceManagementSystem.BusinessLogic.Entities.ClassRoom getByPK(string building, uint floor, uint number)
        {
            throw new NotImplementedException();
        }

        public ISet<ResourceManagementSystem.BusinessLogic.Entities.ClassRoom> getByTask(ResourceManagementSystem.BusinessLogic.Entities.ITask task)
        {
            throw new NotImplementedException();
        }

        public ISet<ClassRoom> getAll()
        {
            DBConnection.GetConnection().Open();
            SqlCommand cmd = new SqlCommand(@"select cr.BuildingName, cr.ClassFloor, cr.Number, cr.classRoomDescription as Description from ClassRooms as cr", DBConnection.GetConnection());
            SqlDataReader dr = cmd.ExecuteReader();
            ISet<ClassRoom> classRooms = new HashSet<ClassRoom>();
            while (dr.Read())
            {
                if (!dr.IsDBNull(0) && !dr.IsDBNull(1) && !dr.IsDBNull(2) && !dr.IsDBNull(3))
                {
                    classRooms.Add(new ClassRoom(dr.GetString(0), Convert.ToUInt32(dr.GetInt32(1)), Convert.ToUInt32(dr.GetInt32(2)), dr.GetString(3)));
                }
            }
            dr.Close();
            DBConnection.GetConnection().Close();
            return classRooms;
        }

        public void Add(ResourceManagementSystem.BusinessLogic.Entities.ClassRoom classRoom)
        {
            DBConnection.GetConnection().Open();
            SqlCommand cmd = new SqlCommand(@"insert into ClassRooms VALUES (@classRoomDescription, @buildingName, @classFloor , @number)", DBConnection.GetConnection());
            cmd.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@classRoomDescription",
                Value = classRoom.Description
            });
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
            cmd.ExecuteNonQuery();
            DBConnection.GetConnection().Close();
        }

        public void Update(string building, uint floor, uint number, ResourceManagementSystem.BusinessLogic.Entities.ClassRoom newClassRoom)
        {
            DBConnection.GetConnection().Open();
            SqlCommand cmd = new SqlCommand(@"update ClassRooms SET classRoomDescription = @newClassRoomDescription, buildingName = @newBuildingName,
					  number = @newNumber, classFloor = @newClassFloor where  buildingName = @buildingName and
							   classFloor = @classFloor and number = @number", DBConnection.GetConnection());
            cmd.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@newClassRoomDescription",
                Value = newClassRoom.Description
            });
            cmd.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@buildingName",
                Value = building
            });
            cmd.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@classFloor",
                Value = Convert.ToInt32(floor)
            });
            cmd.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@number",
                Value = Convert.ToInt32(number)
            });
            cmd.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@newBuildingName",
                Value = newClassRoom.Building
            });
            cmd.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@newClassFloor",
                Value = Convert.ToInt32(newClassRoom.Floor)
            });
            cmd.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@newNumber",
                Value = Convert.ToInt32(newClassRoom.Number)
            });
            cmd.ExecuteNonQuery();
            DBConnection.GetConnection().Close();
        }

        public void Delete(string building, uint floor, uint number)
        {
            DBConnection.GetConnection().Open();
            SqlCommand cmd = new SqlCommand(@"delete from ClassRooms  where   buildingName = @buildingName and
							   classFloor = @classFloor and number = @number", DBConnection.GetConnection());
            
            cmd.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@buildingName",
                Value = building
            });
            cmd.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@classFloor",
                Value = Convert.ToInt32(floor)
            });
            cmd.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@number",
                Value = Convert.ToInt32(number)
            });
            cmd.ExecuteNonQuery();
            DBConnection.GetConnection().Close();
        }
    }
}
