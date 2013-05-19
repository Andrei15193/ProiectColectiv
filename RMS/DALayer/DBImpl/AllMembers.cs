using ResourceManagementSystem.BusinessLogic.Entities;
using ResourceManagementSystem.DataAccess.DAOInterface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALayer.DBImpl
{
    public class AllMembers : IAllMembers
    {
        public Member Where(string email, string password)
        {
            DBConnection.GetConnection().Open();
            SqlCommand cmd = new SqlCommand(@"select u.firstname, u.lastname, u.email, u.passwd, r.name, r.roleDescription
                                            from (select * from Users as us where us.email =@e and us.passwd = @p) as u 
                                    		left join UsersRoles as ur on u.email = ur.email 
		                                    left join Roles as r on ur.roleName = r.name", DBConnection.GetConnection());
            cmd.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@e",
                Value = email
            });
            cmd.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@p",
                Value = password
            });
            SqlDataReader dr = cmd.ExecuteReader();
            String role = null;
            String roleDescription = null;
            String firstname = null;
            String lastname = null;
            String mail = null;
            String passwd = null;
            Member member = null;
            if (dr.Read())
            {
                if (!dr.IsDBNull(0))
                {
                    firstname = dr.GetString(0);
                }
                if (!dr.IsDBNull(1))
                {
                    lastname = dr.GetString(1);
                }
                if (!dr.IsDBNull(2))
                {
                    mail = dr.GetString(2);
                }
                if (!dr.IsDBNull(3))
                {
                    passwd = dr.GetString(3);
                }
                if (!dr.IsDBNull(4))
                {
                    role = dr.GetString(4);
                }
                if (!dr.IsDBNull(5))
                {
                    roleDescription = dr.GetString(5);
                }
            }
            else
            {
                dr.Close();
                DBConnection.GetConnection().Close();
                throw new Exception("No user found!");
            }
            dr.Close();
            List<Feature> features = new List<Feature>();
            if (role != null)
            {
                cmd = new SqlCommand(@"select f.name as FeatureName, f.featureDescription as FeatureDescription from (select * from roles as ro where ro.name = @n)  as r inner join RoleFeatures as rf
		                            on rf.roleName = r.name inner join features as f on f.name = rf.featureName", DBConnection.GetConnection());
                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@n",
                    Value = role
                });
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    if (!dr.IsDBNull(0) && !dr.IsDBNull(1))
                    {
                        features.Add(new Feature(dr.GetString(0), dr.GetString(1)));
                    }
                }
            }
            member = new Member(new Role(role, roleDescription, features), firstname, lastname, mail, passwd);
            dr.Close();
            DBConnection.GetConnection().Close();
            return member;
        }
    }
}
