using System;
using JSONParserLibrary.Exeptions;

namespace JSONParserLibrary
{
	public class PartString : IPart
	{
		private string res;

		public PartString(string name, string value) {
            this.name = name;
			res = value;
		}

		public override string value { get { return res; } }

		public override void SetValue(object _value) {
			if (_value.GetType() is string) {
				res = _value as string;
				return;
			}
			throw new OperationNotAllowed(string.Format("Excepton type of input value {0}, need string", _value.GetType()));
		}

		public override string ToJSON() {
			return string.Format("\"{1}\": \"{0}\"", res, name);
		}

		public override string ValueToJSON() {
			return "\"" + res + "\"";
		}
	}
}
