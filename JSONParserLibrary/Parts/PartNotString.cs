using System;
using JSONParserLibrary.Exeptions;

namespace JSONParserLibrary
{
	public class PartNotString : IPart
	{
		string res;
		private string _name;
		public IPart _parent;

		public PartNotString(string name, string val) {
            this.name = name;
			res = val;
		}

		public int Count { get{ throw new NotImplementedException(); } }

		public string name
		{
			get { return _name; }
			set { _name = value; }
		}

		public IPart parent
		{
			get { return _parent; }
			set { _parent = value; }
		}

		public string value { get { return res; } }

		public void AddPart(IPart element)
		{
			throw new NotImplementedException();
		}

		public IPart GetPart(int index)
		{
			throw new NotImplementedException();
		}

		public IPart GetPart(string name)
		{
			throw new NotImplementedException();
		}

		public void RemovePart(int index)
		{
			throw new NotImplementedException();
		}

		public void RemovePart(string name)
		{
			throw new NotImplementedException();
		}

		public void SetValue(object _value)
		{
			if (_value == null) {
				res = "null";
			}
			else if (_value.GetType() is bool) {
				res = ((bool)_value ? "true" : "false");
			}
			else if (_value.GetType() is string) {
				throw new OperationNotAllowed("Excepton need all not include string");
			}
			else {
				res = _value.ToString();
			}
		}

		public string ToJSON() {
			return string.Format("\"{1}\": {0}", res, _name);
		}

		public string ValueToJSON()
		{
			return res;
		}
	}
}
