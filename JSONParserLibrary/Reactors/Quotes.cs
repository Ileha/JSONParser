using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONParserLibrary.Reactors
{
	public class QuotesFabric : AbstractReactorFabric
	{
		public override char Name {
			get {
				return '\"';
			}
		}

		public override AbstractReactor CreateInstanse(int index) {
			return new Quotes(index);
		}	
	}

    public class Quotes : AbstractReactor {
        public Quotes(int index) : base('\"', index) { }

        public override void Work(ReactorData data) {}
    }
}
