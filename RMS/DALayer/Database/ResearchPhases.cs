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
    }
}
