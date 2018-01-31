using System;
using JSONParserLibrary.Exeptions;

namespace JSONParserLibrary
{
	public class PartNotString : IPart
	{
		string res;

		public PartNotString(string name, string val) {
            this.name = name;
			res = val;
		}

		public override string value { get { return res; } }

		public override void SetValue(object _value)
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

		public override string ToJSON() {
			return string.Format("\"{1}\": {0}", res, name);
		}

		public override string ValueToJSON() {
			return res;
		}
	}
}
