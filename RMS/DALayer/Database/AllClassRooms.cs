using ResourceManagementSystem.BusinessLogic.Entities;
using ResourceManagementSystem.DAOInterface;
using ResourceManagementSystem.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLEntities = ResourceManagementSystem.BusinessLogic.Entities;

namespace DALayer.Database
{
    public class AllClassRooms : IAllClassRooms
    {
        private SqlCommand command;

        public AllClassRooms()
        {
            command = new SqlCommand() { Connection = DatabaseConstants.SqlConnection };
        }

        public void Add(ClassRoom classRoom)
        {

            command.CommandText = @"insert into ClassRooms (name, description) VALUES (@name, @classRoomDescription)";
            command.Parameters.Clear();
            command.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@classRoomDescription",
                Value = classRoom.Description
            });
            command.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@name",
                Value = classRoom.Name
            });
            try
            {
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
            finally
            {
                command.Connection.Close();
            }
        }

        public IEnumerable<ClassRoom> AsEnumerable
        {
            get { return getAll(); }
        }

        private LinkedList<ClassRoom> getAll()
        {
            LinkedList<ClassRoom> classrooms = new LinkedList<ClassRoom>();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = @"select name, description from classrooms";
            command.Parameters.Clear();
            SqlDataReader reader = null;
            try
            {
                command.Connection.Open();
                reader = command.ExecuteReader();
                classrooms = ReadClassRooms(reader);
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                command.Connection.Close();
            }
            return classrooms;
        }

        private LinkedList<ClassRoom> ReadClassRooms(SqlDataReader reader)
        {
            LinkedList<ClassRoom> classrooms = new LinkedList<ClassRoom>();
            if (reader != null)
            {
                while (reader.Read())
                {
                    classrooms.AddLast(new ClassRoom(reader["name"].ToString(), reader["description"].ToString()));
                }
            }
            return classrooms;
        }

        internal ICollection<ClassRoom> getByActivity(int activity)
        {
            LinkedList<ClassRoom> classrooms = new LinkedList<ClassRoom>();
            SqlCommand cmd = new SqlCommand("select classRoom from activityclassrooms where activity = @activity", DatabaseConstants.SqlConnection);
            cmd.Parameters.Add(new SqlParameter()
            {
                Value = activity,
                ParameterName = "@activity"
            });
            cmd.Connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = @"select name, description from classrooms where name = @name";
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter()
                {
                    Value = dr["classRoom"],
                    ParameterName = "@name"
                });
                SqlDataReader reader = null;
                try
                {
                    command.Connection.Open();
                    reader = command.ExecuteReader();
                    classrooms.AddLast(ReadClassRooms(reader).First);
                }
                finally
                {
                    if (reader != null)
                    {
                        reader.Close();
                    }
                    command.Connection.Close();
                }
            }
            dr.Close();
            cmd.Connection.Close();
            return classrooms;
        }
    }
}
