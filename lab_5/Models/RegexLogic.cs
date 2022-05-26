using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace lab_5.Models
{
    public partial class RegexLogic
    {
        public static string FindRegexInText(string Text, string CurrentRegex)
        {
            if (CurrentRegex == String.Empty || CurrentRegex == null)
            {
                return "Exception";
            }

            string Result = "";

            Regex regex = new Regex(CurrentRegex);

            MatchCollection match = regex.Matches(Text);

            foreach (Match x in match)
            {
                Result += (x.Value + "\n");
            }

            return Result;
        }
    }
}
