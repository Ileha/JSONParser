using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JSONParserLibrary.Exceptions;

namespace JSONParserLibrary.Reactors
{
	public class ColonFabric : AbstractReactorFabric {
		public override string Name {
			get {
				return ":";
			}
		}

		public override AbstractReactor CreateInstanse(int index) {
			return new Colon(index);
		}
	}

    public class Colon : AbstractReactor {
        public Colon(int index) : base(":", index) {}

		public override OpenClose State {
			get {
				return OpenClose.undefined;
			}
			set {
				throw new NotImplementedException();
			}
		}

        public override void Work(ReactorData data) {
			//data.Order.Push(this);
        }
    }
}
