using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    public class Node<T>
    {
        public T Value { get; set; }

        public List <Node<T>> Childred { get; set; }

        public bool HasParent { get; set; } // добавяме свойство

        public Node() // конструкор
        {
            this.Childred = new List<Node<T>>();
        }
        public Node(T value) // конструкор който приема стойност
            : this()
        {
            this.Value = value;
        }
    }
}
