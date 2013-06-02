using ResourceManagementSystem.BusinessLogic.Entities;
using ResourceManagementSystem.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DALayer.Database
{
    public class AllResearchActivity
    {
        private SqlCommand command;

         public AllResearchActivity()
        {
            command = new SqlCommand() { Connection = DatabaseConstants.SqlConnection };
        }

        public void Add(int researchproject, int researchphase, ResourceManagementSystem.BusinessLogic.Entities.ResearchActivity researchActivity)
        {

            int activityid = -1;
            command.CommandText = @"insert into activities (type, title, description, state, startDate, endDate) values (@type, @title, @description, @state, @startdate, @enddate); select scope_identity()";
            command.Parameters.Clear();
            command.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@type",
                Value = researchActivity.Type
            });
            command.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@title",
                Value = researchActivity.Title
            });
            command.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@description",
                Value = researchActivity.Description
            });
            command.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@state",
                Value = researchActivity.State
            });
            command.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@startdate",
                Value = researchActivity.StartDate
            });
            command.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@enddate",
                Value = researchActivity.EndDate
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
                    Value = ""
                });
                int teamid = Convert.ToInt32(command.ExecuteScalar());
                foreach (Member m in researchActivity.AsEnumerable())
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
                command.CommandText = @"insert into researchActivities (activity, phase, researchProject, laborCosts, logisticalCosts, mobilityCosts, isConfidential, team) values (@activity, @phase, @researchproject, @laborcosts, @logisticalCosts, @mobilityCosts, @isconfidential, @team)";
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@activity",
                    Value = activityid
                });
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@phase",
                    Value = researchphase
                });
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@researchproject",
                    Value = researchproject
                });
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@laborcosts",
                    Value = new AllFinancialResources().AddandGetId(researchActivity.LaborCost)
                });
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@logisticalCosts",
                    Value = new AllFinancialResources().AddandGetId(researchActivity.LogisticalCost)
                });
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@mobilityCosts",
                    Value = new AllFinancialResources().AddandGetId(researchActivity.MobilityCost)
                });
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@isconfidential",
                    Value = researchActivity.IsConfidential
                });
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@team",
                    Value = teamid
                });
                command.ExecuteNonQuery();
            }
            finally
            {
                command.Connection.Close();
            }
        }
    }
}
