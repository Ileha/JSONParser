using System;
using System.Collections.Generic;
using System.Linq;

namespace JSONParserLibrary
{
	public class PartStruct : IPart
	{
		private Dictionary<string, IPart> container;

        public PartStruct() {
            container = new Dictionary<string, IPart>();
        }
		public PartStruct(string name, params IPart[] contain) {
			this.name = name;
			container = new Dictionary<string, IPart>();
			foreach (IPart part in contain) {
				container.Add(part.name, part);
				part.parent = this;
			}
		}

		public override void AddPart(IPart element) {
			container.Add(element.name, element);
			element.parent = this;
		}

		public override IPart GetPart(string name) {
			return container[name];
		}

		public override void RemovePart(string name) {
			container.Remove(name);
		}

		public override string ToJSON() {
			return string.Format("\"{0}\": {1}", name, ValueToJSON());
		}

		public override string ValueToJSON() {
			string res = "";
			int i = 0;
			foreach (IPart part in container.Values) {
				if (i == container.Count - 1) {
					res += part.ToJSON();
				}
				else {
					res += part.ToJSON()+", ";
				}
				i++;
			}
			return "{"+res+"}";
		}
	}
}
