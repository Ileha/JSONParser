using System;
using System.Collections.Generic;

namespace JSONParserLibrary {
	public class PartArray : IPart {
		private List<IPart> container;
		private string _name;
		public IPart _parent;

		public PartArray(string name, params IPart[] contain) {
            this.name = name;
			container = new List<IPart>();
			for (int i = 0; i < contain.Length; i++) {
				contain[i].name = i.ToString();
				container.Add(contain[i]);
				contain[i].parent = this;
			}
		}

		public int Count { get { return container.Count; } }

		public string name {
			get { return _name; }
			set { _name = value; }
		}

		public IPart parent {
			get { return _parent; }
			set { _parent = value; }
		}

		public string value { get { throw new NotImplementedException(); } }

		public void AddPart(IPart element) {
			container.Add(element);
			element.parent = this;
		}

		public IPart GetPart(int index) {
			return container[index];
		}

		public void RemovePart(int index) {
			container.RemoveAt(index);
		}

		public void RemovePart(string name) {
			throw new NotImplementedException();
		}

		public void SetValue(object _value) {
			throw new NotImplementedException();
		}

		public string ToJSON() {
			return string.Format("\"{0}\": {1}", _name, ValueToJSON());
		}

		public IPart GetPart(string name)
		{
			throw new NotImplementedException();
		}

		public string ValueToJSON() {
			string res = "";
			for (int i = 0; i<container.Count; i++) {
				if (i == container.Count - 1) {
					res += container[i].ValueToJSON();
				}
				else
				{
					res += container[i].ValueToJSON() + ", ";
				}
			}
			return string.Format("[{0}]", res);
		}
	}
}
