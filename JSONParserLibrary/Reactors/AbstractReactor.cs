using System;

namespace JSONParserLibrary.Reactors
{
	public abstract class AbstractReactorFabric
	{
		public abstract string Name { get; }

		public abstract AbstractReactor CreateInstanse(int index);
	}

    public abstract class AbstractReactor {
		private int _index;
        private string _react;
        public string React { get { return _react; } } 
		public int index { get { return _index; } }

        public AbstractReactor(string react_word, int _index) {
            _react = react_word;
			this._index = _index;
        }

		public void WorkDeb(ReactorData data) {
			Console.WriteLine(React);
			Work(data);
		}
        public abstract void Work(ReactorData data);
    }
}
