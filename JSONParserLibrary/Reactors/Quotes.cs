using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONParserLibrary.Reactors
{
    public class Quotes : AbstractReactor {
        private int _index;
        public Quotes() : base("\"") { }

        public override int index {
            get { return _index; }
        }

        public override void CreateInstanse(int index, ReactorData data)
        {
            data.Order.Push(new Quotes() { _index = index });
        }
    }
}
