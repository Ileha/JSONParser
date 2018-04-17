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

        public override void Work(ReactorData data) {}
    }
}
