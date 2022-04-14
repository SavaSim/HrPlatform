using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRPlatform.Helper
{
    public interface IEmailValidator
    {
        bool IsValid(string emailaddress);
    }
}
