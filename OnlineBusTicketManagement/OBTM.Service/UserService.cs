using OBTM.Core.Interfaces;
using OBTM.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBTM.Service
{
    public class UserService:GenericService<User>
    {
        public bool IsExist(String key)
        {
            var repository = GetInstance<IUserRepository>();
            var result = SafeExecute(() => repository.IsExist(key));
            return result.Data;
        }
    }
}
