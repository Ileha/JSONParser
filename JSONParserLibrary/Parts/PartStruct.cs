using System;
using System.Collections.Generic;
using System.Linq;

namespace JSONParserLibrary
{
	public class PartStruct : IPartValue
	{
		private List<Part> container;

		public PartStruct() {
			container = new List<Part>();
		}

		public int Count { get { throw new NotImplementedException(); } }

		public string value { get { throw new NotImplementedException(); } }

		public void AddPart(Part element) {
			container.Add(element);
		}

		public Part GetPart(int index)
		{
			throw new NotImplementedException();
		}

		public Part GetPart(string name) {
			return (from t in container
					where t.Name == name
			        select t).First();
		}

		public void RemovePart(int index)
		{
			throw new NotImplementedException();
		}

		public void RemovePart(string name) {
			container.Remove((from t in container
							  where t.Name == name
							  select t).First());
		}

		public void SetValue(object _value) {
			throw new NotImplementedException();
		}

		public string ToJSON() {
			string res = "";
			for (int i = 0; i < container.Count; i++) {
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
