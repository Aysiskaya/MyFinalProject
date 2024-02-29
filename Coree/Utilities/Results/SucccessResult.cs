using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coree.Utilities.Results
{
    public class SucccessResult : Result
    {
        public SucccessResult(string message) : base(true, message) //RESULT 2 seçenek vardı bu mesaj yazmak istediğim 
        {

        }

        public SucccessResult() : base(true)     // RESULT 2 seçenek vardı bu mesaj yazmak istemediğim. 
        {

        }
        

    }
}
