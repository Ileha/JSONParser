using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONParserLibrary
{
    public class MyStack<T>
    {
        private Enemy<T> up;

        public MyStack() {

        }
    }

    class Enemy<T> {
        public Enemy<T> parent;
        public T contain;
        public Enemy(T contain, Enemy<T> parent)
        {
            this.contain = contain;
            this.parent = parent;
        }
    }
}
