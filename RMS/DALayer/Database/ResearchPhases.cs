using ResourceManagementSystem.BusinessLogic.Entities;
using ResourceManagementSystem.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DALayer.Database
{
    public class AllResearchPhases
    {
        private SqlCommand command;

        public AllResearchPhases()
        {
            command = new SqlCommand() { Connection = DatabaseConstants.SqlConnection };
        }

        public ResourceManagementSystem.BusinessLogic.Entities.ResearchPhase getByPK(int phase)
        {
            int activity = -1;
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = @"select activity from researchProjectPhases where researchProject = @phase";
            command.Parameters.Clear();
            command.Parameters.Add(new SqlParameter()
            {
                Value = phase,
                ParameterName = "@phase"
            });
            SqlDataReader reader = null;
            try
            {
                command.Connection.Open();
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    activity = Convert.ToInt32(reader["activity"]);
                }
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                command.Connection.Close();
            }
            ResearchPhase rf = (ResearchPhase)new AllActivities().getbyPK(activity);
            return rf;
        }

        public void Add(int researchProject, ResearchPhase researchphases)
        {
            int activityid = -1;
            command.CommandText = @"insert into activities (type, title, description, state, startDate, endDate) values (@type, @title, @description, @state, @startdate, @enddate); select scope_identity()";
            command.Parameters.Clear();
            command.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@type",
                Value = researchphases.Type
            });
            command.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@title",
                Value = researchphases.Title
            });
            command.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@description",
                Value = researchphases.Description
            });
            command.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@state",
                Value = researchphases.State
            });
            command.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@startdate",
                Value = researchphases.StartDate
            });
            command.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@enddate",
                Value = researchphases.EndDate
            });
            try
            {
                command.Connection.Open();
                activityid = Convert.ToInt32(command.ExecuteScalar());
                command.CommandText = @"insert into researchProjectPhases (activity, researchProject) values (@activity, @research)";
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@activity",
                    Value = activityid
                });
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@research",
                    Value = researchProject
                });
                command.ExecuteNonQuery();
                foreach (ResearchActivity ra in researchphases)
                {
                    new AllResearchActivity().Add(researchProject, activityid, ra);
                }
            }
            finally
            {
                command.Connection.Close();
            }
        }


        internal ISet<ResearchPhase> getByResearchProject(ResearchProject prj, int p)
        {
            ISet<ResearchPhase> set = new HashSet<ResearchPhase>();
            int activity = -1;
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = @"select activity from researchProjectPhases where researchProject = @phase";
            command.Parameters.Clear();
            command.Parameters.Add(new SqlParameter()
            {
                Value = p,
                ParameterName = "@phase"
            });
            SqlDataReader reader = null;
            try
            {
                command.Connection.Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    activity = Convert.ToInt32(reader["activity"]);
                    ResearchPhase rf = (ResearchPhase)new AllActivities().GetResearchPhase(prj, activity);
                    set.Add(rf);
                }
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                command.Connection.Close();
            }
            return set;
        }
    }
}
