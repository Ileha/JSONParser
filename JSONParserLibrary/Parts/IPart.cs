using System;
using System.Collections;
using System.Collections.Generic;

namespace JSONParserLibrary
{
	public abstract class IPart : IToJSON, IEnumerable<IPart>
	{
		public virtual string value { get { throw new NotImplementedException(); } }
		public virtual void SetValue(object _value) { throw new NotImplementedException(); }

		public virtual IPart Add(string name, IPart element) { throw new NotImplementedException(); }
		public IPart Add(string name, object val) {
			return Add(name, new PartValue(val));
		}
		public virtual IPart Remove(string name) { throw new NotImplementedException(); }
		public virtual IPart Get(string name) { throw new NotImplementedException(); }

		public virtual IPart Add(IPart element) { throw new NotImplementedException(); }
		public IPart Add(object val) {
			return Add(new PartValue(val));
		}
		public virtual IPart Get(int index) { throw new NotImplementedException(); }
		public virtual IPart Remove(int index) { throw new NotImplementedException(); }
		public virtual int Count { get { throw new NotImplementedException(); } }

		public abstract string ToJSON();

        public virtual IEnumerator<IPart> GetEnumerator() {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}