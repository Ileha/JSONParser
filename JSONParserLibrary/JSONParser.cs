using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using JSONParserLibrary.Exceptions;
using System.Xml.Linq;
using JSONParserLibrary.Reactors;

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
            AbstractReactor r = new FigureClose();
            library.Add(r.React, r);
            r = new FigureOpen();
            library.Add(r.React, r);
        }

        //private Type type_struct = typeof(PartStruct);
        //private Type type_array = typeof(PartArray);

        //private static Regex reg = new Regex(",");
        //private static Regex cv_open = new Regex("\\[");
        //private static Regex cv_close = new Regex("\\]");
        //private static Regex reg_open = new Regex("{");
        //private static Regex reg_close = new Regex("}");
        //private static Regex for_end = new Regex("(\"(?<name>[\\w ]+)\":[ ]?(?<skob>[\"]?)(?<value>[^\"]+)[\"]?)");
        //private static Regex for_end_arr = new Regex("[, ]+(?<skob>[\"]?)(?<value>[^\"]+)");
        //private static Regex for_next = new Regex("^[, ]+\"(?<name>[\\w ]+)\":[ ]?(?<body>.+)$");
        //private static Regex for_next_arr = new Regex("[, ]+(?<body>.+)");
        //private static Regex reg_cav = new Regex("\"");
        //private static Regex reg_super_cymbols = new Regex("\"(?<symbols>[^\"]+)\"");
        //private static Regex not_reg_super_cymbols = new Regex("[ ]?,[ ]?");
        //private static Regex is_array = new Regex("^(?<is_arr>[{\\[]?)");
        //private static Regex simple_element = new Regex("([{]+)|([}]+)|([\\[]+)|([\\]]+)");

        //public JSONParser(string JSONString) {
        //    main = ConvertFromJSON(JSONString);
        //}
        //public JSONParser(IPart root) {
        //    main = root;
        //}
        //public string ConvertToJSON() {
        //    return main.ValueToJSON();
        //}
        //public static IPart ConvertFromJSON(string For_parse) {
        //    IPart el;
        //    Convert(out el, "root", ConvertSuperSymbols(For_parse));
        //    return el;
        //}
        //private static string ConvertSuperSymbols(string input) {
        //    string res = reg_super_cymbols.Replace(input,
        //        m => {
        //            string str = m.Groups["symbols"].Value;
        //            if (!not_reg_super_cymbols.IsMatch(str)) {
        //                str = reg_open.Replace(str, "<erugif_nepo>");
        //                str = reg_close.Replace(str, "<erugif_esolc>");
        //                str = cv_open.Replace(str, "<vc_nepo>");
        //                str = cv_close.Replace(str, "<vc_esolc>");
        //            }
        //            return "\"" + str + "\"";
        //        });
        //    return res;
        //}
        //private static string UnConvertSuperSymbols(string input) {
        //    string val;
        //    val = Regex.Replace(input, "<erugif_nepo>", "{");
        //    val = Regex.Replace(val, "<erugif_esolc>", "}");
        //    val = Regex.Replace(val, "<vc_nepo>", "[");
        //    val = Regex.Replace(val, "<vc_esolc>", "]");
        //    return val;
        //}
        
		public static void Convert(out IPart name, string For_parse) {
            ReactorData data = new ReactorData(For_parse);
            for (int i = 0; i < For_parse.Length; i++) {
                try {
                    library[For_parse[i].ToString()].CreateInstanse(i, data);
                    Console.WriteLine(i);
                }
                catch (Exception err) { }
            }
            name = null;
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