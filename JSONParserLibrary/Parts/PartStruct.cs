using System;
using System.Collections.Generic;
using System.Text;
using JSONParserLibrary.Exceptions;

namespace JSONParserLibrary
{
	public class PartStruct : IPart
	{
		private Dictionary<string, IPart> container;

        public PartStruct() {
            container = new Dictionary<string, IPart>();
        }

		public override IPart Add(string name, IPart element)
		{
			container.Add(name, element);
            return this;
		}

		public override IPart Get(string name) {
			return container[name];
		}

		public override IPart Remove(string name) {
			container.Remove(name);
            return this;
		}

        public override IEnumerator<IPart> GetEnumerator() {
            return container.Values.GetEnumerator();
        }

		public override string ToJSON() {
			StringBuilder res = new StringBuilder().Append("{");
			int i = 0;
			foreach (KeyValuePair<string, IPart> part in container) {
				if (i == container.Count - 1) {
					res.AppendFormat("\"{0}\":{1}", part.Key, part.Value.ToJSON());
				}
				else {
					res.AppendFormat("\"{0}\":{1}, ", part.Key, part.Value.ToJSON());
				}
				i++;
			}
			return res.Append("}").ToString();
		}

		internal override IPart PathStack(Queue<string> path) {
			if (path.Count == 0) {
				return this;
			}
			string index = path.Dequeue();
			try {
				return Get(index).PathStack(path);
			}
			catch (KeyNotFoundException err) {
				throw new FielNotFound(index);
			}
		}
	}
}
