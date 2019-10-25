using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BusinessLogicLayer
{
    public class UserBLL
    {
        public int UserID { get; set; }
        public string EMail { get; set; }
        public string Hash { get; set; }
        public string Salt { get; set; }
        public int RoleID { get; set; }
        public string RoleName { get; set; }

        public UserBLL(DataAccessLayer.UserDAL user)
        {
            UserID = user.UserID;
            EMail = user.EMail;
            Hash = user.Hash;
            Salt = user.Salt;
            RoleID = user.RoleID;
            RoleName = user.RoleName;
        }

        public UserBLL()
        {
            // default ctor (constructor) is REQUIRED for MVC 
        }


    }
}
