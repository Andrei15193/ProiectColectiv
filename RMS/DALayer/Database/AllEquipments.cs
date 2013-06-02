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
    public class AllEquipments : IAllEquipments
    {
        private SqlCommand command;

        public AllEquipments()
        {
            command = new SqlCommand() { Connection = DatabaseConstants.SqlConnection };
        }

        public void Add(Equipment equipment)
        {
            command.CommandText = @"insert into Equipments (brand, model, serialNumber, description) values (@brand, @model, @serial, @description)";
            command.Parameters.Clear();
            command.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@brand",
                Value = equipment.Brand
            });
            command.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@model",
                Value = equipment.Model
            });
            command.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@serial",
                Value = equipment.SerialNumber
            });
            command.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@description",
                Value = equipment.Description
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

        public IEnumerable<Equipment> AsEnumerable
        {
            get { return getAll(); }
        }


        private LinkedList<Equipment> getAll()
        {
            LinkedList<Equipment> equipments = new LinkedList<Equipment>();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = @"select brand, model, serialNumber, description from equipments";
            command.Parameters.Clear();
            SqlDataReader reader = null;
            try
            {
                command.Connection.Open();
                reader = command.ExecuteReader();
                equipments = ReadEquipments(reader);
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                command.Connection.Close();
            }
            return equipments;
        }

        private LinkedList<Equipment> ReadEquipments(SqlDataReader reader)
        {
            LinkedList<Equipment> equipments = new LinkedList<Equipment>();
            if (reader != null)
            {
                while (reader.Read())
                {
                    equipments.AddLast(new Equipment(reader["brand"].ToString(), reader["model"].ToString(), reader["serialNumber"].ToString(), reader["description"].ToString()));
                }
            }
            return equipments;
        }

        internal ICollection<Equipment> getByActivity(int activity)
        {

            LinkedList<Equipment> equipments = new LinkedList<Equipment>();
            SqlCommand cmd = new SqlCommand("select equipment from activityequipments where activity = @activity", DatabaseConstants.SqlConnection);
            cmd.Parameters.Add(new SqlParameter()
            {
                Value = activity,
                ParameterName = "@activity"
            });
            cmd.Connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = @"select brand, model, serialNumber, description from equipments where serialNumer = @sn";
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter()
                {
                    Value = dr["equipment"],
                    ParameterName = "@sn"
                });
                SqlDataReader reader = null;
                try
                {
                    command.Connection.Open();
                    reader = command.ExecuteReader();
                    equipments.AddLast(ReadEquipments(reader).First);
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
            dr.Close();
            cmd.Connection.Close();
            return equipments;
        }
    }
}
