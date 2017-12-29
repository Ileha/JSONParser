using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using JSONParserLibrary.Strings;
using JSONParserLibrary.Exeptions;
using System.Xml.Linq;
using System.Xml;

namespace JSONParserLibrary
{
    public class JSONParser
    {
        private MyElement main;

        public MyElement Data {
            get { return main; }
        }

        static Regex reg = new Regex(",");
        static Regex cv_open = new Regex("\\[");
        static Regex cv_close = new Regex("\\]");
        static Regex reg_open = new Regex("{");
        static Regex reg_close = new Regex("}");
        static Regex reg_is_math = new Regex("^[, ]+\"[\\w ]+\":[ ]?[\"]?[\\w/ ]+[\"]?");
        static Regex for_end = new Regex("(\"(?<name>[\\w ]+)\":[ ]?(?<skob>[\"]?)(?<value>[^\"]+)[\"]?)");
        static Regex for_end_arr = new Regex("[, ]+(?<skob>[\"]?)(?<value>[^\"]+)");
        static Regex for_next = new Regex("^[, ]+\"(?<name>[\\w ]+)\":[ ]?(?<body>.+)$");
        static Regex for_next_arr = new Regex("[, ]+(?<body>.+)");
        static Regex reg_cav = new Regex("\"");
        static Regex reg_super_cymbols = new Regex("\"(?<symbols>[^\"]+)\"");
        static Regex not_reg_super_cymbols = new Regex("[ ]?,[ ]?");
        static Regex is_array = new Regex("^(?<is_arr>[{\\[]?)");
        static Regex simple_element = new Regex("([{]+)|([}]+)|([\\[]+)|([\\]]+)");

        public JSONParser(string JSONString) {
            main = ConvertFromJSON(JSONString);
        }
        public JSONParser() {
            main = new MyElement("root");
            main.MyType = MyElementType.structure;
        }
        public string ConvertToJSON() {
            return ConvertToJSON(main);
        }
        public static string ConvertToJSON(MyElement dictionary) {
            string res = "";
            int count = dictionary.Elements().Count();
            foreach (XElement el in dictionary.Elements()) {
                count--;
                MyElement current = el as MyElement;
                if (current.MyType == MyElementType.str) {
                    if (dictionary.MyType != MyElementType.array) { 
                        res += "\"" + current.name + "\": \"" + current.Value + "\"";
                    }
                    else {
                        res += "\"" + current.Value + "\"";
                    }
                }
                else if (current.MyType == MyElementType.nstr) {
                    if (dictionary.MyType != MyElementType.array) { 
                        res += "\"" + current.name + "\": " + current.Value;
                    }
                    else {
                        res += current.Value;
                    }
                }
                else {
                    if (dictionary.MyType != MyElementType.array) { 
                        res += "\""+current.name+"\": "+ConvertToJSON(current);
                    }
                    else {
                        res += ConvertToJSON(current);
                    }
                }
                if (count != 0) { 
                    res += ", ";
                }
            }

            if (dictionary.MyType == MyElementType.array) { return "[" + res + "]"; }
            else if (dictionary.MyType == MyElementType.structure) { return "{" + res + "}"; }
            else { return res; }
        }
        public static MyElement ConvertFromJSON(string For_parse) {
            MyElement el = new MyElement("root");
            Convert(ref el, ConvertSuperSymbols(For_parse));
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
        private static void Convert(ref MyElement name, string For_parse) {
            bool array_is = true;
            if (is_array.Match(For_parse).Groups["is_arr"].Value == "{") {
                array_is = false;
            }

            name.MyType = array_is ? MyElementType.array : MyElementType.structure;
            string for_parse = Regex.Replace(For_parse, "(^[{\\[]{1})|([}\\]]{1})$", ",");
            int value = -1;
            List<string> array = new List<string>();
            foreach (Match m in reg.Matches(for_parse)) {
                if (value == -1) { value = m.Index; }
                else {
                    string sub_str = for_parse.Substring(value, m.Index - value);
                    int fig_open = reg_open.Matches(sub_str).Count;
                    int fig_close = reg_close.Matches(sub_str).Count;
                    int cv_open_count = cv_open.Matches(sub_str).Count;
                    int cv_close_count = cv_close.Matches(sub_str).Count;
                    int count = reg_cav.Matches(sub_str).Count;
                    if (fig_open == fig_close && cv_close_count == cv_open_count && count % 2 == 0) {
                        array.Add(sub_str);
                        value = m.Index;
                    }
                }
            }
            //array.ForEach(c => Console.WriteLine(c));
            int CountArray = 0;
            foreach (string str in array) {
                if (array_is == true) {
                    Match m;
                    if (!simple_element.IsMatch(str)) {
                        m = for_end_arr.Match(str);
                        string val = UnConvertSuperSymbols(m.Groups["value"].Value);
                        MyElement new_el = new MyElement(CountArray.ToString());
                        new_el.MySetValue(val);
                        new_el.MyType = m.Groups["skob"].Value == "" ? MyElementType.nstr : MyElementType.str;
                        name.Add(new_el);
                    }
                    else {
                        m = for_next_arr.Match(str);
                        MyElement element = new MyElement(CountArray.ToString());
                        Convert(ref element, m.Groups["body"].Value);
                        name.Add(element);
                    }
                    CountArray++;
                }
                else {
                    if (reg_is_math.IsMatch(str)) {
                        foreach (Match m in for_end.Matches(str)) {
                            string val = UnConvertSuperSymbols(m.Groups["value"].Value);
                            MyElement new_el = new MyElement(m.Groups["name"].Value);
                            new_el.MySetValue(val);
                            new_el.MyType = m.Groups["skob"].Value == "" ? MyElementType.nstr : MyElementType.str;
                            name.Add(new_el);
                        }
                    }
                    else {
                        foreach (Match m in for_next.Matches(str)) {
                            MyElement element = new MyElement(m.Groups["name"].Value);
                            Convert(ref element, m.Groups["body"].Value);
                            name.Add(element);
                        }
                    }
                }
            }
        }
        public MyElement this[string index] {
            get {
                string[] elements = index.Split('.');
                MyElement res = main;
                for (int i = 0; i < elements.Length; i++) {
                    try { 
                        res = (from k in res.Elements()
                               where k.Attribute("name").Value == elements[i]
                               select k).First() as MyElement;
                    }
                    catch (InvalidOperationException err) {
                        throw new FielNotFound(elements[i]);
                    }
                }
                return res;
            }
        }
    }
}