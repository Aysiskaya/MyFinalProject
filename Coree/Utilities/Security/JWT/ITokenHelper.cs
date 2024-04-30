using Coree.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coree.Utilities.Security.JWT
{
    // Kullanıcı adı şifre giren kullanıcı doğruysa bu çalışacak 
    public  interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }
}
