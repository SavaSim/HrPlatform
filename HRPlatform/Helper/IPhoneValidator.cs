using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRPlatform.Helper
{
    public interface IPhoneValidator
    {
        bool IsValid(string number);
    }
}
