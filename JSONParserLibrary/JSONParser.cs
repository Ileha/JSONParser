using System;
using System.Collections.Generic;
using JSONParserLibrary.Reactors;
using JSONParserLibrary.Exceptions;

namespace JSONParserLibrary
{
	public class JSONParser
    {
        private IPart main;

        public IPart Data {
            get { return main; }
        }

        private static Dictionary<string, AbstractReactor> library;
        static JSONParser() {
            library = new Dictionary<string, AbstractReactor>();
			addToLibrary(new FigureClose());
			addToLibrary(new FigureOpen());
			addToLibrary(new Colon());
			addToLibrary(new Comma());
			addToLibrary(new Quotes());
        }

		private static void addToLibrary(AbstractReactor react) {
			library.Add(react.React, react);
		}
        
		public static void Convert(out IPart name, string For_parse) {
            ReactorData data = new ReactorData(For_parse);
            for (int i = 0; i < For_parse.Length; i++) {
				try {
					library[For_parse[i].ToString()].CreateInstanse(i, data);
					Console.WriteLine(i);
				}
				catch (ParsError err) { throw err; }
				catch (Exception err) { }
            }
			name = data.root.GetPart();
        }

        //public IPart this[string index] {
        //    get {
        //        string[] elements = index.Split('.');
        //        IPart res = main;
        //        for (int i = 0; i < elements.Length; i++) {
        //            //Console.WriteLine("element: {0} - ", elements[i]);
        //            try {
        //                if (res.GetType() == type_array) {
        //                    res = res.GetPart(System.Convert.ToInt32(elements[i]));
        //                }
        //                else if (res.GetType() == type_struct) {
        //                    res = res.GetPart(elements[i]);
        //                }
        //                else {
        //                    throw new FielNotFound(elements[i]); ;
        //                }
        //            }
        //            catch (FielNotFound err2) {
        //                throw err2;
        //            }
        //            catch (Exception err) {
        //                throw new FielNotFound(elements[i]);
        //            }
        //        }
        //        return res;
        //    }
        //}
    }
}