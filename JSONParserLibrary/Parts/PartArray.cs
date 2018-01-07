using System;
using System.Collections.Generic;

namespace JSONParserLibrary {
	public class PartArray : IPartValue {
		private List<Part> container;
		private Part MyPart;

		public PartArray(params Part[] contain) {
			container = new List<Part>();
			for (int i = 0; i < contain.Length; i++) {
				contain[i].ChangeName(i.ToString());
				container.Add(contain[i]);
			}
		}

		public int Count { get { return container.Count; } }

		public string value { get { throw new NotImplementedException(); } }

		public void AddPart(Part element) {
			container.Add(element);
			element.ChangeParent(MyPart);
		}

		public Part GetPart(int index) {
			return container[index];
		}

		public Part GetPart(string name) {
			throw new NotImplementedException();
		}

		public void OnAddingToPart(Part master) {
			MyPart = master;
			container.ForEach((obj) => obj.ChangeParent(master));
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

		public string ToJSON()
		{
			string res = "";
			for (int i = 0; i < container.Count; i++)
			{
				if (i == container.Count - 1) {
					res += container[i].Value.ToJSON();
				}
				else
				{
					res += container[i].Value.ToJSON() + ", ";
				}
			}
			return string.Format("[{0}]", res);
		}
	}
}
