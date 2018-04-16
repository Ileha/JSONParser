using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONParserLibrary
{
    public class MyQueue<T> {
        private Enemy<T> up;
        //private Enemy<T> down;

        public MyQueue() {
            //k.Enqueue
            //k.Dequeue
            //k.Peek
        }

        //public MyQueue(Enemy<T> first) {
        //    up = first;
        //}
        public T Dequeue()
        {
            T res = up.contain;
            Enemy<T> new_up = up.child;
            up.Dispose();
            up = new_up;
            return res;
        }

        public T Peek() {
            return up.contain;
        }
    }

    public class MyStack<T>
    {
        private Enemy<T> up;

        public MyStack() {}

        public void Push(T element) {
            Enemy<T> el = new Enemy<T>(element, up);
            up.child = el;
            up = el;
        }
        public T Peek() {
            return up.contain;
        }
        public T Pop() {
            T res = up.contain;
            Enemy<T> new_up = up.parent;
            up.Dispose();
            up = new_up;
            return res;
        }
    }

    class Enemy<T> : IDisposable {
        public Enemy<T> parent;
        public T contain;
        public Enemy<T> child;
        public Enemy(T contain, Enemy<T> parent)
        {
            this.contain = contain;
            this.parent = parent;
        }

        public void Dispose() {
            try {
                parent.child = null;
                parent = null;
            }
            catch (Exception err) {}
            try {
                child.parent = null;
                child = null;
            }
            catch (Exception err) {}
        }
    }
}
