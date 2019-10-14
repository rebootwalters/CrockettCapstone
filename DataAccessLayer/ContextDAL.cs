using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class ContextDAL : IDisposable 
    {
        #region Context stuff
        SqlConnection _con = new SqlConnection();

        public void Dispose()
        {
            _con.Dispose();
        }

        void EnsureConnected()
        {
            switch(_con.State)
            {
                case (System.Data.ConnectionState.Closed):
                    _con.Open();
                    break;
                case (System.Data.ConnectionState.Broken):
                    _con.Close();
                    _con.Open();
                    break;
                case (System.Data.ConnectionState.Open):
                    // dont need to do anything since it is already open
                    break;


            }
        }

        public string ConnectionString
        {
            get
            {
                return _con.ConnectionString;
            }
            set
            {
                _con.ConnectionString = value;
            }
        }
        #endregion context stuff

        #region role stuff
        public RoleDAL RoleFindByID(int RoleID)
        {
            RoleDAL proposedReturnValue = null;
            EnsureConnected();
            using (SqlCommand command = new SqlCommand("RoleFindByID",_con))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@RoleID", RoleID);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    RoleMapper rm = new RoleMapper(reader);
                    int count=0;
                    while(reader.Read())
                    {
                        proposedReturnValue = rm.ToRole(reader);
                        count++;
                    }
                    if (count > 1)
                    {
                        throw new Exception($"{count} Multiple Roles found for ID {RoleID}");
                    }

                }
            }
            return proposedReturnValue;
        }

        public List<RoleDAL> RoleGetAll(int Skip, int Take)
        {
            List<RoleDAL> proposedReturnValue = new List<RoleDAL>();
            EnsureConnected();
            using (SqlCommand command = new SqlCommand("RolesGetAll", _con))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@skip", Skip);
                command.Parameters.AddWithValue("@take", Take);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    RoleMapper rm = new RoleMapper(reader);
                    
                    while (reader.Read())
                    {
                        RoleDAL item = rm.ToRole(reader);
                        proposedReturnValue.Add(item);
                       
                    }
                 }
            }
            return proposedReturnValue;
        }

        public int RolesObtainCount()
        {
            int proposedReturnValue = 0;
            EnsureConnected();
            using (SqlCommand command = new SqlCommand("RolesObtainCount", _con))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;

                proposedReturnValue = (int) command.ExecuteScalar();
            }
            return proposedReturnValue;
        }


        // returns the new id in an output parameter
        public int RoleCreate(string RoleName)
        {
            int proposedReturnValue = 0;
            EnsureConnected();
            using (SqlCommand command = new SqlCommand("RoleCreate", _con))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@RoleName", RoleName);
                command.Parameters.AddWithValue("@RoleID", 0);
                command.Parameters["@RoleID"].Direction = System.Data.ParameterDirection.Output;
                command.ExecuteNonQuery();
                proposedReturnValue = (int)command.Parameters["@RoleID"].Value;
            }
            return proposedReturnValue;
        }

        // returns the new id as a scaler
        public int RoleCreateIDReturned(string RoleName)
        {
            int proposedReturnValue = 0;
            EnsureConnected();
            using (SqlCommand command = new SqlCommand("RoleCreateIDReturned", _con))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@RoleName", RoleName);
                object itemReturned = command.ExecuteScalar();

                proposedReturnValue = Convert.ToInt32(itemReturned);
            }
            return proposedReturnValue;
        }

        public void RoleDelete(int RoleID)
        {
           
            EnsureConnected();
            using (SqlCommand command = new SqlCommand("RoleDelete", _con))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@RoleID", RoleID);
                command.ExecuteNonQuery();
                
     
            }
           
        }

        public void RoleUpdateJust(int RoleID, string RoleName)
        {

            EnsureConnected();
            using (SqlCommand command = new SqlCommand("RoleUpdateJust", _con))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@RoleID", RoleID);
                command.Parameters.AddWithValue("@RoleName", RoleName);
                object datareturned = command.ExecuteNonQuery();


            }

        }

        public int RoleUpdateSafe(int RoleID, string OldRoleName, string NewRoleName)
        {

            EnsureConnected();
            using (SqlCommand command = new SqlCommand("RoleUpdateSafe", _con))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@RoleID", RoleID);
                command.Parameters.AddWithValue("@OldRoleName", OldRoleName);
                command.Parameters.AddWithValue("@NewRoleName", NewRoleName);
                return  command.ExecuteNonQuery();


            }

        }

        #endregion role stuff

        #region user stuff
        public UserDAL UserFindByID(int UserID)
        {
            UserDAL proposedReturnValue = null;
            EnsureConnected();
            using (SqlCommand command = new SqlCommand("UserFindByID", _con))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UserID", UserID);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    UserMapper rm = new UserMapper(reader);
                    int count = 0;
                    while (reader.Read())
                    {
                        proposedReturnValue = rm.ToUser(reader);
                        count++;
                    }
                    if (count > 1)
                    {
                        throw new Exception($"{count} Multiple Users found for ID {UserID}");
                    }

                }
            }
            return proposedReturnValue;
        }
        public List<UserDAL> UserGetAll(int Skip, int Take)
        {
            List<UserDAL> proposedReturnValue = new List<UserDAL>();
            EnsureConnected();
            using (SqlCommand command = new SqlCommand("UsersGetAll", _con))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@skip", Skip);
                command.Parameters.AddWithValue("@take", Take);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    UserMapper rm = new UserMapper(reader);

                    while (reader.Read())
                    {
                        UserDAL item = rm.ToUser(reader);
                        proposedReturnValue.Add(item);

                    }
                }
            }
            return proposedReturnValue;
        }
        public List<UserDAL> UserGetRelatedToRoleID(int RoleID,int Skip, int Take)
        {
            List<UserDAL> proposedReturnValue = new List<UserDAL>();
            EnsureConnected();
            using (SqlCommand command = new SqlCommand("UsersGetRelatedToRoleID", _con))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@skip", Skip);
                command.Parameters.AddWithValue("@take", Take);
                command.Parameters.AddWithValue("@RoleID", RoleID);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    UserMapper rm = new UserMapper(reader);

                    while (reader.Read())
                    {
                        UserDAL item = rm.ToUser(reader);
                        proposedReturnValue.Add(item);

                    }
                }
            }
            return proposedReturnValue;
        }
        public int UsersObtainCount()
        {
            int proposedReturnValue = 0;
            EnsureConnected();
            using (SqlCommand command = new SqlCommand("UsersObtainCount", _con))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;

                proposedReturnValue = (int)command.ExecuteScalar();
            }
            return proposedReturnValue;
        }
        // returns the new id in an output parameter
        public int UserCreate(string EMail, string Hash, string Salt, int RoleID)
        {
            int proposedReturnValue = 0;
            EnsureConnected();
            using (SqlCommand command = new SqlCommand("UserCreate", _con))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UserID", 0);
                command.Parameters.AddWithValue("@Hash", Hash);
                command.Parameters.AddWithValue("@Salt", Salt);
                command.Parameters.AddWithValue("@RoleID", RoleID);
                command.Parameters.AddWithValue("@EMail", EMail);
                command.Parameters["@UserID"].Direction = System.Data.ParameterDirection.Output;
                command.ExecuteNonQuery();
                proposedReturnValue = (int)command.Parameters["@UserID"].Value;
            }
            return proposedReturnValue;
        }
        // returns the new id as a scaler
        public int UserCreateIDReturned(string EMail, string Hash, string Salt, int RoleID)
        {
            int proposedReturnValue = 0;
            EnsureConnected();
            using (SqlCommand command = new SqlCommand("UserCreateIDReturned", _con))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Hash", Hash);
                command.Parameters.AddWithValue("@Salt", Salt);
                command.Parameters.AddWithValue("@RoleID", RoleID);
                command.Parameters.AddWithValue("@EMail", EMail);

                proposedReturnValue = Convert.ToInt32(command.ExecuteScalar());
            }
            return proposedReturnValue;
        }
        public void UserDelete(int UserID)
        {

            EnsureConnected();
            using (SqlCommand command = new SqlCommand("UserDelete", _con))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UserID", UserID);
                command.ExecuteNonQuery();


            }

        }
        public void UserUpdateJust(int UserID, string EMail, string Hash, string Salt, int RoleID)
        {

            EnsureConnected();
            using (SqlCommand command = new SqlCommand("UserUpdateJust", _con))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UserID", UserID);
                command.Parameters.AddWithValue("@Hash", Hash);
                command.Parameters.AddWithValue("@Salt", Salt);
                command.Parameters.AddWithValue("@RoleID", RoleID);
                command.Parameters.AddWithValue("@EMail", EMail);
                object datareturned = command.ExecuteNonQuery();


            }

        }
        public int UserUpdateSafe(int UserID, 
            string OldEMail, string OldHash, string OldSalt, int OldRoleID, 
            string NewEMail, string NewHash, string NewSalt, int NewRoleID)
        {

            EnsureConnected();
            using (SqlCommand command = new SqlCommand("UserUpdateSafe", _con))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UserID", UserID);
                command.Parameters.AddWithValue("@OldHash", OldHash);
                command.Parameters.AddWithValue("@OldSalt", OldSalt);
                command.Parameters.AddWithValue("@OldRoleID", OldRoleID);
                command.Parameters.AddWithValue("@OldEMail", OldEMail);
                command.Parameters.AddWithValue("@NewHash", NewHash);
                command.Parameters.AddWithValue("@NewSalt", NewSalt);
                command.Parameters.AddWithValue("@NewRoleID", NewRoleID);
                command.Parameters.AddWithValue("@NewEMail", NewEMail);
                return command.ExecuteNonQuery();


            }

        }
        #endregion


    }
}
