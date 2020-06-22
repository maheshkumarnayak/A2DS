using System;

namespace SimpleDS
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestCase(new ArrayImpl<int>());
            //StackTestCase();
            //LinkedStackTestCase();
            //QueueArrayTestCase();
            //QueueLinkedTestCase();
            //LinkedListTestCase();

            TestValueType();

            Console.ReadLine();
        }


        public static void TestValueType()
        {

        }



        static void TestCase(IOperation<int> obj)
        {
            obj.Merge(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
            obj.Add(5);
            obj.Insert(4, 2);
            obj.Delete(1);
            obj.DeleteItem(4);
            obj.Sort();
            obj.Add(2);
            obj.Sort();
            obj.Search(5);
        }
        static void StackTestCase()
        {
            StackArrayImpl<int> obj = new StackArrayImpl<int>();
            obj.Merge(new int[] { 1, 2, 3, 4, 5 });
            obj.Push(3);
            obj.Peek();
            obj.Pop();
            obj.Pop();
            obj.Pop();
            obj.Push(5);
        }
        static void LinkedStackTestCase()
        {
            StackLinkedImpl<int> obj = new StackLinkedImpl<int>();
            obj.Merge(new int[] { 1, 2, 3, 4, 5 });
            obj.Push(3);
            obj.Peek();
            obj.Pop();
            obj.Pop();
            obj.Pop();
            obj.Push(5);
        }
        static void QueueArrayTestCase()
        {
            QueueArrayImlp<int> obj = new QueueArrayImlp<int>();
            obj.Merge(new int[] { 1, 2, 3, 4, 5 });
            obj.Enqueue(3);
            obj.Peek();
            obj.Dequeue();
            obj.Dequeue();
            obj.Dequeue();
            obj.Enqueue(5);
        }
        static void QueueLinkedTestCase()
        {
            QueueLinkedImpl<int> obj = new QueueLinkedImpl<int>();
            obj.Merge(new int[] { 1, 2, 3, 4, 5 });
            obj.Enqueue(3);
            obj.Peek();
            obj.Dequeue();
            obj.Dequeue();
            obj.Dequeue();
            obj.Enqueue(5);
        }
        static void LinkedListTestCase()
        {
            LinkedListImpl<int> obj = new LinkedListImpl<int>();
            obj.Merge(new int[] { 1, 2, 3, 4, 5 });
            var newlyadded = obj.Add(8, true);
            var newlyadded2 = obj.Add(7, true);
            obj.AddAfter(newlyadded, 11);
            obj.FindFirst(8);
            obj.Reverse();
            obj.AddAfter(newlyadded2, 13);
            obj.AddAfter(newlyadded, 15);
            obj.Reverse();
            obj.DeleteAfter(newlyadded);
            obj.Delete(4);

        }

    }
}
