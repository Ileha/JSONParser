using System;
using JSONParserLibrary.Reactors;

namespace JSONParserLibrary
{
	public class SquareCloseFabric : AbstractReactorFabric
	{
		public override string Name
		{
			get { return "]"; }
		}

		public override AbstractReactor CreateInstanse(int index)
		{
			return new SquareClose(index);
		}
	}

	public class SquareClose : AbstractReactor {
		public SquareClose(int index) : base("]", index) {
			
		}

		public override void Work(ReactorData data) {
			//AbstractReactor r = data.Order.Peek();
			//if (r.React != "[") {
			//	AbstractReactor react = new Comma(index);
			//	react.Work(data);
			//}
			//data.root = data.root.parent;
		}
	}
}
