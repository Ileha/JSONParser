using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JSONParserLibrary.Exceptions;

namespace JSONParserLibrary.Reactors {
	public class CommaFabric : AbstractReactorFabric {
        public override char Name
        {
			get {
				return ',';
			}
		}

		public override AbstractReactor CreateInstanse(int index) {
			return new Comma(index);
		}
	}

    public class Comma : AbstractReactor {
        public Comma(int index) : base(',', index) { }

        public override void Work(ReactorData data) {}
    }
}
