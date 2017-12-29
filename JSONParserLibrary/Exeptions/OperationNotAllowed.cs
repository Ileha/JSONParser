using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONParserLibrary.Exeptions
{
    class OperationNotAllowed : Exception  {
        private string Message;

        public OperationNotAllowed(string message) : base(message) {
            Message = "Operation " + message + " is not allowed";
        }

        public override string ToString() {
            return Message;
        }
    }
}
