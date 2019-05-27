using System;

namespace JSONParserLibrary.Reactors
{
	public abstract class AbstractReactorFabric
	{
		public abstract char Name { get; }

		public abstract AbstractReactor CreateInstanse(int index);
	}

    public abstract class AbstractReactor {
        public char react { get; private set; }
        public int index { get; private set; }

        public AbstractReactor(char react_word, int _index) {
            react = react_word;
            index = _index;
        }

		public void WorkDeb(ReactorData data) {
			Console.WriteLine(react);
			Work(data);
		}
        public abstract void Work(ReactorData data);
    }
}
