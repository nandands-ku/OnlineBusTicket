using OBTM.Core.Interfaces;
using OBTM.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBTM.DataAccess
{
    public class UserDataAccess : GenericDataAccess<User>,IUserRepository
    {
        public UserDataAccess(OBTMDbContext context) : base(context)
        {

        }

        public bool IsExist(string key)
        {
            return OBTMDbContext.Users.Any(m=>m.UserName== key) ||OBTMDbContext.Users.Any(m=>m.Email== key);
        }
    }
}
