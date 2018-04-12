using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONParserLibrary.Reactors
{
    public abstract class AbstractReactor {
        private string _react;
        public string React { get { return _react; } }
        public abstract int index { get; }

        public AbstractReactor(string react_word) {
            _react = react_word;
        }

        public abstract void CreateInstanse(int index, ReactorData data);
    }
}
