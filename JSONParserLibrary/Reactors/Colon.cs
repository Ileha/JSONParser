using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONParserLibrary.Reactors
{
    public class Colon : AbstractReactor
    {
        private int _index;

        public Colon() : base(":") {}
        public override int index
        {
            get { return _index; }
        }

        public override void CreateInstanse(int index, ReactorData data)
        {
            data.Order.Push(new Colon() { _index = index });
        }
    }
}
