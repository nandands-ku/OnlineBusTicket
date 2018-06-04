using OBTM.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBTM.Service
{
    public class BaseService
    {
        protected Response<T> SafeExecute<T>(Func<T> exec)
        {
            var response = new Response<T>();
            try
            {
                response.Data = exec();
                response.Success = true;
            }
            catch (Exception exp)
            {
                response.ErrorMessage = exp.Message;
                response.Success = false;
            }
            return response;
        }
        
    }
}
