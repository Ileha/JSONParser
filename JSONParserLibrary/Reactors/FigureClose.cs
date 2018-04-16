using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONParserLibrary.Reactors {
	public class FigureCloseFabric : AbstractReactorFabric {
		public override string Name {
			get {
				return "}";
			}
		}

		public override AbstractReactor CreateInstanse(int index) {
			return new FigureClose(index);
		}
	}

	public class FigureClose : AbstractReactor {
        public FigureClose(int index) : base("}", index) { }

		public override OpenClose State {
			get {
				return OpenClose.close;
			}
			set {
				throw new NotImplementedException();
			}
		}

        public override void Work(ReactorData data) {
			//AbstractReactor r = data.Order.Peek();
			//if (r.React != "{") {
			//	AbstractReactor react = new Comma(index);
			//	react.Work(data);
			//}
			//data.root = data.root.parent;

			//data.ReverseOrder.Push(this);
			//PartStruct p = new PartStruct("time");
			//data.root.AddPart(p);
   			//data.root = p;
			//AbstractReactor r = data.Order.Pop();
			//int _last_index = index;
			//int[] indexes = new int[4];
			//while (r.React != "{") {
			//	if (r.React == ":") {
			//		indexes[3] = _last_index;
			//		indexes[2] = r.index;
			//		r = data.Order.Pop();
			//		indexes[1] = r.index;
			//		r = data.Order.Pop();
			//		indexes[0] = r.index;
			//		data.root.AddPart(new PartNotString(data.data.Substring(indexes[0]+1, (indexes[1] - indexes[0])-1), data.data.Substring(indexes[2]+1, (indexes[3] - indexes[2])-1)));
			//	}
			//	else if (r.React == ",") {
			//		_last_index = r.index;
			//	}
			//	else {
			//		indexes[3] = r.index;
   //                 while ((r = data.Order.Pop()).React != "\"") {}
			//		indexes[2] = r.index;
			//		r = data.Order.Pop();
			//		r = data.Order.Pop();
			//		indexes[1] = r.index;
			//		r = data.Order.Pop();
			//		indexes[0] = r.index;
			//		data.root.AddPart(new PartString(data.data.Substring(indexes[0]+1, (indexes[1] - indexes[0])-1), data.data.Substring(indexes[2]+1, (indexes[3] - indexes[2])-1)));
			//	}
			//	r = data.Order.Pop();
			//}
			//data.root = data.root.parent;
        }
    }
}
