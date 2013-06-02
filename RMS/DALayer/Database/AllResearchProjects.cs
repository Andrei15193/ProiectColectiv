using ResourceManagementSystem.BusinessLogic.Entities;
using ResourceManagementSystem.BusinessLogic.Entities.Collections;
using ResourceManagementSystem.DAOInterface;
using ResourceManagementSystem.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DALayer.Database
{
    public class AllResearchProjects : IAllResearchProjects
    {
        private SqlCommand command;

        public AllResearchProjects()
        {
            command = new SqlCommand() { Connection = DatabaseConstants.SqlConnection };
        }

        public ResourceManagementSystem.BusinessLogic.Entities.ResearchProject getByPhase(int p)
        {
            LinkedList<ResearchProject> researchProjects = new LinkedList<ResearchProject>();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = @"select researchProject from researchProjectPhases where activity = @activity";
            command.Parameters.Clear();
            command.Parameters.Add(new SqlParameter()
            {
                Value = p,
                ParameterName = "@activity"
            });
            SqlDataReader reader = null;
            try
            {
                command.Connection.Open();
                reader = command.ExecuteReader();
                researchProjects = ReadResearchProjects(reader);
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                command.Connection.Close();
            }
            if (researchProjects.Count() > 0)
                return researchProjects.First();
            else
                return null;
        }

        public void Add(ResourceManagementSystem.BusinessLogic.Entities.ResearchProject researchProject)
        {
            int activityid = -1;
            int teamid = -1;
            command.CommandText = @"insert into activities (type, title, description, state, startDate, endDate) values (@type, @title, @description, @state, @startdate, @enddate); select scope_identity()";
            command.Parameters.Clear();
            command.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@type",
                Value = researchProject.Type
            });
            command.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@title",
                Value = researchProject.Title
            });
            command.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@description",
                Value = researchProject.Description
            });
            command.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@state",
                Value = researchProject.State
            });
            command.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@startdate",
                Value = researchProject.StartDate
            });
            command.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@enddate",
                Value = researchProject.EndDate
            });
            try
            {
                command.Connection.Open();
                activityid = Convert.ToInt32(command.ExecuteScalar());

                command.CommandText = @"insert into teams(name) values (@name); select scope_identity()";
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@name",
                    Value = researchProject.Team.GetType() == typeof(NamedTeam) ? ((NamedTeam)researchProject.Team).Name : ""
                });
                teamid = Convert.ToInt32(command.ExecuteScalar());
                foreach (Member m in researchProject.Team)
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

                
                command.CommandText = @"insert into researchProjects (activity, team) values (@activity, @team)";
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
                foreach (ResearchPhase rp in researchProject)
                {
                    new AllResearchPhases().Add(activityid, rp);
                }
            }
            finally
            {
                command.Connection.Close();
            }
        }

        public IEnumerable<ResourceManagementSystem.BusinessLogic.Entities.ResearchProject> AsEnumerable
        {
            get { return getAll(); }
        }

        private LinkedList<ResearchProject> getAll()
        {
            LinkedList<ResearchProject> researchProjects = new LinkedList<ResearchProject>();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = @"select activity, team from researchProjects";
            command.Parameters.Clear();
            SqlDataReader reader = null;
            try
            {
                command.Connection.Open();
                reader = command.ExecuteReader();
                researchProjects = ReadResearchProjects(reader);
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                command.Connection.Close();
            }
            return researchProjects;
        }

        private LinkedList<ResearchProject> ReadResearchProjects(SqlDataReader reader)
        {
            LinkedList<ResearchProject> researchProjects = new LinkedList<ResearchProject>();
            if (reader != null)
            {
                while (reader.Read())
                {
                    researchProjects.AddLast((ResearchProject)new AllActivities().getbyPK(reader.GetInt32(0)));
                }
            }
            return researchProjects;
        }
    }
}
