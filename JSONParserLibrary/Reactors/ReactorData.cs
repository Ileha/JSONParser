using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JSONParserLibrary;

namespace JSONParserLibrary.Reactors
{
	class RootPart : IPart {
		private IPart container;

		public override IPart parent {
			get { return null; }
			set { }
		}

		public override string name {
			get { return "root"; }
			set { }
		}

		public override void AddPart(IPart element) {
			container = element;
			element.parent = this;
		}
		public override IPart GetPart() {
			return container;
		}

		public override string ToJSON() {
			throw new NotImplementedException();
		}

		public override string ValueToJSON() {
			throw new NotImplementedException();
		}
	}

    public class ReactorData {
        public string data;
        public readonly Stack<AbstractReactor> Order;
        public IPart root;
        public ReactorData(string data) {
            Order = new Stack<AbstractReactor>();
			root = new RootPart();
            this.data = data;
        }
    }
}
