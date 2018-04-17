using System;
using System.Collections.Generic;
using JSONParserLibrary.Reactors;
using JSONParserLibrary.Exceptions;

namespace JSONParserLibrary
{
	public class JSONParser : IToJSON
    {
        private static Type type_array;
        private static Type type_struct;

        private IPart main;

        public IPart Data {
            get { return main; }
        }

        private static Dictionary<string, AbstractReactorFabric> library;
        static JSONParser() {
            library = new Dictionary<string, AbstractReactorFabric>();
			addToLibrary(new FigureCloseFabric());
			addToLibrary(new FigureOpenFabric());
			addToLibrary(new ColonFabric());
			addToLibrary(new CommaFabric());
			addToLibrary(new QuotesFabric());
			addToLibrary(new SquareOpenFabric());
			addToLibrary(new SquareCloseFabric());
            type_array = typeof(PartArray);
            type_struct = typeof(PartStruct);
        }

        public JSONParser() { }
        public JSONParser(string json_string)
        {
            Create(json_string);
        }

		private static void addToLibrary(AbstractReactorFabric react) {
			library.Add(react.Name, react);
		}

        public void Create(string json_string) {
            Convert(out main, json_string);
        }

		public static void Convert(out IPart name, string For_parse) {
            ReactorData data = new ReactorData(For_parse);
            for (int i = For_parse.Length-1; i >= 0; i--) {
				try {
					data.Order.Push(library[For_parse[i].ToString()].CreateInstanse(i));
					//Console.WriteLine(i);
				}
				catch (Exception err) { }
            }

			while (data.Order.Count != 0) {
				data.Order.Pop().Work(data);
			}

			name = data.root.GetPart();
        }

        public IPart this[string index]
        {
            get
            {
                string[] elements = index.Split('.');
                IPart res = main;
                for (int i = 0; i < elements.Length; i++)
                {
                    //Console.WriteLine("element: {0} - ", elements[i]);
                    try
                    {
                        if (res.GetType() == type_array)
                        {
                            res = res.GetPart(System.Convert.ToInt32(elements[i]));
                        }
                        else if (res.GetType() == type_struct)
                        {
                            res = res.GetPart(elements[i]);
                        }
                        else
                        {
                            throw new FielNotFound(elements[i]); ;
                        }
                    }
                    catch (FielNotFound err2)
                    {
                        throw err2;
                    }
                    catch (Exception err)
                    {
                        throw new FielNotFound(elements[i]);
                    }
                }
                return res;
            }
        }

        public string ToJSON() {
            return main.ValueToJSON();
        }

        public string ValueToJSON() {
            throw new NotImplementedException();
        }
    }
}