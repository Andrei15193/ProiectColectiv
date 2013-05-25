using ResourceManagementSystem.DataAccess.DAOInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DAOInterface.DAExceptions;
using ResourceManagementSystem.BusinessLogic.Entities;

namespace DALayer.DBImpl
{
    public class FinancialResources : IFinancialResources
    {
        public bool AddFinancialResource(ResourceManagementSystem.BusinessLogic.Entities.FinancialResource fr)
        {
            if (fr == null)
            {
                throw new ArgumentNullException("Financial resource parameter null!");
            }

            DBConnection dbConnection = new DBConnection();
            try
            {
                dbConnection.Connection.Open();

                SqlCommand cmd = new SqlCommand("insert into FinancialResource (value, currency) VALUES (@value, @currency)", dbConnection.Connection);

                cmd.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@value",
                    Value = Convert.ToInt32(fr.Value)
                });

                cmd.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@currency",
                    Value = Convert.ToInt32(fr.Currency)
                });

                cmd.ExecuteNonQuery();

                dbConnection.Connection.Close();
            }
            catch (SqlException e)
            {
                if (dbConnection.Connection.State == System.Data.ConnectionState.Open)
                {
                    dbConnection.Connection.Close();
                }

                throw new DataBaseException("Insert fail!", e);
            }

            return true;
        }

        public IEnumerable<ResourceManagementSystem.BusinessLogic.Entities.FinancialResource> All
        {
            get {
                List<FinancialResource> financialResources = new List<FinancialResource>();

                DBConnection dbConnection = new DBConnection();
                try
                {
                    dbConnection.Connection.Open();

                    SqlCommand cmd = new SqlCommand("select value, currency from FinancialResource", dbConnection.Connection);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        int value;
                        int currency;

                        if (dr.IsDBNull(0) || dr.IsDBNull(1))
                        {
                            continue;
                        }

                        value = dr.GetInt32(0);
                        currency = dr.GetInt32(1);                        

                        FinancialResource fr = new FinancialResource(Convert.ToUInt32(value), (Currency)currency);

                        financialResources.Add(fr);
                    }

                    dbConnection.Connection.Close();
                }
                catch (SqlException e)
                {
                    if (dbConnection.Connection.State == System.Data.ConnectionState.Open)
                    {
                        dbConnection.Connection.Close();
                    }

                    throw new DataBaseException("Fetch fail!", e);
                }

                return financialResources;
            }
        }
    }
}
