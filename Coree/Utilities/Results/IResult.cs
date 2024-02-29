using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coree.Utilities.Results
{
    // temel voidler için 
    public  interface IResult
    {
        bool Success { get; }   // sadece okunabilir.
        string Message { get; }
    }
}
