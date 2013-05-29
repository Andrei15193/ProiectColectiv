//using ResourceManagementSystem.BusinessLogic.Entities;
//using ResourceManagementSystem.DataAccess.DAOInterface;
//using System;
//using System.Collections.Generic;
//using System.Data.SqlClient;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace DALayer.DBImpl
//{
//    public class HumanResources : IHumanResources
//    {
//        public bool addMember(ResourceManagementSystem.BusinessLogic.Entities.Member member)
//        {
//            DBConnection dbConnection = new DBConnection();
//            dbConnection.Connection.Open();

//            SqlCommand cmd = new SqlCommand(@"insert into users Values(@username, @firstname, @lastname, @passwd, @email)", dbConnection.Connection);
//            cmd.Parameters.Add(new SqlParameter()
//            {
//                ParameterName = "@username",
//                Value = "username"
//            });
//            cmd.Parameters.Add(new SqlParameter()
//            {
//                ParameterName = "@firstname",
//                Value = member.FirstName
//            });
//            cmd.Parameters.Add(new SqlParameter()
//            {
//                ParameterName = "@lastname",
//                Value = member.LastName
//            });
//            cmd.Parameters.Add(new SqlParameter()
//            {
//                ParameterName = "@passwd",
//                Value = member.Password
//            });
//            cmd.Parameters.Add(new SqlParameter()
//            {
//                ParameterName = "@email",
//                Value = member.EMail
//            });
//            cmd.ExecuteNonQuery();
//            for (int i = 0; i < member.Roles.Count; i++)
//            {
//                cmd = new SqlCommand(@"insert into UsersRoles Values(@email, @roleName)", dbConnection.Connection);
//                cmd.Parameters.Add(new SqlParameter()
//                {
//                    ParameterName = "@roleName",
//                    Value = member.Roles.ElementAt(i).Name
//                });
//                cmd.Parameters.Add(new SqlParameter()
//                {
//                    ParameterName = "@email",
//                    Value = member.EMail
//                });
//                cmd.ExecuteNonQuery();
//            }
//            for (int i = 0; i < member.Tasks.Count; i++)
//            {
//                int? id = new Tasks().GetTaksIdByTask(member.Tasks.ElementAt(i));
//                if (id == null)
//                {
//                    new Tasks().AddTask(member.Tasks.ElementAt(i));
//                    id = new Tasks().GetTaksIdByTask(member.Tasks.ElementAt(i));
//                }

//                cmd = new SqlCommand(@"insert into UsersTasks Values(@email, @taskId)", dbConnection.Connection);
//                cmd.Parameters.Add(new SqlParameter()
//                {
//                    ParameterName = "@taskId",
//                    Value = id
//                });
//                cmd.Parameters.Add(new SqlParameter()
//                {
//                    ParameterName = "@email",
//                    Value = member.EMail
//                });
//                cmd.ExecuteNonQuery();
//            }
//            dbConnection.Connection.Close();
//            return true;
//        }

//        public bool updateMember(string email, ResourceManagementSystem.BusinessLogic.Entities.Member newMember)
//        {
//            DBConnection dbConnection = new DBConnection();
//            dbConnection.Connection.Open();

//            SqlCommand cmd = new SqlCommand(@"update users set firstname = @firstname, lastname = @lastname, passwd = @passwd, email = @email where email = @oldemail", dbConnection.Connection);
//            cmd.Parameters.Add(new SqlParameter()
//            {
//                ParameterName = "@firstname",
//                Value = newMember.FirstName
//            });
//            cmd.Parameters.Add(new SqlParameter()
//            {
//                ParameterName = "@lastname",
//                Value = newMember.LastName
//            });
//            cmd.Parameters.Add(new SqlParameter()
//            {
//                ParameterName = "@passwd",
//                Value = newMember.Password
//            });
//            cmd.Parameters.Add(new SqlParameter()
//            {
//                ParameterName = "@email",
//                Value = newMember.EMail
//            });
//            cmd.Parameters.Add(new SqlParameter()
//            {
//                ParameterName = "@oldemail",
//                Value = email
//            });

//            cmd.ExecuteNonQuery();
//            cmd = new SqlCommand(@"delete from UsersRoles where email = @email", dbConnection.Connection);
//            cmd.Parameters.Add(new SqlParameter()
//            {
//                ParameterName = "@email",
//                Value = email
//            });
//            cmd.ExecuteNonQuery();
//            for (int i = 0; i < newMember.Roles.Count; i++)
//            {
//                cmd = new SqlCommand(@"insert into UsersRoles Values(@email, @roleName)", dbConnection.Connection);
//                cmd.Parameters.Add(new SqlParameter()
//                {
//                    ParameterName = "@roleName",
//                    Value = newMember.Roles.ElementAt(i).Name
//                });
//                cmd.Parameters.Add(new SqlParameter()
//                {
//                    ParameterName = "@email",
//                    Value = newMember.EMail
//                });
//                cmd.ExecuteNonQuery();
//            }
//            cmd = new SqlCommand(@"delete from UsersTasks where email = @email", dbConnection.Connection);
//            cmd.Parameters.Add(new SqlParameter()
//            {
//                ParameterName = "@email",
//                Value = email
//            });
//            cmd.ExecuteNonQuery();
//            for (int i = 0; i < newMember.Tasks.Count; i++)
//            {
//                int? id = new Tasks().GetTaksIdByTask(newMember.Tasks.ElementAt(i));
//                if (id == null)
//                {
//                    new Tasks().AddTask(newMember.Tasks.ElementAt(i));
//                    id = new Tasks().GetTaksIdByTask(newMember.Tasks.ElementAt(i));
//                }

//                cmd = new SqlCommand(@"insert into UsersTasks Values(@email, @taskId)", dbConnection.Connection);
//                cmd.Parameters.Add(new SqlParameter()
//                {
//                    ParameterName = "@taskId",
//                    Value = id
//                });
//                cmd.Parameters.Add(new SqlParameter()
//                {
//                    ParameterName = "@email",
//                    Value = newMember.EMail
//                });
//                cmd.ExecuteNonQuery();
//            }
//            dbConnection.Connection.Close();
//            return true;
//        }

//        public bool deleteMember(string email)
//        {
//            DBConnection dbConnection = new DBConnection();
//            dbConnection.Connection.Open();

//            SqlCommand cmd = new SqlCommand(@"delete from UsersRoles where email = @email", dbConnection.Connection);
//            cmd.Parameters.Add(new SqlParameter()
//            {
//                ParameterName = "@email",
//                Value = email
//            });
//            cmd.ExecuteNonQuery();
//            cmd = new SqlCommand(@"delete from UsersTasks where email = @email", dbConnection.Connection);
//            cmd.Parameters.Add(new SqlParameter()
//            {
//                ParameterName = "@email",
//                Value = email
//            });
//            cmd.ExecuteNonQuery();
//            cmd = new SqlCommand(@"delete from users where email = @email", dbConnection.Connection);
//            cmd.Parameters.Add(new SqlParameter()
//            {
//                ParameterName = "@email",
//                Value = email
//            });
//            cmd.ExecuteNonQuery();
//            dbConnection.Connection.Close();
//            return true;
//        }
//    }
//}
