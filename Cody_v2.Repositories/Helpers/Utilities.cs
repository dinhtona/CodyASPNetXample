using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cody_v2.Repositories.Helpers
{
    public static class Utilities
    {
        public static bool IsIPFormat(this string strIP)
        {
            Regex regexIP = new Regex(@"^(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$",
            RegexOptions.Compiled | RegexOptions.IgnoreCase);
            return regexIP.IsMatch(strIP);
        }
    }
}
