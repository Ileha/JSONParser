using System;
using JSONParserLibrary.Exeptions;

namespace JSONParserLibrary
{
	public class PartNotString : IPartValue
	{
		string res;

		public PartNotString(string val) {
			res = val;
		}

		public int Count { get { throw new NotImplementedException(); } }

		public string value { get { return res; } }

		public void AddPart(Part element)
		{
			throw new NotImplementedException();
		}

		public Part GetPart(int index)
		{
			throw new NotImplementedException();
		}

		public Part GetPart(string name)
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
			return string.Format("{0}", res);
		}
	}
}
