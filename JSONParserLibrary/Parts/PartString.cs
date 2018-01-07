using System;
using JSONParserLibrary.Exeptions;

namespace JSONParserLibrary
{
	public class PartString : IPartValue
	{
		private string res;
		public PartString(string value) {
			res = value;
		}

		public int Count { get { throw new NotImplementedException(); } }

		public string value { get { return res; } }

		public void AddPart(Part element) {
			throw new NotImplementedException();
		}

		public Part GetPart(int index)
		{
			throw new NotImplementedException();
		}

		public Part GetPart(string name) {
			throw new NotImplementedException();
		}

		public void OnAddingToPart(Part master) {}

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
			return string.Format("\"{0}\"", res);
		}
	}
}
