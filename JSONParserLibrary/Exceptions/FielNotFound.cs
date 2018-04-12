using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONParserLibrary.Exceptions
{
    public class FielNotFound : Exception {
        private string Message;

        public FielNotFound(string message) : base("Fiel: " + message + " not found")
        {
            Message = "Fiel: " + message + " not found";
        }

        public override string ToString() {
            return Message;
        }
    }
}
