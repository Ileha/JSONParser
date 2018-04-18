using System;
using System.Collections;
using System.Collections.Generic;

namespace JSONParserLibrary
{
	public abstract class IPart : IToJSON, IEnumerable<IPart>
	{
		protected string _name;
		protected IPart _parent;

		public virtual string name
		{
			get { return _name; }
			set { 
				try {
					parent.RemovePart(name);
					_name = value;
					parent.AddPart(this);
				}
				catch (Exception err) {
					_name = value;
				}
			}
		}
		public virtual IPart parent
		{
			get { return _parent; }
			set { _parent = value; }
		}

		public virtual string value { get { throw new NotImplementedException(); } }
		public virtual void SetValue(object _value) { throw new NotImplementedException(); }
		public virtual void AddPart(IPart element) { throw new NotImplementedException(); }
		public virtual void RemovePart(string name) { throw new NotImplementedException(); }
		public virtual IPart GetPart() { throw new NotImplementedException(); }
		public virtual IPart GetPart(string name) { throw new NotImplementedException(); }
		public virtual IPart GetPart(int index) { throw new NotImplementedException(); }
		public virtual void RemovePart(int index) { throw new NotImplementedException(); }
		public virtual int Count { get { throw new NotImplementedException(); } }

		public abstract string ToJSON();
		public abstract string ValueToJSON();

		//IPart this[string index];

        public virtual IEnumerator<IPart> GetEnumerator() {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}