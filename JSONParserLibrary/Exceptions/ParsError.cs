using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONParserLibrary.Exceptions
{
    class ParsError : Exception
    {
        String message;
        public ParsError(char bad)
        {
            message = "bad symbol " + bad;
        }
        public ParsError(string message) {
            this.message = message;
        }

        public override string ToString()
        {
            return message;
        }
    }
}
