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
            command.CommandText = @"insert into financialResources (value, status, currency) VALUES (@value, @status, @currency)";
            command.Parameters.Clear();
            command.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@value",
                Value = financialResource.Value
            });
            command.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@currency",
                Value = financialResource.Currency
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
            command.CommandText = @"select value, status, currency from financialResources";
            command.Parameters.Clear();
            SqlDataReader reader = null;
            try
            {
                command.Connection.Open();
                reader = command.ExecuteReader();
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
                    financialResources.AddLast(new FinancialResource(Convert.ToInt32(reader["value"].ToString()), (Currency)Convert.ToInt32(reader["currency"].ToString())));
                }
            }
            return financialResources;
        }

        public FinancialResource getbyPK(int p)
        {
            LinkedList<FinancialResource> financialResources = new LinkedList<FinancialResource>();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = @"select value, status, currency from financialResources where operationId = @id";
            command.Parameters.Clear();
            command.Parameters.Add(new SqlParameter()
            {
                Value = p,
                ParameterName = "@id"
            });
            SqlDataReader reader = null;
            try
            {
                command.Connection.Open();
                reader = command.ExecuteReader();
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
            if (financialResources.Count() > 0)
                return financialResources.First();
            else
                return null;
        }

        internal int AddandGetId(FinancialResource financialResource)
        {
            int id = -1;
            command.CommandText = @"insert into financialResources (value, status, currency) VALUES (@value, @status, @currency);select scope_identity()";
            command.Parameters.Clear();
            command.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@value",
                Value = financialResource.Value
            });
            command.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@currency",
                Value = financialResource.Currency
            });
            command.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@status",
                Value = financialResource.Status
            });
            try
            {
                command.Connection.Open();
                id = Convert.ToInt32(command.ExecuteScalar());
            }
            finally
            {
                command.Connection.Close();
            }
            return id;
        }
    }
}
