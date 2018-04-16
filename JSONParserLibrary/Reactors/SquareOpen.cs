using System;
using JSONParserLibrary.Exceptions;
using JSONParserLibrary.Reactors;

namespace JSONParserLibrary {
	public class SquareOpenFabric : AbstractReactorFabric {
		public override string Name {
			get { return "["; }
		}

		public override AbstractReactor CreateInstanse(int index) {
			return new SquareOpen(index);
		}
	}

	public class SquareOpen : AbstractReactor {
		public SquareOpen(int index) : base("[", index) {
		}

		public override void Work(ReactorData data) {
			if (data.root.parent == null) {
				PartArray p = new PartArray("root");
				data.root.AddPart(p);
				data.root = p;
			}
			else if (data.ReverseOrder.Count > 0) {
				AbstractReactor r = data.ReverseOrder.Pop();
				if (r.React != ":") { throw new ParsError(":"); }
				r = data.ReverseOrder.Pop();
				if (r.React != "\"") { throw new ParsError("\""); }
				int stop = r.index;
				r = data.ReverseOrder.Pop();
				if (r.React != "\"") { throw new ParsError("\""); }
				int start = r.index;
				PartArray p = new PartArray(data.data.Substring(start + 1, (stop - start) - 1));
				data.root.AddPart(p);
				data.root = p;
			}
			else {
				PartArray p = new PartArray(data.root.Count.ToString());
				data.root.AddPart(p);
				data.root = p;
			}

			AbstractReactor last = this;
			do
			{
				AbstractReactor[] indexes = new AbstractReactor[2];
				indexes[0] = data.Order.Pop();

				if (indexes[0].React == "{") {
					indexes[0].Work(data);
					last = data.Order.Pop();
				}
				else if (indexes[0].React == "[") {
					indexes[0].Work(data);
					last = data.Order.Pop();
				}
				else if (indexes[0].React == "\"") {
                    AbstractReactor vie = null;
                    do
                    {
                        indexes[1] = data.Order.Pop();
                        vie = data.Order.Peek();
                    } while (!(indexes[1].React == "\"" && (vie.React == "," || vie.React == "]")));
					data.root.AddPart(new PartString(data.root.Count.ToString(), data.data.Substring(indexes[0].index + 1, (indexes[1].index - indexes[0].index) - 1)));
					last = data.Order.Pop();
				}
				else {
					data.root.AddPart(new PartNotString(data.root.Count.ToString(), data.data.Substring(last.index + 1, (indexes[0].index - last.index) - 1).Trim()));
					last = indexes[0];
				}
			} while (last.React != "]");
			data.root = data.root.parent;
		}
	}
}
