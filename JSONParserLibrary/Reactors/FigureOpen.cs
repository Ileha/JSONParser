﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JSONParserLibrary.Exceptions;

namespace JSONParserLibrary.Reactors {
	public class FigureOpenFabric : AbstractReactorFabric {
        public override char Name
        {
			get {
				return '{';
			}
		}

		public override AbstractReactor CreateInstanse(int index) {
			return new FigureOpen(index);
		}
	}

    public class FigureOpen : AbstractReactor {
        public FigureOpen(int index) : base('{', index) {}

        public override void Work(ReactorData data) {
			IPart JSONStruct = new PartStruct();
			data.Push(JSONStruct);
			AbstractReactor r = null;

			do {
				r = data.Order.Dequeue();
				int[] range = new int[3];
				if (r.react != '\"') {
                    if (r.react == '}') { break; }
                    throw new ParsError('\"');
                }
				range[0] = r.index;
				r = data.Order.Dequeue();
				if (r.react != '\"') { throw new ParsError('\"'); }
				range[1] = r.index;
				r = data.Order.Dequeue();
				range[2] = r.index;
				if (r.react != ':') { throw new ParsError('\"'); }
				string name = data.JSONData.Substring(range[0] + 1, range[1] - range[0]-1);

				r = data.Order.Dequeue();
				if (r.react == '\"')
				{ //string
					range[0] = r.index;
					do
					{
						r = data.Order.Dequeue();
					} while (r.react != '\"');
					range[1] = r.index;
					JSONStruct.Add(name, PartValue.GetString(data.JSONData.Substring(range[0] + 1, range[1] - range[0]-1)));
					r = data.Order.Dequeue();
				}
				else if (r.react == ',' || r.react == '}')
				{ //not string
					range[0] = r.index;
					JSONStruct.Add(name, PartValue.GetNotString(data.JSONData.Substring(range[2] + 1, range[0] - range[2]-1).Trim()));
				}
				else if (r.react == '{')
				{ //object
					r.Work(data);
					JSONStruct.Add(name, data.Pop());
					r = data.Order.Dequeue();
				}
				else if (r.react == '[')
				{ //array
					r.Work(data);
					JSONStruct.Add(name, data.Pop());
					r = data.Order.Dequeue();
				}
				else
				{
					throw new ParsError("error in struct");
				}
			} while (r.react != '}');


			/*
			if (data.root.parent == null) {
				PartStruct p = new PartStruct("root");
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
				PartStruct p = new PartStruct(data.data.Substring(start + 1, (stop - start) - 1));
				data.root.AddPart(p);
                data.root = p;
			}
			else {
				PartStruct p = new PartStruct(data.root.Count.ToString());
				data.root.AddPart(p);
				data.root = p;
			}

			AbstractReactor last = null;
			do
			{
				AbstractReactor[] indexes = new AbstractReactor[4];
				indexes[0] = data.Order.Pop();
                if (indexes[0].React == "}") { break; }
                if (indexes[0].React != "\"") { throw new ParsError("\""); }
				indexes[1] = data.Order.Pop();
                if (indexes[1].React != "\"") { throw new ParsError("\""); }
				indexes[2] = data.Order.Pop();
                if (indexes[2].React != ":") { throw new ParsError(":"); }
				indexes[3] = data.Order.Pop();

				if (indexes[3].React == "{")
				{
					data.ReverseOrder.Push(indexes[0]);
					data.ReverseOrder.Push(indexes[1]);
					data.ReverseOrder.Push(indexes[2]);
					indexes[3].Work(data);
					last = data.Order.Pop();
				}
				else if (indexes[3].React == "[")
				{
					data.ReverseOrder.Push(indexes[0]);
					data.ReverseOrder.Push(indexes[1]);
					data.ReverseOrder.Push(indexes[2]);
					indexes[3].Work(data);
					last = data.Order.Pop();
				}
				else if (indexes[3].React == "\"")
				{
					indexes[2] = indexes[3];
                    AbstractReactor vie = null;
                    do {
                        indexes[3] = data.Order.Pop();
                        vie = data.Order.Peek();
                    } while (!(indexes[3].React == "\"" && (vie.React == "," || vie.React == "}")));
					data.root.AddPart(new PartString(data.data.Substring(indexes[0].index + 1, (indexes[1].index - indexes[0].index) - 1), data.data.Substring(indexes[2].index + 1, (indexes[3].index - indexes[2].index) - 1)));
					last = data.Order.Pop();
				}
				else {
					data.root.AddPart(new PartNotString(data.data.Substring(indexes[0].index + 1, (indexes[1].index - indexes[0].index) - 1), data.data.Substring(indexes[2].index + 1, (indexes[3].index - indexes[2].index) - 1).Trim()));
					last = indexes[3];
				}
			} while (last.React != "}");
			data.root = data.root.parent;
			*/
        }
    }
}
