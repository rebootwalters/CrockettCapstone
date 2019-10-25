using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLogicLayer
{
   public class ContextBLL : IDisposable
    {
        #region Context stuff
        ContextDAL _context = new ContextDAL();
        public ContextBLL()
        {
            _context.ConnectionString =
            ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        #endregion


        #region role stuff
        public List<RoleBLL> RoleGetAll(int skip, int take)
        {
            List<RoleBLL> ProposedReturnValue = new List<RoleBLL>();

            List<RoleDAL> items =  _context.RoleGetAll(skip, take);

            foreach (RoleDAL item in items)
            {
                RoleBLL correctedItem = new RoleBLL(item);
                ProposedReturnValue.Add(correctedItem);
            }

            return ProposedReturnValue;
        }

        public RoleBLL RoleFindByID(int RoleID)
        {
            RoleBLL proposedReturnValue = null;
            RoleDAL item = _context.RoleFindByID(RoleID);
            if (item != null)
            {
                proposedReturnValue = new RoleBLL(item);
            }
            return proposedReturnValue;
        }

        public int RoleCreate(string RoleName)
        {
            return _context.RoleCreate(RoleName);
        }

        public void RoleJustUpdate(int RoleID, string RoleName)
        {
            _context.RoleUpdateJust(RoleID, RoleName);
        }

        public void RoleDelete(int RoleID)
        {
            _context.RoleDelete(RoleID);
        }

        #endregion roles

        #region User stuff

        public List<UserBLL> UserGetAll(int skip, int take)
        {
            List<UserBLL> ProposedReturnValue = new List<UserBLL>();

            List<UserDAL> items = _context.UserGetAll(skip, take);

            foreach (UserDAL item in items)
            {
                UserBLL correctedItem = new UserBLL(item);
                ProposedReturnValue.Add(correctedItem);
            }

            return ProposedReturnValue;
        }

        public UserBLL UserFindByID(int UserID)
        {
            UserBLL proposedReturnValue = null;
            UserDAL item = _context.UserFindByID(UserID);
            if (item != null)
            {
                proposedReturnValue = new UserBLL(item);
            }
            return proposedReturnValue;
        }

        public void UserUpdateJust(int UserID, string EMail, string Hash, string Salt, int RoleID)
        {
            _context.UserUpdateJust(UserID, EMail, Hash, Salt, RoleID);
        }

        public void UserDelete(int UserID)
        {
            _context.UserDelete(UserID);
        }

        #endregion users
    }
}
