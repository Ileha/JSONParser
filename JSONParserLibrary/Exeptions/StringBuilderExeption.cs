using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONParserLibrary.Exeptions
{
    public class StringBuilderExeption : Exception
    {
        private string Message;

        public StringBuilderExeption(string message) : base(message) {
            Message = message;
        }

        public override string ToString() {
            return Message;
        }
    }
}
