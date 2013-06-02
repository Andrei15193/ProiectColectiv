using ResourceManagementSystem.BusinessLogic.Entities;
using ResourceManagementSystem.DAOInterface;
using ResourceManagementSystem.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALayer.Database
{
    public class AllStudentCircles : IAllStudentCircles
    {
        public AllStudentCircles()
        {
            command = new SqlCommand() { Connection = DatabaseConstants.SqlConnection };
        }

        public void Add(StudentCircle studentCircle)
        {
            int activityid = -1;
            command.CommandText = @"insert into activities (type, title, description, state, startDate, endDate) values (@type, @title, @description, @state, @startdate, @enddate); select scope_identity()";
            command.Parameters.Clear();
            command.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@type",
                Value = studentCircle.Type
            });
            command.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@title",
                Value = studentCircle.Title
            });
            command.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@description",
                Value = studentCircle.Description
            });
            command.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@state",
                Value = studentCircle.State
            });
            command.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@startdate",
                Value = studentCircle.StartDate
            });
            command.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@enddate",
                Value = studentCircle.EndDate
            });
            try
            {
                command.Connection.Open();
                activityid = Convert.ToInt32(command.ExecuteScalar());

                command.CommandText = @"insert into studentcircles (activity, studyprogram) values (@activity, @studyProgram)";
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@activity",
                    Value = activityid
                });
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@studyProgram",
                    Value = studentCircle.StudyProgram.Id
                });
                command.ExecuteNonQuery();
            }
            finally
            {
                command.Connection.Close();
            }
        }

        public IEnumerable<StudentCircle> AsEnumerable
        {
            get { return getAll(); }
        }

        private LinkedList<StudentCircle> getAll()
        {
            LinkedList<StudentCircle> studentCircles = new LinkedList<StudentCircle>();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = @"select activity, studyProgram from studentcircles";
            command.Parameters.Clear();
            SqlDataReader reader = null;
            try
            {
                command.Connection.Open();
                reader = command.ExecuteReader();
                studentCircles = ReadStudentCircles(reader);
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                command.Connection.Close();
            }
            return studentCircles;
        }

        private LinkedList<StudentCircle> ReadStudentCircles(SqlDataReader reader)
        {
            LinkedList<StudentCircle> studentCircles = new LinkedList<StudentCircle>();
            if (reader != null)
            {
                while (reader.Read())
                {
                    studentCircles.AddLast((StudentCircle)new AllActivities().getbyPK(reader.GetInt32(0)));
                }
            }
            return studentCircles;
        }

        private SqlCommand command { get; set; }
    }
}
