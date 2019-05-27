using System;
using JSONParserLibrary.Exceptions;
using JSONParserLibrary.Reactors;

namespace JSONParserLibrary {
	public class SquareOpenFabric : AbstractReactorFabric {
        public override char Name
        {
			get { return '['; }
		}

		public override AbstractReactor CreateInstanse(int index) {
			return new SquareOpen(index);
		}
	}

	public class SquareOpen : AbstractReactor {
		public SquareOpen(int index) : base('[', index) {
		}

		public override void Work(ReactorData data) {
			IPart JSONArray = new PartArray();
			data.Push(JSONArray);

			AbstractReactor last = this;
			do
			{
				AbstractReactor[] indexes = new AbstractReactor[2];
				indexes[0] = data.Order.Dequeue();

				if (indexes[0].react == '{') {
					indexes[0].Work(data);
					JSONArray.Add(data.Pop());
					last = data.Order.Dequeue();
				}
                else if (indexes[0].react == ']')
                {
                    break;
                }
				else if (indexes[0].react == '[') {
					indexes[0].Work(data);
					JSONArray.Add(data.Pop());
					last = data.Order.Dequeue();
				}
				else if (indexes[0].react == '\"') {
                    AbstractReactor vie = null;
                    do
                    {
                        indexes[1] = data.Order.Dequeue();
                        vie = data.Order.Peek();
                    } while (!(indexes[1].react == '\"' && (vie.react == ',' || vie.react == ']')));
					JSONArray.Add(PartValue.GetString(data.JSONData.Substring(indexes[0].index + 1, (indexes[1].index - indexes[0].index) - 1)));
					last = data.Order.Dequeue();
				}
				else {
					JSONArray.Add(PartValue.GetNotString(data.JSONData.Substring(last.index + 1, (indexes[0].index - last.index) - 1).Trim()));
					last = indexes[0];
				}
			} while (last.react != ']');
		}
	}
}
