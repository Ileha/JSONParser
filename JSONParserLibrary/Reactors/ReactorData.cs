using System.Collections.Generic;

namespace JSONParserLibrary.Reactors
{
    public class ReactorData {
        public readonly Queue<AbstractReactor> Order;
		private readonly Stack<IPart> Current;
		public IPart root { get; private set; }
		public string JSONData { get; private set; }

		/*
			Push: добавляет элемент в стек на первое место
			Pop: извлекает и возвращает первый элемент из стека
			Peek: просто возвращает первый элемент из стека без его удаления
		*/

        public ReactorData(string JSONObject) {
            Order = new Queue<AbstractReactor>();
			Current = new Stack<IPart>();
			JSONData = JSONObject;
        }

		public bool IsEmpty() {
			return root == null;
		}
		public void Push(IPart element) {
			if (root == null) {
				root = element;
			}
			Current.Push(element);
		}
		public IPart Pop() {
			return Current.Pop();
		}
		public IPart Peek() {
			return Current.Peek();
		}
    }
}
