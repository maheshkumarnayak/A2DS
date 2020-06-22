using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace SimpleDS
{
    public class StackArrayImpl<T> 
    {
        private T[] _storage;
        private int _lastIndex;
        public StackArrayImpl()
        {
            Console.WriteLine("Stack Implementation");
            _storage = new T[10];
            _lastIndex = -1;
        }
        public StackArrayImpl(int length)
        {
            if (length < 1) throw new ArgumentOutOfRangeException(nameof(length));
            _storage = new T[length];
            _lastIndex = -1;
            
        }
        public StackArrayImpl(T[] arr)
        {
            if (arr == null) throw new ArgumentOutOfRangeException(nameof(arr));

            _storage = arr;
            _lastIndex = _storage.Length - 1;
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

        public void Push(T item, bool isPrint = true)
        {
            if (_lastIndex == _storage.Length - 1)
                ExpandStorage();

            _lastIndex++;
            _storage[_lastIndex] = item;

            if (isPrint) Print("After Push " + item + " :");
        }

        public T Pop()
        {
            if (_lastIndex < 0) throw new InvalidOperationException("Stack is empty");
            T item = _storage[_lastIndex--];
            Print("After Pop got -" + item + " :");
            return item;
        }

        public T Peek()
        {
            if (_lastIndex < 0) throw new InvalidOperationException("Stack is empty");
            T item = _storage[_lastIndex];
            Print("After Peek got -" + item + " :");
            return item;
        }

        public void Clear()
        {
            _storage = new T[10];
            _lastIndex = -1;
            Print("After Clear :");
        }

        public void Sort()
        {
            T temp;
            for (int i = 0; i < _lastIndex; i++)
            {
                for (int j = 0; j < _lastIndex; j++)
                {
                    if (Convert.ToInt32(_storage[j]) > Convert.ToInt32(_storage[j + 1]))
                    {
                        temp = _storage[j + 1];
                        _storage[j + 1] = _storage[j];
                        _storage[j] = temp;
                    }
                }
            }
            Print("After Sorting :");
        }

        public void Search(T item)
        {
            for (int j = 0; j <= _lastIndex; j++)
            {
                if (_storage[j].Equals(item))
                {
                    Print("After Search Item " + item + " found on index " + j + " :");
                    break;
                }
            }
        }

        public void Merge(T[] arritem)
        {
            foreach(var item in arritem)
            {
                Push(item,false);
            }
            Print("After Merge :");
        }

        public void Traverse()
        {
            for (int i = _lastIndex; i >= 0; i--)
                Console.Write(_storage[i] + ", ");
            Console.WriteLine("");
        }

        public T[] ToArray()
        {
            T[] newArray = new T[_lastIndex+1];
            for (int i = 0; i <= _lastIndex; i++)
            {
                newArray[i] = _storage[_lastIndex - i];
            }
            return newArray;
        }
    }
}
