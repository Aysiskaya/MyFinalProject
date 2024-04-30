using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coree.Utilities.Security.Encryption
{
   public class SecurityKeyHelper   ///  byte array haline getiritor
    {
        public static SecurityKey CreateSecuritiyKey(string securityKey)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
        }
    }
}
