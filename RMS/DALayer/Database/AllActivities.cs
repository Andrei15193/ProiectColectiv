using ResourceManagementSystem.BusinessLogic.Entities;
using ResourceManagementSystem.DAOInterface;
using ResourceManagementSystem.DataAccess;
using ResourceManagementSystem.DataAccess.Database;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALayer.Database
{
    public class AllActivities : IAllActivities
    {
        private SqlCommand command;

        public AllActivities()
        {
            command = new SqlCommand() { Connection = DatabaseConstants.SqlConnection };
        }

        public IEnumerable<AbstractActivity> AsEnumerable
        {
            get { return getAll(); }
        }

        private LinkedList<AbstractActivity> getAll()
        {
            LinkedList<AbstractActivity> activities = new LinkedList<AbstractActivity>();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = @"select id, type, title, description, startDate, endDate, state from Activities";
            command.Parameters.Clear();
            SqlDataReader reader = null;
            try
            {
                command.Connection.Open();
                reader = command.ExecuteReader();
                activities = ReadActivities(reader);
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                command.Connection.Close();
            }
            return activities;
        }

        private LinkedList<AbstractActivity> ReadActivities(SqlDataReader reader)
        {
            LinkedList<AbstractActivity> activities = new LinkedList<AbstractActivity>();
            if (reader != null)
            {
                while (reader.Read())
                {
                    ActivityType a = (ActivityType)Convert.ToInt32(reader["type"].ToString());
                    switch (a)
                    {
                        case ActivityType.Administrative:
                            {
                                activities.AddLast(new AdministrativeActivity(reader["title"].ToString(), reader["description"].ToString(), reader.GetDateTime(5), reader.GetDateTime(6))
                                {
                                    BreakdownActvities = new AllTaskBreakDownActivities().GetbyAdministrativeActivity(Convert.ToInt32(reader["id"])),
                                    Id = Convert.ToInt32(reader["id"].ToString()),
                                    State = (State) Convert.ToInt32(reader["state"].ToString())
                                });
                                break;
                            }
                        #region 1
                        case ActivityType.Didactic:
                            {
                                CourseType courseType = CourseType.Course;
                                Member m = null;
                                string formation = null;
                                SqlCommand cmd = new SqlCommand(@"select formation, assignee, coursetype from didacticactivities where activity = @id", DatabaseConstants.SqlConnection);
                                cmd.Parameters.Clear();

                                SqlDataReader dr = null;
                                cmd.Parameters.Add(new SqlParameter()
                                {
                                    ParameterName = "@id",
                                    Value = Convert.ToInt32(reader["id"])
                                });
                                try
                                {
                                    cmd.Connection.Open();
                                    dr = cmd.ExecuteReader();
                                    if (dr.Read())
                                    {
                                        courseType = (CourseType)Convert.ToInt32(dr["coursetype"].ToString());
                                        m = new AllMembers().Where(dr["assignee"].ToString());
                                        formation = dr["formation"].ToString();
                                    }
                                }
                                finally
                                {
                                    if (dr != null)
                                    {
                                        dr.Close();
                                    }
                                    cmd.Connection.Close();
                                }
                                activities.AddLast(new DidacticActivity(courseType, reader["title"].ToString(), reader["description"].ToString(), formation, reader.GetDateTime(4), reader.GetDateTime(5), m)
                                {
                                    Id = Convert.ToInt32(reader["id"]),
                                    Equipments = new AllEquipments().getByActivity(Convert.ToInt32(reader["id"])),
                                    ClassRooms = new AllClassRooms().getByActivity(Convert.ToInt32(reader["id"])),
                                    State = (State) Convert.ToInt32(reader["state"].ToString())
                                });
                                break;
                            }
                        #endregion
                        #region 2
                        case ActivityType.General_Activity:
                            {
                                activities.AddLast(new TaskBreakdownActivity(null, reader["title"].ToString(), reader["description"].ToString(), reader.GetDateTime(4), reader.GetDateTime(5))
                                {
                                    tasks = new AllTasks().getByBreakdownActivity(reader["id"]),
                                    Id = Convert.ToInt32(reader["id"].ToString()),
                                    State = (State)Convert.ToInt32(reader["state"].ToString())
                                });
                                break;
                            }
                        #endregion
                        #region 3
                        case ActivityType.Research:
                            {
                                ResearchPhase rp = null;
                                IEnumerable<Member> members = null;
                                FinancialResource mobilittyCost = null;
                                FinancialResource laborCost = null;
                                FinancialResource logisticalCost = null;
                                bool isConfidential = false;
                                SqlCommand cmd = new SqlCommand(@"select team, phase, researchProject, laborCosts, logisticalCosts, mobilityCosts, isConfidential from researchActivities where activity = @id", DatabaseConstants.SqlConnection);
                                cmd.Parameters.Clear();

                                SqlDataReader dr = null;
                                cmd.Parameters.Add(new SqlParameter()
                                {
                                    ParameterName = "@id",
                                    Value = Convert.ToInt32(reader["id"])
                                });
                                try
                                {
                                    cmd.Connection.Open();
                                    dr = cmd.ExecuteReader();
                                    if (dr.Read())
                                    {
                                        members = new AllMembers().getTeam(Convert.ToInt32(dr["team"].ToString()));
                                        mobilittyCost = new AllFinancialResources().getbyPK(Convert.ToInt32(dr["mobilityCosts"].ToString()));
                                        laborCost = new AllFinancialResources().getbyPK(Convert.ToInt32(dr["laborCosts"].ToString()));
                                        logisticalCost = new AllFinancialResources().getbyPK(Convert.ToInt32(dr["logisticalCosts"].ToString()));
                                        isConfidential = Convert.ToBoolean(dr["isConfidential"]);
                                        rp = new AllResearchPhases().getByPK(Convert.ToInt32(dr["researchProject"].ToString()));
                                    }
                                }
                                finally
                                {
                                    if (dr != null)
                                    {
                                        dr.Close();
                                    }
                                    cmd.Connection.Close();
                                }
                                activities.AddLast(new ResearchActivity(rp, reader["title"].ToString(), reader["description"].ToString(), reader.GetDateTime(4), reader.GetDateTime(5), members, mobilittyCost, laborCost, logisticalCost, isConfidential)
                                {
                                    Id = Convert.ToInt32(reader["id"].ToString()),
                                    State = (State)Convert.ToInt32(reader["state"].ToString())
                                });
                                break;
                            }
                        #endregion
                        #region 4
                        case ActivityType.Research_Phase:
                            {
                                activities.AddLast(new ResearchPhase(new AllResearchProjects().getByPhase(Convert.ToInt32(reader["id"])), reader["title"].ToString(), reader["description"].ToString(), reader.GetDateTime(4), reader.GetDateTime(5))
                                {

                                    Id = Convert.ToInt32(reader["id"].ToString()),
                                    State = (State) Convert.ToInt32(reader["state"])
                                });
                                break;
                            }
                        #endregion
                        #region 5
                        case ActivityType.Research_Project:
                            {
                                int teamid = -1;
                                SqlCommand cmd = new SqlCommand(@"select team from researchprojects where activity = @id", DatabaseConstants.SqlConnection);
                                cmd.Parameters.Clear();

                                SqlDataReader dr = null;
                                cmd.Parameters.Add(new SqlParameter()
                                {
                                    ParameterName = "@id",
                                    Value = Convert.ToInt32(reader["id"])
                                });
                                try
                                {
                                    cmd.Connection.Open();
                                    dr = cmd.ExecuteReader();
                                    if (dr.Read())
                                    {
                                        teamid = dr.GetInt32(0);
                                    }
                                }
                                finally
                                {
                                    if (dr != null)
                                    {
                                        dr.Close();
                                    }
                                    cmd.Connection.Close();
                                }
                                activities.AddLast(new ResearchProject(reader["title"].ToString(), reader["description"].ToString(), reader.GetDateTime(4), reader.GetDateTime(5), new AllMembers().getTeam(teamid))
                                {
                                    //phases = new AllResearchPhases().getByResearchProject(Convert.ToInt32(reader["id"].ToString())),
                                    Id = Convert.ToInt32(reader["id"].ToString()),
                                    State = (State)Convert.ToInt32(reader["state"].ToString())
                                });
                                break;
                            }
                        #endregion
                        #region 6
                        case ActivityType.Student_Circle:
                            {
                                activities.AddLast(new StudentCircle(reader["title"].ToString(), reader["description"].ToString(), reader.GetDateTime(4), reader.GetDateTime(5), new Studyprograms().getByStudentCircle(Convert.ToInt32(reader["id"].ToString())))
                                {
                                    Id = Convert.ToInt32(reader["id"].ToString()),
                                    State = (State)Convert.ToInt32(reader["state"].ToString())
                                });
                                break;
                            }
                        #endregion
                    }
                }
            }
            return activities;
        }

        public AbstractActivity getbyPK(int activity)
        {
            LinkedList<AbstractActivity> activities = new LinkedList<AbstractActivity>();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = @"select id, type, title, description, startDate, endDate, state from Activities where id = @id";
            command.Parameters.Clear();
            command.Parameters.Add(new SqlParameter()
            {
                Value = activity,
                ParameterName = "@id"
            });
            SqlDataReader reader = null;
            try
            {
                command.Connection.Open();
                reader = command.ExecuteReader();
                activities = ReadActivities(reader);
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                command.Connection.Close();
            }
            if (activities.Count() > 0)
                return activities.First();
            else
                return null;
        }


        

        public void aproveActivity(AbstractActivity activity,bool aproved)
        {
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = @"update activities set state = @state where id = @id";
            command.Parameters.Clear();
            command.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@state",
                Value = aproved ? State.Aproved : State.Rejected
            });
            command.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@id",
                Value = activity.Id
            });
            SqlDataReader reader = null;
            try
            {
                command.Connection.Open();
                command.ExecuteNonQuery();
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
    }
}
