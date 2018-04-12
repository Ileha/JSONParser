using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONParserLibrary.Exceptions
{
    class ParsError : Exception
    {
        string bad;
        public ParsError(string bad)
        {
            this.bad = bad;
        }

        public override string ToString()
        {
            return "bad symbol " + bad;
        }
    }
}
