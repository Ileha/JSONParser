using System;
using System.Collections.Generic;
using System.Text;

namespace JSONParserLibrary {
	public class PartArray : IPart {
		private List<IPart> container;

		public PartArray(string name, params IPart[] contain) {
            this.name = name;
			container = new List<IPart>();
			for (int i = 0; i < contain.Length; i++) {
				contain[i].name = i.ToString();
				container.Add(contain[i]);
				contain[i].parent = this;
			}
		}
		public override int Count { get { return container.Count; } }

		public override void AddPart(IPart element) {
			element.name = container.Count.ToString();
			container.Add(element);
			element.parent = this;
		}

		public override IPart GetPart(int index) {
			return container[index];
		}

		public override void RemovePart(int index) {
			container.RemoveAt(index);
		}

		public override string ToJSON() {
			return string.Format("\"{0}\": {1}", name, ValueToJSON());
		}

		public override string ValueToJSON() {
            StringBuilder res = new StringBuilder().Append("[");
			for (int i = 0; i<container.Count; i++) {
				if (i == container.Count - 1) {
					res.Append(container[i].ValueToJSON());
				}
				else
				{
					res.Append(container[i].ValueToJSON()).Append(", ");
				}
			}
            return res.Append("]").ToString();
		}
	}
}
