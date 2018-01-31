using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using JSONParserLibrary.Exeptions;
using System.Xml.Linq;

namespace JSONParserLibrary
{
    public class JSONParser
    {
        private IPart main;

        public IPart Data {
            get { return main; }
        }

		private Type type_struct = typeof(PartStruct);
		private Type type_array = typeof(PartArray);

        private static Regex reg = new Regex(",");
        private static Regex cv_open = new Regex("\\[");
        private static Regex cv_close = new Regex("\\]");
        private static Regex reg_open = new Regex("{");
        private static Regex reg_close = new Regex("}");
        private static Regex for_end = new Regex("(\"(?<name>[\\w ]+)\":[ ]?(?<skob>[\"]?)(?<value>[^\"]+)[\"]?)");
       	private static Regex for_end_arr = new Regex("[, ]+(?<skob>[\"]?)(?<value>[^\"]+)");
       	private static Regex for_next = new Regex("^[, ]+\"(?<name>[\\w ]+)\":[ ]?(?<body>.+)$");
       	private static Regex for_next_arr = new Regex("[, ]+(?<body>.+)");
       	private static Regex reg_cav = new Regex("\"");
        private static Regex reg_super_cymbols = new Regex("\"(?<symbols>[^\"]+)\"");
        private static Regex not_reg_super_cymbols = new Regex("[ ]?,[ ]?");
        private static Regex is_array = new Regex("^(?<is_arr>[{\\[]?)");
       	private static Regex simple_element = new Regex("([{]+)|([}]+)|([\\[]+)|([\\]]+)");

        public JSONParser(string JSONString) {
            main = ConvertFromJSON(JSONString);
        }
        public JSONParser(IPart root) {
			main = root;
        }
        public string ConvertToJSON() {
			return main.ValueToJSON();
        }
		public static IPart ConvertFromJSON(string For_parse) {
			IPart el;
            Convert(out el, "root", ConvertSuperSymbols(For_parse));
            return el;
        }
        private static string ConvertSuperSymbols(string input) {
            string res = reg_super_cymbols.Replace(input,
                m => {
                    string str = m.Groups["symbols"].Value;
                    if (!not_reg_super_cymbols.IsMatch(str)) {
                        str = reg_open.Replace(str, "<erugif_nepo>");
                        str = reg_close.Replace(str, "<erugif_esolc>");
                        str = cv_open.Replace(str, "<vc_nepo>");
                        str = cv_close.Replace(str, "<vc_esolc>");
                    }
                    return "\"" + str + "\"";
                });
            return res;
        }
        private static string UnConvertSuperSymbols(string input) {
            string val;
            val = Regex.Replace(input, "<erugif_nepo>", "{");
            val = Regex.Replace(val, "<erugif_esolc>", "}");
            val = Regex.Replace(val, "<vc_nepo>", "[");
            val = Regex.Replace(val, "<vc_esolc>", "]");
            return val;
        }
        
		private static void Convert(out IPart name, string part_name, string For_parse) {
            bool array_is = true;
            if (is_array.Match(For_parse).Groups["is_arr"].Value == "{") {
                array_is = false;
            }

			if (array_is) { name = new PartArray(part_name); }
			else { name = new PartStruct(part_name); }
			string for_parse = Regex.Replace(For_parse, "(^[{\\[]{1})|([}\\]]{1})$", ",");
            int value = -1;
			//List<string> array = new List<string>()
			MatchCollection collect = reg.Matches(for_parse);
			string[] array = new string[collect.Count];
			int iterator = 0;
            foreach (Match m in collect) {
                if (value == -1) { value = m.Index; }
                else {
                    string sub_str = for_parse.Substring(value, m.Index - value);
                    int fig_open = reg_open.Matches(sub_str).Count;
                    int fig_close = reg_close.Matches(sub_str).Count;
                    int cv_open_count = cv_open.Matches(sub_str).Count;
                    int cv_close_count = cv_close.Matches(sub_str).Count;
                    int count = reg_cav.Matches(sub_str).Count;
                    if (fig_open == fig_close && cv_close_count == cv_open_count && count % 2 == 0) {
						//array.Add(sub_str);
						array[iterator] = sub_str;
                        value = m.Index;
						iterator++;
                    }
                }
            }
			//Console.WriteLine("start");
   			//array.ForEach(c => Console.WriteLine(c));
			//Console.WriteLine("end");
            int CountArray = 0;
            foreach (string str in array) {
				if (str == null || str == "") { return; }
				Match m;
                if (array_is == true) {
                    if (!simple_element.IsMatch(str)) {
                        m = for_end_arr.Match(str);
                        string val = UnConvertSuperSymbols(m.Groups["value"].Value);
						IPart new_el;
						if (m.Groups["skob"].Value == "") {
							//new_el = new Part(CountArray.ToString(), name, new PartNotString(val));
							//new_el = new Part(CountArray.ToString(), new PartNotString(val));
							new_el = new PartNotString(CountArray.ToString(), val);
						}
						else {
							//new_el = new Part(CountArray.ToString(), name, new PartString(val));
							//new_el = new Part(CountArray.ToString(), new PartString(val));
							new_el = new PartString(CountArray.ToString(), val);
						}
						name.AddPart(new_el);
                    }
                    else {
                        m = for_next_arr.Match(str);
                        //Part element = new Part(CountArray.ToString(), name);
						IPart element; //new Part(CountArray.ToString());
                        Convert(out element, CountArray.ToString(), m.Groups["body"].Value);
                        name.AddPart(element);
                    }
                    CountArray++;
                }
                else {
                    if (!simple_element.IsMatch(str)) {
						m = for_end.Match(str);
                        string val = UnConvertSuperSymbols(m.Groups["value"].Value);
						IPart new_el;
						if (m.Groups["skob"].Value == "") {
							//new_el = new Part(m.Groups["name"].Value, name, new PartNotString(val));
							//new_el = new Part(m.Groups["name"].Value, new PartNotString(val));
							new_el = new PartNotString(m.Groups["name"].Value, val);
						}
						else {
							//new_el = new Part(m.Groups["name"].Value, name, new PartString(val));
							//new_el = new Part(m.Groups["name"].Value, new PartString(val));
							new_el = new PartString(m.Groups["name"].Value, val);
						}
                        name.AddPart(new_el);
                    }
                    else {
						m = for_next.Match(str);
						//Part element = new Part(m.Groups["name"].Value, name);
						IPart element;// = new Part(m.Groups["name"].Value);
                        Convert(out element, m.Groups["name"].Value, m.Groups["body"].Value);
                        name.AddPart(element);
                    }
                }
            }
        }

        public IPart this[string index] {
            get {
                string[] elements = index.Split('.');
                IPart res = main;
                for (int i = 0; i < elements.Length; i++) {
					//Console.WriteLine("element: {0} - ", elements[i]);
					try {
						if (res.GetType() == type_array) {
							res = res.GetPart(System.Convert.ToInt32(elements[i]));
						}
						else if (res.GetType() == type_struct) {
							res = res.GetPart(elements[i]);
						}
						else {
							throw new FielNotFound(elements[i]); ;
						}
					}
					catch (FielNotFound err2) {
						throw err2;
					}
					catch (Exception err) {
                        throw new FielNotFound(elements[i]);
                    }
                }
                return res;
            }
        }
    }
}