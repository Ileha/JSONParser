using System;
using System.Collections.Generic;
using System.Linq;

namespace JSONParserLibrary
{
	public class PartStruct : IPart
	{
		private List<IPart> container;
		private string _name;
		public IPart _parent;

		public PartStruct(string name, params IPart[] contain) {
			this.name = name;
			container = new List<IPart>();
			foreach (IPart part in contain) {
				container.Add(part);
				part.parent = this;
			}
		}

		public int Count { get { throw new NotImplementedException(); } }
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

		public IPart GetPart(int index)
		{
			throw new NotImplementedException();
		}

		public IPart GetPart(string name) {
			return (from t in container
					where t.name == name
			        select t).First();
		}

		public void RemovePart(int index)
		{
			throw new NotImplementedException();
		}

		public void RemovePart(string name) {
			container.Remove((from t in container
							  where t.name == name
							  select t).First());
		}

		public void SetValue(object _value) {
			throw new NotImplementedException();
		}

		public string ToJSON() {
			return string.Format("\"{0}\": {1}", _name, ValueToJSON());
		}

		public string ValueToJSON() {
			string res = "";
			for (int i = 0; i<container.Count; i++) {
				if (i == container.Count - 1) {
					res += container[i].ToJSON();
				}
				else {
					res += container[i].ToJSON()+", ";
				}
			}
			return "{"+res+"}";
		}
	}
}
