using System;
using JSONParserLibrary.Exeptions;

namespace JSONParserLibrary
{
	public class PartString : IPart
	{
		private string res;
		private string _name;
		public IPart _parent;

		public PartString(string name, string value) {
            this.name = name;
			res = value;
		}

		public int Count { get { throw new NotImplementedException(); } }

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

		public void AddPart(IPart element) {
			throw new NotImplementedException();
		}

		public IPart GetPart(int index)
		{
			throw new NotImplementedException();
		}

		public IPart GetPart(string name) {
			throw new NotImplementedException();
		}

		public void RemovePart(int index)
		{
			throw new NotImplementedException();
		}

		public void RemovePart(string name) {
			throw new NotImplementedException();
		}

		public void SetValue(object _value) {
			if (_value.GetType() is string) {
				res = _value as string;
				return;
			}
			throw new OperationNotAllowed(string.Format("Excepton type of input value {0}, need string", _value.GetType()));
		}

		public string ToJSON() {
			return string.Format("\"{1}\": \"{0}\"", res, _name);
		}

		public string ValueToJSON()
		{
			return "\"" + res + "\"";
		}
	}
}
