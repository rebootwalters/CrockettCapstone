using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
   public class UserDAL
    {
        #region columns from primary table
        public int UserID { get; set; }
        public string EMail { get; set; }
        public string Hash { get; set; }
        public string Salt { get; set; }
        public int RoleID { get; set; }
        #endregion

        #region columns from foreign tables
        public string RoleName { get; set; }
        #endregion

        public override string ToString()
        {
            return $"UserID:{UserID,5} RoleID:{RoleID,5} RoleName:{RoleName,15} EMail:{EMail,25} Hash:{Hash} Salt:{Salt}";
        }
    }
}
