using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL = ResourceManagementSystem.BusinessLogic.Entities;

namespace DALayer.DBImpl
{
    public class Tasks
    {
        public int? GetTaksIdByTask(BL.ITask task)
        {
            if (task == null || task.Location == null || task.StartDate != null || task.Location.Building == null)
            {
                return null;
            }

            int? taskId = null;

            DBConnection dbConnection = new DBConnection();

            SqlCommand cmd = new SqlCommand(@"select t.id from (select * from ClassRooms as cr where cr.buildingName = @building and classFloor = @floor and number = @number) as c 
                                                inner join TasksClassRooms as tcr on c.id = tcr.classRoomId 
                                                inner join Tasks as t on t.id = tcr.taskId where t.startDate = @startdate", dbConnection.Connection);
            cmd.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@building",
                Value = task.Location.Building
            });
            cmd.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@number",
                Value = Convert.ToInt32(task.Location.Number)
            });
            cmd.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@floor",
                Value = task.Location.Floor
            });
            cmd.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@startdate",
                Value = task.StartDate
            });

            dbConnection.Connection.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                if (!dr.IsDBNull(0))
                {
                    taskId = dr.GetInt32(0);
                }
            }

            dr.Close();
            dbConnection.Connection.Close();

            return taskId;
        }
    }
}
