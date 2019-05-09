using System;
using System.Collections.Generic;
using JSONParserLibrary.Reactors;
using System.IO;

namespace JSONParserLibrary
{
	public class JSONParser : IToJSON
    {
        private IPart main;

        public IPart Data {
            get { return main; }
        }

        private static Dictionary<string, AbstractReactorFabric> library;
		private static void addToLibrary(AbstractReactorFabric react) {
			library.Add(react.Name, react);
		}
        static JSONParser() {
            library = new Dictionary<string, AbstractReactorFabric>();
			addToLibrary(new FigureCloseFabric());
			addToLibrary(new FigureOpenFabric());
			addToLibrary(new ColonFabric());
			addToLibrary(new CommaFabric());
			addToLibrary(new QuotesFabric());
			addToLibrary(new SquareOpenFabric());
			addToLibrary(new SquareCloseFabric());
        }

        public JSONParser() {
			main = new PartStruct();
		}
        public JSONParser(IPart data) {
            main = data;
        }
        public JSONParser(string json_string)
        {
            Convert(out main, json_string);
        }

		public static JSONParser ReadConfig(string configName) {
			JSONParser res;
			try {
				using (StreamReader sr = new StreamReader(configName)) {
					res = new JSONParser(sr.ReadToEnd());
				}
			}
			catch (IOException e) {
				throw e;
			}
			return res;
		}

		private static void Convert(out IPart name, string For_parse) {
            ReactorData data = new ReactorData(For_parse);
            for (int i = 0; i < For_parse.Length; i++) {
				try {
					data.Order.Enqueue(library[For_parse[i].ToString()].CreateInstanse(i));
				}
				catch (Exception err) { }
            }

			while (data.Order.Count != 0) {
				data.Order.Dequeue().Work(data);
			}

			name = data.root;
        }

        public IPart this[string index] {
            get {
				return main.ByPath(index);
            }
        }

        public string ToJSON() {
			return main.ToJSON();
        }
    }
}