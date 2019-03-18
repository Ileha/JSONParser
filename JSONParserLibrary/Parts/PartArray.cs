using System;
using System.Collections.Generic;
using System.Text;

namespace JSONParserLibrary {
	public class PartArray : IPart {
		private List<IPart> container;

		public PartArray() {
			container = new List<IPart>();
		}
		public override int Count { get { return container.Count; } }

		public override IPart Add(IPart element) {
			container.Add(element);
            return this;
		}

		public override IPart Get(int index) {
			return container[index];
		}

		public override IPart Remove(int index) {
			container.RemoveAt(index);
            return this;
		}

        public override IEnumerator<IPart> GetEnumerator() {
            return container.GetEnumerator();
        }

		public override string ToJSON() {
            StringBuilder res = new StringBuilder().Append("[");
			for (int i = 0; i<container.Count; i++) {
				if (i == container.Count - 1) {
					res.Append(container[i].ToJSON());
				}
				else
				{
					res.Append(container[i].ToJSON()).Append(", ");
				}
			}
            return res.Append("]").ToString();
		}
	}
}
