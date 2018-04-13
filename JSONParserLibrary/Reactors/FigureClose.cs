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
			AbstractReactor r = data.Order.Pop();
			int _last_index = index;
			int[] indexes = new int[4];
			while (r.React != "{") {
				if (r.React == ":") {
					indexes[3] = _last_index;
					indexes[2] = r.index;
					r = data.Order.Pop();
					indexes[1] = r.index;
					r = data.Order.Pop();
					indexes[0] = r.index;

					data.root.AddPart(new PartNotString(data.data.Substring(indexes[0]+1, (indexes[1] - indexes[0])-1), data.data.Substring(indexes[2]+1, (indexes[3] - indexes[2])-1)));
				}
				else if (r.React == ",") {
					_last_index = r.index;
				}
				else {
					indexes[3] = r.index;
					r = data.Order.Pop();
					indexes[2] = r.index;
					r = data.Order.Pop();
					r = data.Order.Pop();
					indexes[1] = r.index;
					r = data.Order.Pop();
					indexes[0] = r.index;
					data.root.AddPart(new PartString(data.data.Substring(indexes[0]+1, (indexes[1] - indexes[0])-1), data.data.Substring(indexes[2]+1, (indexes[3] - indexes[2])-1)));
				}



				r = data.Order.Pop();
			}
			data.root = data.root.parent;
        }
    }
}
