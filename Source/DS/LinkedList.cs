using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading;

namespace SimpleDS
{
    public class LinkedListImpl<T>
    {
        public Node Root { get; set; }

        public Node Add(T value, bool isPrint = true)
        {
            if (value == null) throw new InvalidOperationException("Invalid input");
            var newNode = new Node(value, null);
            if (null == Root) Root = newNode;
            else
            {
                var node = Root;
                while(null != node.Next)
                {
                    node = node.Next;
                }
                node.Next = newNode;
            }
            if (isPrint) Print("After Add " + value + " :");
            return newNode;
        }

        public Node AddAfter(Node node, T value)
        {
            if (node == null || value== null) throw new InvalidOperationException("Invalid input");
            var newNode = new Node(value, node.Next);
            node.Next = newNode;
            Print("After AddAfter " + value + " :");
            return newNode;
        }

        public Node FindFirst(T value)
        {
            Node current = Root;
            Node previous = null;

            if (null == current) return null;
            if (current.Value.Equals(value)) return Root;

            do
            {
                previous = current;
                current = current.Next;

                if (current.Value.Equals(value))
                {
                    Print("After FindFirst " + value + " :");
                    return current;
                }

            } while (null != current.Next);
            Print("After FindFirst " + value + " Not Found : ");
            return null;
        }

        public bool DeleteAfter(Node node)
        {
            var nextNode = node.Next;
            if (null == nextNode) return false; // nothing to delete

            node.Next = nextNode.Next;
            Print("After DeleteAfter " + node.Value + " : ");
            return true;
        }

        public bool Delete(T value)
        {
            if (value == null) throw new InvalidOperationException("Input value is null");
            var node = Root;
            Node previous = null;
            while (node.Next != null)
            {
                if (node.Value.Equals(value))
                {
                    if (previous != null)
                    {
                        previous.Next = node.Next;
                    }
                    else
                    {
                        Root = node.Next;
                    }
                }
                previous = node;
                node = node.Next;
            }
            Print("After Delete " + value + " : ");
            return true;
        }

        public Node Reverse()
        {
            var current = Root;
            Node previous = null;
            if (null == current) return null;

            do
            {
                var temp = previous;
                previous = current;
                current = current.Next;
                previous.Next = temp;

            } while (null != current.Next);
            current.Next = previous;
            Root = current;
            Print("After Reverse : ");
            return null;
        }

        public void Traverse()
        {
            string result = "";
            var node = Root;
            while (node != null)
            {
                result += node.Value + ", ";
                node = node.Next;
            }

            Console.WriteLine(result);
        }

        public void Merge(T[] arritem)
        {
            foreach (var item in arritem)
            {
                Add(item, false);
            }
            Print("After Merge :");
        }
       
        private void Print(string str)
        {
            Console.Write(str + new string(' ', 40 - str.Length < 0 ? 0 : 40 - str.Length));
            Traverse();
        }

        public override string ToString()
        {
            string result = "[";
            var node = Root;

            while (node != null)
            {
                result += node.Value;
                node = node.Next;

                if (null != node) result += ",";
            }

            result += "]";

            return result;
        }

        public class Node
        {
            public Node Next { get; set; }
            public T Value { get; set; }
            public Node(T value, Node next)
            {
                Value = value;
                Next = next;
            }
        }
    }
}
