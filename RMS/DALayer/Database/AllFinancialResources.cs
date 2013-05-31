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
    public class AllFinancialResources : IAllFinancialResources
    {
        private SqlCommand command;

        
        public AllFinancialResources()
        {
            command = new SqlCommand() { Connection = DatabaseConstants.SqlConnection };
        }

        public void Add(FinancialResource financialResource)
        {
            command.CommandText = @"insert into financialResources (value, status) VALUES (@value, @status)";
            command.Parameters.Clear();
            command.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@value",
                Value = financialResource.Value
            });
            command.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@status",
                Value = financialResource.Status
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

        public IEnumerable<FinancialResource> AsEnumerable
        {
            get { return getAll(); }
        }

        private LinkedList<FinancialResource> getAll()
        {
            LinkedList<FinancialResource> financialResources = new LinkedList<FinancialResource>();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = @"select value, status from financialResources";
            command.Parameters.Clear();
            SqlDataReader reader = null;
            try
            {
                command.Connection.Open();
                reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                financialResources = ReadFinancialResources(reader);
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                command.Connection.Close();
            }
            return financialResources;
        }

        private LinkedList<FinancialResource> ReadFinancialResources(SqlDataReader reader)
        {
            LinkedList<FinancialResource> financialResources = new LinkedList<FinancialResource>();
            if (reader != null)
            {
                while (reader.Read())
                {
                    financialResources.AddLast(new FinancialResource(Convert.ToInt32(reader["value"].ToString()), Currency.RON));
                }
            }
            return financialResources;
        }
    }
}
