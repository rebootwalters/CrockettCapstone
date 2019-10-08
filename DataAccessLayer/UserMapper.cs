using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    class UserMapper : Mapper
    {
        int OffsetToUserID;
        int OffsetToEMail;
        int OffsetToHash;
        int OffsetToSalt;
        int OffsetToRoleID;
        int OffsetToRoleName;

        public UserMapper(SqlDataReader reader)
        {
            OffsetToUserID = reader.GetOrdinal("UserID");
            OffsetToEMail = reader.GetOrdinal("EMail");
            OffsetToHash = reader.GetOrdinal("Hash");
            OffsetToSalt = reader.GetOrdinal("Salt");
            OffsetToRoleID = reader.GetOrdinal("RoleID");
            OffsetToRoleName = reader.GetOrdinal("RoleName");

            Assert(OffsetToUserID== 0, "OffsetToUserID Is {OffsetToUserID} not 0 as expected");
            Assert(OffsetToEMail== 1, "OffsetToEMail Is {OffsetToEMail} not 1 as expected");
            Assert(OffsetToHash== 2, "OffsetToHas Is {OffsetToHas} not 2 as expected");
            Assert(OffsetToSalt== 3, "OffsetToSalt Is {OffsetToSalt} not 3 as expected");
            Assert(OffsetToRoleID== 4, "OffsetToRoleID Is {OffsetToRoleID} not 4 as expected");
        Assert(OffsetToRoleName== 5, "OffsetToRoleName Is {OffsetToRoleName} not 5 as expected");
        }

        public UserDAL ToUser(SqlDataReader reader)
        {
            UserDAL proposedRV = new UserDAL();

            proposedRV.UserID = reader.GetInt32(OffsetToUserID);
            proposedRV.EMail = reader.GetString(OffsetToEMail);
            proposedRV.Hash = reader.GetString(OffsetToHash);
            proposedRV.Salt = reader.GetString(OffsetToSalt);
            proposedRV.RoleID = reader.GetInt32(OffsetToRoleID);
            proposedRV.RoleName = reader.GetString(OffsetToRoleName);

            return proposedRV;
        }
    }
}
