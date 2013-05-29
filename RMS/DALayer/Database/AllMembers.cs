﻿using ResourceManagementSystem.BusinessLogic.Entities;
using ResourceManagementSystem.DAOInterface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ResourceManagementSystem.DataAccess.Database
{
    public class AllMembers : IAllMembers
    {
        public AllMembers()
        {
            command = new SqlCommand() { Connection = DatabaseConstants.Connection };
        }

        public void Add(Director director)
        {
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = @"insert into Members(type, name, email, password)
                                        values (@type, @name, @email, @password)";
            command.Parameters.Clear();
            command.Parameters.Add(new SqlParameter("@type", System.Data.SqlDbType.Int) { Value = (int)director.Type });
            command.Parameters.Add(new SqlParameter("@name", System.Data.SqlDbType.VarChar, 100) { Value = director.Name });
            command.Parameters.Add(new SqlParameter("@email", System.Data.SqlDbType.VarChar, 100) { Value = director.EMail });
            command.Parameters.Add(new SqlParameter("@password", System.Data.SqlDbType.VarChar, 100) { Value = director.Password });
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

        public void Add(Administrator administrator)
        {
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = @"insert into Members(type, name, email, password)
                                        values (@type, @name, @email, @password)";
            command.Parameters.Clear();
            command.Parameters.Add(new SqlParameter("@type", System.Data.SqlDbType.Int) { Value = (int)administrator.Type });
            command.Parameters.Add(new SqlParameter("@name", System.Data.SqlDbType.VarChar, 100) { Value = administrator.Name });
            command.Parameters.Add(new SqlParameter("@email", System.Data.SqlDbType.VarChar, 100) { Value = administrator.EMail });
            command.Parameters.Add(new SqlParameter("@password", System.Data.SqlDbType.VarChar, 100) { Value = administrator.Password });
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

        public void Add(Teacher teacher)
        {
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = @"insert into Members(type, name, email, password,
                                                        teachingPosition, hasPhD,
                                                        telephone, website, address, domainsOfInterest)
                                        values (@type, @name, @email, @password,
                                                @teachingPosition, @hasPhD, @telephone, @website, @address, @domainsOfInterest)";
            command.Parameters.Clear();
            command.Parameters.Add(new SqlParameter("@type", System.Data.SqlDbType.Int) { Value = (int)teacher.Type });
            command.Parameters.Add(new SqlParameter("@name", System.Data.SqlDbType.VarChar, 100) { Value = teacher.Name });
            command.Parameters.Add(new SqlParameter("@email", System.Data.SqlDbType.VarChar, 100) { Value = teacher.EMail });
            command.Parameters.Add(new SqlParameter("@password", System.Data.SqlDbType.VarChar, 100) { Value = teacher.Password });
            command.Parameters.Add(new SqlParameter("@teachingPosition", System.Data.SqlDbType.Int) { Value = (int)teacher.Position });
            command.Parameters.Add(new SqlParameter("@hasPhD", System.Data.SqlDbType.Bit) { Value = teacher.HasPhD });
            command.Parameters.Add(new SqlParameter("@telephone", System.Data.SqlDbType.VarChar, 20) { Value = teacher.Telephone });
            command.Parameters.Add(new SqlParameter("@website", System.Data.SqlDbType.VarChar, 200) { Value = teacher.Website });
            command.Parameters.Add(new SqlParameter("@address", System.Data.SqlDbType.VarChar, int.MaxValue) { Value = teacher.Address });
            command.Parameters.Add(new SqlParameter("@domainsOfInterest", System.Data.SqlDbType.VarChar, int.MaxValue) { Value = teacher.DomainsOfInterest });
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

        public void Add(PhDStudent phDStudent)
        {
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = @"insert into Members(type, name, email, password,
                                                        telephone, website, address, domainsOfInterest)
                                        values (@type, @name, @email, @password,
                                                @telephone, @website, @address, @domainsOfInterest)";
            command.Parameters.Clear();
            command.Parameters.Add(new SqlParameter("@type", System.Data.SqlDbType.Int) { Value = (int)phDStudent.Type });
            command.Parameters.Add(new SqlParameter("@name", System.Data.SqlDbType.VarChar, 100) { Value = phDStudent.Name });
            command.Parameters.Add(new SqlParameter("@email", System.Data.SqlDbType.VarChar, 100) { Value = phDStudent.EMail });
            command.Parameters.Add(new SqlParameter("@password", System.Data.SqlDbType.VarChar, 100) { Value = phDStudent.Password });
            command.Parameters.Add(new SqlParameter("@telephone", System.Data.SqlDbType.VarChar, 20) { Value = phDStudent.Telephone });
            command.Parameters.Add(new SqlParameter("@website", System.Data.SqlDbType.VarChar, 200) { Value = phDStudent.Website });
            command.Parameters.Add(new SqlParameter("@address", System.Data.SqlDbType.VarChar, int.MaxValue) { Value = phDStudent.Address });
            command.Parameters.Add(new SqlParameter("@domainsOfInterest", System.Data.SqlDbType.VarChar, int.MaxValue) { Value = phDStudent.DomainsOfInterest });
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

        public IEnumerable<Member> AsEnumerable
        {
            get
            {
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = @"select type, name, email, password, teachingPosition, hasPhD, telephone, website, address, domainsOfInterest
                                            from Members";
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                IEnumerable<Member> members = ReadMembers(reader);
                reader.Close();
                return members;
            }
        }

        private IEnumerable<Member> ReadMembers(SqlDataReader dataReader)
        {
            LinkedList<Member> members = new LinkedList<Member>();
            while (dataReader.Read())
                switch (((MemberType)Convert.ToInt32(dataReader["type"])))
                {
                    case MemberType.Director:
                        members.AddLast(
                            new Director(
                                dataReader["name"].ToString(),
                                dataReader["email"].ToString(),
                                dataReader["password"].ToString()
                            )
                        );
                        break;
                    case MemberType.Administrator:
                        members.AddLast(
                            new Administrator(
                                dataReader["name"].ToString(),
                                dataReader["email"].ToString(),
                                dataReader["password"].ToString()
                            )
                        );
                        break;
                    case MemberType.Teacher:
                        members.AddLast(
                            new Teacher(
                                (TeachingPosition)Convert.ToInt32(dataReader["teachingPosition"]),
                                dataReader["name"].ToString(),
                                dataReader["email"].ToString(),
                                dataReader["password"].ToString(),
                                Convert.ToBoolean(dataReader["hasPhD"]),
                                dataReader["address"].ToString(),
                                dataReader["telephone"].ToString(),
                                dataReader["website"].ToString(),
                                dataReader["domainsOfInterest"].ToString()
                            )
                        );
                        break;
                    case MemberType.PhD_Student:
                        members.AddLast(
                            new PhDStudent(
                                dataReader["name"].ToString(),
                                dataReader["email"].ToString(),
                                dataReader["password"].ToString(),
                                dataReader["address"].ToString(),
                                dataReader["telephone"].ToString(),
                                dataReader["website"].ToString(),
                                dataReader["domainsOfInterest"].ToString()
                            )
                        );
                        break;
                    default:
                        break;
                }
            return members;
        }

        private SqlCommand command;
    }
}
