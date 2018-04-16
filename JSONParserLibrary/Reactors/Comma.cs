using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JSONParserLibrary.Exceptions;

namespace JSONParserLibrary.Reactors {
	public class CommaFabric : AbstractReactorFabric {
		public override string Name {
			get {
				return ",";
			}
		}

		public override AbstractReactor CreateInstanse(int index) {
			return new Comma(index);
		}
	}

    public class Comma : AbstractReactor {
        public Comma(int index) : base(",", index) { }

		public override OpenClose State {
			get {
				return OpenClose.undefined;
			}
			set {
				throw new NotImplementedException();
			}
		}

        public override void Work(ReactorData data) {
			//AbstractReactor r = data.Order.Peek();
			//if (r.State == OpenClose.open)  {
			//	return;
			//}
			//bool is_str = false;
			//int[] indexes = new int[4];
			//indexes[3] = index;
			//if (r.React == "[") {
			//	indexes[2] = r.index;
			//	data.root.AddPart(new PartString((data.root.Count+1).ToString(), data.data.Substring(indexes[2] + 1, (indexes[3] - indexes[2]) - 1)));
			//	return;
			//}

			//r = data.Order.Pop();
			//if (r.React == ":") {
			//	indexes[2] = r.index;
			//}
			//else {
			//	is_str = true;
			//	indexes[3] = r.index;
			//	do {
			//		r = data.Order.Pop();
			//	} while (r.React != "\"" && r.State != OpenClose.open);
			//	indexes[2] = r.index;
			//	r = data.Order.Pop();
			//	if (r.React != ":") {
			//		data.root.AddPart(new PartString((data.root.Count+1).ToString(), data.data.Substring(indexes[2] + 1, (indexes[3] - indexes[2]) - 1)));
			//		return;
			//	}
			//}
			//r = data.Order.Pop();
			//indexes[1] = r.index;
			//r = data.Order.Pop();
			//indexes[0] = r.index;
			//if (is_str) {
			//	data.root.AddPart(new PartString(data.data.Substring(indexes[0]+1, (indexes[1] - indexes[0]) - 1), data.data.Substring(indexes[2] + 1, (indexes[3] - indexes[2]) - 1)));
			//}
			//else {
			//	data.root.AddPart(new PartNotString(data.data.Substring(indexes[0]+1, (indexes[1] - indexes[0]) - 1), data.data.Substring(indexes[2] + 1, (indexes[3] - indexes[2]) - 1)));
			//}
        }
    }
}
