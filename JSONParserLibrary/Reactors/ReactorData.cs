using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JSONParserLibrary;

namespace JSONParserLibrary.Reactors
{
    public class ReactorData {
        public string data;
        public readonly Stack<AbstractReactor> Order;
        public IPart root;
        public ReactorData(string data) {
            Order = new Stack<AbstractReactor>();
            root = null;
            this.data = data;
        }
    }
}
