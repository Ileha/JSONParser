using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JSONParserLibrary.Exceptions;

namespace JSONParserLibrary.Reactors
{
    public class FigureOpen : AbstractReactor {
        private int _index;

        public FigureOpen() : base("{") {}

        public override void CreateInstanse(int index, ReactorData data)
		{
            if (data.root.parent == null) {
				PartStruct p = new PartStruct("root");
				data.root.AddPart(p);
				data.root = p;
            }
            else {
                AbstractReactor r = data.Order.Pop();
                if (r.React != ":") { throw new ParsError(":"); }
                r = data.Order.Pop();
                if (r.React != "\"") { throw new ParsError("\""); }
                int stop = r.index;
                r = data.Order.Pop();
                if (r.React != "\"") { throw new ParsError("\""); }
                int start = r.index;
				PartStruct p = new PartStruct(data.data.Substring(start+1, (stop-start)-1));
                data.root.AddPart(p);
                data.root = p;
            }
			data.Order.Push(new FigureOpen() { _index = index });
        }

        public override int index
        {
            get { return _index; }
        }
    }
}
