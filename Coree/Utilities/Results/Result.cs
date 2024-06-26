﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coree.Utilities.Results
{
    public class Result : IResult
    {
        // success başarılıysa ya da başarısızsa isteğe göre mesage

        public Result(bool success, string message ):this(success) /// this kendini kasdeder Result 
        {
            Message = message;
        
        }
        public Result(bool success)
        {
            
            Success = success;
        }

        public bool Success { get; }

        public string Message { get; }
    }
}
