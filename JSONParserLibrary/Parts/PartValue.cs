using System;
using JSONParserLibrary.Exceptions;
using System.Collections.Generic;

namespace JSONParserLibrary
{
	public class PartValue : IPart
	{
		private string res;
		private bool isQuotes;

        private PartValue() {}
        public PartValue(object val) {
			SetValue(val);
		}

		public override string value { get { return res; } }
        internal static PartValue GetString(string _value) {
            return new PartValue() { res = _value, isQuotes = true };
        }
        internal static PartValue GetNotString(string _value) {
            return new PartValue() { res = _value, isQuotes = false };
        }
		public override void SetValue(Object _value)
		{
			if (_value == null) {
				res = "null";
				isQuotes = false;
			}
			else if (_value is bool) {
				res = ((bool)_value ? "true" : "false");
				isQuotes = false;
			}
			else if (_value is string) {
				res = _value.ToString();
				isQuotes = true;
			}
			else {
				res = _value.ToString();
				isQuotes = false;
			}
		}

		public override string ToJSON() {
			if (isQuotes) {
				return String.Format("\"{0}\"", res);
			}
			else
			{
				return res;
			}
		}

		internal override IPart PathStack(Queue<string> path) {
			if (path.Count == 0) {
				return this;
			}
			else {
				throw new FielNotFound(path.Peek());
			}
		}
	}
}
