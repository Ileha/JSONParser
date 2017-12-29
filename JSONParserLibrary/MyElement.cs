using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using JSONParserLibrary.Exeptions;

namespace JSONParserLibrary
{
    public enum MyElementType {
        str,
        nstr,
        array,
        structure
    }
    public class MyElement : XElement {
        public string name {
            get { return this.Attribute("name").Value; }
            set { SetAttributeValue("name", value); }
        }
        public MyElementType MyType;

        public MyElement(string name, MyElementType my_type) : base("element") {
            this.name = name;
            MyType = my_type;
        }
        public MyElement(string name) : base("element") {
            this.name = name;
        }

        public void MyAdd(MyElement element) {
            if (MyType == MyElementType.array) {
                element.name = this.Elements().Count().ToString();
                this.Add(element);
            }
            else if (MyType == MyElementType.structure) {
                this.Add(element);
            }
            else {
                throw new OperationNotAllowed("MyAdd");
            }
        }
        public void MySetValue(string val) {
            if (MyType == MyElementType.nstr || MyType == MyElementType.str) {
                MyType = MyElementType.str;
                Value = val;
            }
            else {
                throw new OperationNotAllowed("MySetValue");
            }
        }
        public void MySetValue(int val) {
            if (MyType == MyElementType.nstr || MyType == MyElementType.str) {
                MyType = MyElementType.nstr;
                Value = val.ToString();
            }
            else {
                throw new OperationNotAllowed("MySetValue");
            }
        }
        public void MySetValue(float val) {
            if (MyType == MyElementType.nstr || MyType == MyElementType.str) {
                MyType = MyElementType.nstr;
                Value = val.ToString();
            }
            else {
                throw new OperationNotAllowed("MySetValue");
            }
        }
        public void MySetValue(bool val) {
            if (MyType == MyElementType.nstr || MyType == MyElementType.str) {
                MyType = MyElementType.nstr;
                Value = val ? "true" : "false";
            }
            else {
                throw new OperationNotAllowed("MySetValue");
            }
        }
        public void MySetNull() {
            this.RemoveNodes();
            MyType = MyElementType.nstr;
            Value = "null";
        }

        public static MyElement Create(string name, string value) {
            MyElement el = new MyElement(name);
            el.MySetValue(value);
            return el;
        }
        public static MyElement Create(string name, bool value) {
            MyElement el = new MyElement(name);
            el.MySetValue(value);
            return el;
        }
        public static MyElement Create(string name, int value) {
            MyElement el = new MyElement(name);
            el.MySetValue(value);
            return el;
        }
        public static MyElement Create(string name, float value) {
            MyElement el = new MyElement(name);
            el.MySetValue(value);
            return el;
        }
    }
}
