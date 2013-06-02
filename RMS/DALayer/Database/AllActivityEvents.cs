using ResourceManagementSystem.BusinessLogic.Entities;
using ResourceManagementSystem.BusinessLogic.Entities.Collections;
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
    class AllAdministrativeActivity : IAllAdministrativeActivity
    {
        private SqlCommand command;

        public AllAdministrativeActivity()
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

        IEnumerable<ResourceManagementSystem.BusinessLogic.Entities.AdministrativeActivity> IAllAdministrativeActivity.AsEnumerable
        {
            get { throw new NotImplementedException(); }
        }

        public void Add(ResourceManagementSystem.BusinessLogic.Entities.AdministrativeActivity administrativeActivity)
        {
            int activityid = -1;
            int teamid = -1;
            command.CommandText = @"insert into activities (type, title, description, state, startDate, endDate) values (@type, @title, @description, @state, @startdate, @enddate); select scope_identity()";
            command.Parameters.Clear();
            command.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@type",
                Value = administrativeActivity.Type
            });
            command.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@title",
                Value = administrativeActivity.Title
            });
            command.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@description",
                Value = administrativeActivity.Description
            });
            command.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@state",
                Value = administrativeActivity.State
            });
            command.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@startdate",
                Value = administrativeActivity.StartDate
            });
            command.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@enddate",
                Value = administrativeActivity.EndDate
            });
            try
            {
                command.Connection.Open();
                activityid = Convert.ToInt32(command.ExecuteScalar());
                foreach (Team t in administrativeActivity.Teams)
                {
                    command.CommandText = @"insert into teams(name) values (@name); select scope_identity()";
                    command.Parameters.Clear();
                    command.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@name",
                        Value = t.GetType() == typeof(NamedTeam) ? ((NamedTeam)t).Name : ""
                    });
                    teamid = Convert.ToInt32(command.ExecuteScalar());
                    foreach (Member m in t)
                    {
                        command.CommandText = @"insert into teammembers values (@teamId, @email)";
                        command.Parameters.Clear();
                        command.Parameters.Add(new SqlParameter()
                        {
                            ParameterName = "@teamId",
                            Value = teamid
                        });
                        command.Parameters.Add(new SqlParameter()
                        {
                            ParameterName = "@email",
                            Value = m.EMail
                        });
                        command.ExecuteNonQuery();
                    }


                    command.CommandText = @"insert into administrativeActivities (activity, team) values (@activity, @team)";
                    command.Parameters.Clear();
                    command.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@activity",
                        Value = activityid
                    });
                    command.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@team",
                        Value = teamid
                    });
                    command.ExecuteNonQuery();
                }
                //foreach (ResearchPhase rp in researchProject)
                //{
                //    new AllResearchPhases().Add(activityid, rp);
                //}
            }
            finally
            {
                command.Connection.Close();
            }
        }
    }
}
