using System;
using JSONParserLibrary.Reactors;

namespace JSONParserLibrary
{
	public class SquareCloseFabric : AbstractReactorFabric
	{
        public override char Name
		{
			get { return ']'; }
		}

		public override AbstractReactor CreateInstanse(int index)
		{
			return new SquareClose(index);
		}
	}

	public class SquareClose : AbstractReactor {
		public SquareClose(int index) : base(']', index) {
			
		}

		public override void Work(ReactorData data) {}
	}
}
