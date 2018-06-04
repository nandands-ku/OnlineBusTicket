﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBTM.Core.Models
{
    public class Response<T>
    {
        public Response()
        {
            Success = true;
        }
        public bool Success { get; set; }

        public T Data { get; set; }

        public int DataCount { get; set; }

        public string ErrorMessage { get; set; }
    }
}
