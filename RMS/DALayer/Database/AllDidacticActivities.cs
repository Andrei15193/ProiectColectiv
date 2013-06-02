using DAOInterface;
using ResourceManagementSystem.BusinessLogic.Entities;
using ResourceManagementSystem.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALayer.Database
{
    class AllDidacticActivities : IAllDidacticActivities
    {
        private SqlCommand command;

        public AllDidacticActivities()
        {
            command = new SqlCommand() { Connection = DatabaseConstants.SqlConnection };
        }

        public void Add(DidacticActivity didacticActivity)
        {
            int activityid = -1;
            command.CommandText = @"insert into activities (type, title, description, state, startDate, endDate) values (@type, @title, @description, @state, @startdate, @enddate); select scope_identity()";
            command.Parameters.Clear();
            command.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@type",
                Value = didacticActivity.Type
            });
            command.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@title",
                Value = didacticActivity.Title
            });
            command.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@description",
                Value = didacticActivity.Description
            });
            command.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@state",
                Value = didacticActivity.State
            });
            command.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@startdate",
                Value = didacticActivity.StartDate
            });
            command.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@enddate",
                Value = didacticActivity.EndDate
            });
            try
            {
                command.Connection.Open();
                activityid = Convert.ToInt32(command.ExecuteScalar());

                command.CommandText = @"insert into didacticActivities(formation, assignee, coursetype, activity) values (@formation, @assignee, @coursetype, @activity)";
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@activity",
                    Value = activityid
                });
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@formation",
                    Value = didacticActivity.Formation
                });
                IEnumerator<Member> e = didacticActivity.GetEnumerator();
                e.MoveNext();
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@assignee",
                    Value = e.Current
                });
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@coursetype",
                    Value = didacticActivity.Formation
                });
                command.ExecuteNonQuery();
                foreach (ClassRoom c in didacticActivity.ClassRooms)
                {
                    command.CommandText = @"insert into activityClassRooms(classRoom, activity) values (@classroom, @activity)";
                    command.Parameters.Clear();
                    command.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@activity",
                        Value = activityid
                    });
                    command.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@classroom",
                        Value = c.Name
                    });
                    command.ExecuteNonQuery();
                }
                foreach (Equipment eq in didacticActivity.Equipments)
                {
                    command.CommandText = @"insert into activityEquipments(equipment, activity) values (@equipment, @activity)";
                    command.Parameters.Clear();
                    command.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@activity",
                        Value = activityid
                    });
                    command.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@equipment",
                        Value = eq.SerialNumber
                    });
                    command.ExecuteNonQuery();
                }
            }
            finally
            {
                command.Connection.Close();
            }
        }

        public IEnumerable<ResourceManagementSystem.BusinessLogic.Entities.DidacticActivity> AsEnumerable
        {
            get { return getAll(); }
        }

        private LinkedList<DidacticActivity> getAll()
        {
            LinkedList<DidacticActivity> didacticActivities = new LinkedList<DidacticActivity>();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = @"select activity from didacticactivities";
            command.Parameters.Clear();
            SqlDataReader reader = null;
            try
            {
                command.Connection.Open();
                reader = command.ExecuteReader();
                didacticActivities = ReadDidacticActivities(reader);
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                command.Connection.Close();
            }
            return didacticActivities;
        }

        private LinkedList<DidacticActivity> ReadDidacticActivities(SqlDataReader reader)
        {
            LinkedList<DidacticActivity> didacticActivities = new LinkedList<DidacticActivity>();
            if (reader != null)
            {
                while (reader.Read())
                {
                    didacticActivities.AddLast((DidacticActivity)new AllActivities().getbyPK(reader.GetInt32(0)));
                }
            }
            return didacticActivities;
        }
    }
}
