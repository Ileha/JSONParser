using System;
using JSONParserLibrary.Exceptions;
using System.Collections.Generic;
using System.Globalization;

namespace JSONParserLibrary
{
	public class PartValue : IPart
	{
		private readonly static CultureInfo defaultCulture = CultureInfo.GetCultureInfo("en-US");

		private string res;
		private bool isQuotes;

        private PartValue() {}
        public PartValue(object val) {
			SetValue(val);
		}

		public override T GetValue<T>() {
			if (isQuotes && typeof(T) == typeof(string)) {
				return (T)Convert.ChangeType(res, typeof(T));
			}
			else {//isQuotes = false
				if (res == "null") { return default(T); }
				else if (typeof(T) == typeof(string)) { throw new NotImplementedException(); }
				else { return (T)Convert.ChangeType(res, typeof(T), defaultCulture); }
			}
		}
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
			else if (_value is string) {
				res = _value.ToString();
				isQuotes = true;
			}
            else {
                isQuotes = false;
                if (_value is bool) {
                    res = ((bool)_value ? "true" : "false");
                }
                else if (_value is sbyte) {
                    res = ((sbyte)_value).ToString(defaultCulture);
			    }
                else if (_value is byte) {
                    res = ((byte)_value).ToString(defaultCulture);
                }
                else if (_value is short) {
                    res = ((short)_value).ToString(defaultCulture);
                }
                else if (_value is ushort) {
                    res = ((ushort)_value).ToString(defaultCulture);
                }
                else if (_value is int) {
                    res = ((int)_value).ToString(defaultCulture);
                }
                else if (_value is uint) {
                    res = ((uint)_value).ToString(defaultCulture);
                }
                else if (_value is long) {
                    res = ((long)_value).ToString(defaultCulture);
                }
                else if (_value is ulong) {
                    res = ((ulong)_value).ToString(defaultCulture);
                }
                else if (_value is float) {
                    res = ((float)_value).ToString(defaultCulture);
                }
                else if (_value is double) {
                    res = ((double)_value).ToString(defaultCulture);
                }
                else {
                    throw new NotSupportedException();
                }
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
