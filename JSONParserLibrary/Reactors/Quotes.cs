using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONParserLibrary.Reactors
{
	public class QuotesFabric : AbstractReactorFabric
	{
		public override string Name {
			get {
				return "\"";
			}
		}

		public override AbstractReactor CreateInstanse(int index) {
			return new Quotes(index);
		}	
	}

    public class Quotes : AbstractReactor {
        public Quotes(int index) : base("\"", index) { }

        public override void Work(ReactorData data) {
			

			//AbstractReactor r = data.Order.Pop();
			//int[] indexes = new int[3];
			//indexes[0] = r.index;
			//r = data.Order.Pop();
			//indexes[1] = r.index;
			//r = data.Order.Pop();
			//if (r.React == "\"") {
			//	indexes[1] = r.index;
			//	while ((r = data.Order.Pop()).React != "\"") {}
			//	indexes[2] = r.index;
			//	data.root.AddPart(new PartString(data.data.Substring(index+1, (indexes[0] - index) - 1), data.data.Substring(indexes[1] + 1, (indexes[2] - indexes[1]) - 1)));
			//}
			//else if (r.React == "}") {
			//	indexes[2] = r.index;
			//	data.root.AddPart(new PartNotString(data.data.Substring(index+1, (indexes[0] - index) - 1), data.data.Substring(indexes[1] + 1, (indexes[2] - indexes[1]) - 1)));
			//	data.root = data.root.parent;
			//}
			//else if (r.React == ",") {
			//	indexes[2] = r.index;
			//	data.root.AddPart(new PartNotString(data.data.Substring(index+1, (indexes[0] - index) - 1), data.data.Substring(indexes[1] + 1, (indexes[2] - indexes[1]) - 1)));
			//}
			//else if (r.React == "{") {
			//	PartStruct p = new PartStruct(data.data.Substring(index+1, (indexes[0] - index) - 1));
			//	data.root.AddPart(p);
			//	data.root = p;
			//}
        }
    }
}
