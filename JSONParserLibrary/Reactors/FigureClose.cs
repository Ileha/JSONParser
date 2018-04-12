using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONParserLibrary.Reactors
{
    public class FigureClose : AbstractReactor {
        private int _index;

        public FigureClose() : base("}") { }

        public override int index
        {
            get { return _index; }
        }

        public override void CreateInstanse(int index, ReactorData data)
        {
            
        }
    }
}
