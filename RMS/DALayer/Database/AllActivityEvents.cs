using ResourceManagementSystem.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResourceManagementSystem.BusinessLogic.Entities;

namespace DALayer.Database
{
    class AllActivityEvents
    {
        private SqlCommand command;

        public AllActivityEvents()
        {
            command = new SqlCommand() { Connection = DatabaseConstants.SqlConnection };
        }

        public void Add()
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
                reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
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
    }
}
