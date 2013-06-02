using ResourceManagementSystem.BusinessLogic.Entities;
using ResourceManagementSystem.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DALayer.Database
{
    class AllTaskBreakDownActivities
    {
        private SqlCommand command;
        public AllTaskBreakDownActivities()
        {
            command = new SqlCommand() { Connection = DatabaseConstants.SqlConnection };
        }

        public void Add(int administrativeactivities, ResourceManagementSystem.BusinessLogic.Entities.TaskBreakdownActivity tb)
        {
            int activityid = -1;
            command.CommandText = @"insert into activities (type, title, description, state, startDate, endDate) values (@type, @title, @description, @state, @startdate, @enddate); select scope_identity()";
            command.Parameters.Clear();
            command.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@type",
                Value = tb.Type
            });
            command.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@title",
                Value = tb.Title
            });
            command.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@description",
                Value = tb.Description
            });
            command.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@state",
                Value = tb.State
            });
            command.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@startdate",
                Value = tb.StartDate
            });
            command.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@enddate",
                Value = tb.EndDate
            });
            try
            {
                command.Connection.Open();
                activityid = Convert.ToInt32(command.ExecuteScalar());
                foreach (Task t in tb)
                {
                    new AllTasks().Add(activityid, t);
                }
            }
            finally
            {
                command.Connection.Close();
            }
        }

        internal ICollection<TaskBreakdownActivity> GetbyAdministrativeActivity(int p)
        {
            throw new NotImplementedException();
        }
    }
}
