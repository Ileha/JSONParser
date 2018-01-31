using System;
namespace JSONParserLibrary
{
	public abstract class IPart : IToJSON
	{
		private string _name;
		public IPart _parent;

		public string name {
			get { return _name; }
			set { _name = value; }
		}
		public IPart parent {
			get { return _parent; }
			set { _parent = value; }
		}

		public virtual string value { get { throw new NotImplementedException(); } }
		public virtual void SetValue(object _value) { throw new NotImplementedException(); }
		public virtual void AddPart(IPart element) { throw new NotImplementedException(); }
		public virtual void RemovePart(string name) { throw new NotImplementedException(); }
		public virtual IPart GetPart(string name) { throw new NotImplementedException(); }
		public virtual IPart GetPart(int index) { throw new NotImplementedException(); }
		public virtual void RemovePart(int index) { throw new NotImplementedException(); }
		public virtual int Count { get { throw new NotImplementedException(); } }

		public abstract string ToJSON();
		public abstract string ValueToJSON();

		//IPart this[string index];
	}
}
