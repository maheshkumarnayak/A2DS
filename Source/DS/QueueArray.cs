using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleDS
{
    public class QueueArrayImlp<T>
    {
        private T[] _storage;
        private int _startIndex;
        private int _lastIndex;
        private int _count;
        public QueueArrayImlp() : this(10) { }
        public QueueArrayImlp(int length)
        {
            if (length < 1) throw new ArgumentOutOfRangeException(nameof(length));
            _storage = new T[length];
            _count = 0;
            _startIndex = -1;
            _lastIndex = -1;
            Console.WriteLine("Array Queue Implementation");
        }

        private void ExpandStorage()
        {
            var newStorage = new T[_storage.Length * 2];
            Array.Copy(_storage, newStorage, _storage.Length);
            _storage = newStorage;
        }

        private void ValidateIndex(int index)
        {
            if (index < 0 || index > _lastIndex)
                throw new ArgumentOutOfRangeException(nameof(index));
        }

        private void Print(string str)
        {
            Console.Write(str + new string(' ', 40 - str.Length < 0 ? 0 : 40 - str.Length));
            Traverse();
        }

        public void Enqueue(T item, bool isPrint = true)
        {
            if (_storage.Length == _count)
                ExpandStorage();

            _count++; _lastIndex++;
            if (_lastIndex == _storage.Length) _lastIndex = 0;
            _storage[_lastIndex] = item;

            if (_startIndex == -1) _startIndex = 0;

            if (isPrint) Print("After Enqueue " + item + " :");
        }

        public T Dequeue()
        {
            if (_count == 0) throw new InvalidOperationException("Queue is empty");

            _count--;
            T item = _storage[_startIndex++];
            if (_startIndex == _storage.Length) _startIndex = 0;

            if (_count == 0)
            {
                _startIndex = 0;
                _lastIndex = 0;
            }


            Print("After Dequeue got -" + item + " :");
            return item;
        }

        public T Peek()
        {
            if (_lastIndex < 0) throw new InvalidOperationException("Queue is empty");
            T item = _storage[_startIndex];

            Print("After Peek got -" + item + " :");
            return item;
        }

        public void Clear()
        {
            int length = 10;
            _storage = new T[length];
            _count = length;
            _startIndex = -1;
            _lastIndex = -1;
            Print("After Clear :");
        }

        public void Sort()
        {
            throw new NotImplementedException();
        }

        public void Search(T item)
        {
            int bufferIndex = _startIndex;
            for (int i = 0; i < _count; i++)
            {
                if (object.Equals(_storage[bufferIndex++], item))
                {
                    Print("After Search Item " + item + " found on index " + i + " :");
                    break;
                }
                if (bufferIndex == _storage.Length) bufferIndex = 0;
            }
            Print("After Search Item No item found");
        }

        public void Merge(T[] arritem)
        {
            foreach (var item in arritem)
            {
                Enqueue(item, false);
            }
            Print("After Merge :");
        }

        public void Traverse()
        {
            int bufferIndex = _startIndex;
            for (int i = 0; i < _count; i++)
            {
                Console.Write(_storage[bufferIndex++] + ", ");
                if (bufferIndex == _storage.Length) bufferIndex = 0;
            }
            Console.WriteLine("");
        }

        public T[] ToArray()
        {
            T[] newArray = new T[_lastIndex + 1];
            for (int i = 0; i <= _lastIndex; i++)
            {
                newArray[i] = _storage[_lastIndex - i];
            }
            return newArray;
        }
    }
}
