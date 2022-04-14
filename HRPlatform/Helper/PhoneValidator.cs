using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HRPlatform.Helper
{
    public class PhoneValidator : IPhoneValidator
    {
        private const string motif = @"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$";
        public bool IsValid(string number)
        {
            if (number != null) return Regex.IsMatch(number, motif);
            else return false;
        }
    }
}
