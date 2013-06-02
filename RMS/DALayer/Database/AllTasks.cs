using ResourceManagementSystem.BusinessLogic.Entities;
using ResourceManagementSystem.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DALayer.Database
{
    public class AllTasks
    {
        private SqlCommand command;
        public AllTasks()
        {
            command = new SqlCommand() { Connection = DatabaseConstants.SqlConnection };
        }

        public void Add(int act, ResourceManagementSystem.BusinessLogic.Entities.Task t)
        {
            int activityid = -1;
            int teamid = -1;
            command.Connection.Open();
            command.CommandText = @"insert into teams(name) values (@name); select scope_identity()";
            command.Parameters.Clear();
            command.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@name",
                Value = ""
            });
            teamid = Convert.ToInt32(command.ExecuteScalar());
            foreach (Member m in t.AsEnumerable())
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

            command.CommandText = @"insert into tasks (activity, team, type, title, description, startDate, endDate, state, laborCosts, mobilityCosts) values 
            (@activity, @team, @type, @title, @description, @startDate, @endDate, @state, @laborCosts, @logisticalCosts, @mobilityCosts); select scope_identity()";
            command.Parameters.Clear();
            command.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@laborCosts",
                Value = new AllFinancialResources().AddandGetId(t.LaborCost)
            });
            command.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@logisticalCosts",
                Value = new AllFinancialResources().AddandGetId(t.LogisticalCost)
            });
            command.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@mobilityCosts",
                Value = new AllFinancialResources().AddandGetId(t.MobilityCost)
            });
            command.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@activity",
                Value = act
            });
            command.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@team",
                Value = teamid
            });
            command.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@type",
                Value = (int)t.Type
            });
            command.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@title",
                Value = t.Title
            });
            command.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@description",
                Value = t.Description
            });
            command.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@state",
                Value = (int)t.State
            });
            command.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@startDate",
                Value = t.StartDate
            });
            command.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@endDate",
                Value = t.EndDate
            });
            try
            {
                int taskid = Convert.ToInt32(command.ExecuteScalar());
                foreach (ClassRoom c in t.ClassRooms)
                {
                    command.CommandText = @"insert into taskClassRooms(classRoom, task) values (@classroom, @activity)";
                    command.Parameters.Clear();
                    command.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@activity",
                        Value = taskid
                    });
                    command.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@classroom",
                        Value = c.Name
                    });
                    command.ExecuteNonQuery();
                }
                foreach (Equipment eq in t.Equipments)
                {
                    command.CommandText = @"insert into taskEquipments(equipment, task) values (@equipment, @activity)";
                    command.Parameters.Clear();
                    command.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@activity",
                        Value = taskid
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

        internal ISet<Task> getByBreakdownActivity(object p)
        {
            throw new NotImplementedException();
        }
    }
}
