using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleDS
{
    public class QueueLinkedImpl<T>
    {
        public QueueLinkedImpl()
        {
            Console.WriteLine("Linked Queue Implementation");
        }
        protected Node Head { get; set; }

        protected Node Tail { get; set; }

        public void Enqueue(T value, bool isPrint = true)
        {
            var valueNode = new Node(value, null);
            if (null == Tail)
            {
                Head = valueNode;
                Tail = Head;
                return;
            }

            Tail.Next = valueNode;
            Tail = valueNode;

            if (isPrint) Print("After Enqueue " + value + " :");
        }

        public T Dequeue()
        {
            if (null == Head) throw new InvalidOperationException("The queue is empty!");

            var result = Head.Value;
            Head = Head.Next;
            Print("After Dequeue got -" + result + " :");
            return result;
        }

        public T Peek()
        {
            if (null == Head) throw new InvalidOperationException("The queue is empty!");
            Print("After Peek got -" + Head.Value + " :");
            return Head.Value;
        }

        public void Traverse()
        {
            string result = "";
            var node = Head;
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
                Enqueue(item, false);
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
            var node = Head;

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
