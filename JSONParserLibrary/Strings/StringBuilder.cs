using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using JSONParserLibrary.Exeptions;

namespace JSONParserLibrary.Strings
{
    public class StringBuilder
    {
        static Regex reg = new Regex(@"({(?<num>\d+)})");

        public static string Build(string pattern, params string[] input)
        {
            return reg.Replace(pattern, m => {
                string str = m.Groups["num"].Value;
                int index = Convert.ToInt32(str);
                try { 
                    str = input[index];
                }
                catch (Exception ex) {
                    throw new StringBuilderExeption(ex.ToString());
                }
                return str; 
            });
        }

        public static string Build(string pattern, List<string> input) {
            return reg.Replace(pattern, m => {
                string str = m.Groups["num"].Value;
                int index = Convert.ToInt32(str);
                try {
                    str = input[index];
                }
                catch (Exception ex) {
                    throw new StringBuilderExeption(ex.ToString());
                }
                return str;
            });
        }
    }
}
