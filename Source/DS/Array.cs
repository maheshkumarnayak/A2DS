using System;

namespace SimpleDS
{
    public class ArrayImpl<T> : IOperation<T>
    {
        private T[] _storage;
        private int _lastIndex;
        public ArrayImpl()
        {
            _storage = new T[10];
            _lastIndex = -1;
        }
        public ArrayImpl(T[] arr)
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

        public void Add(T item)
        {
            if (_lastIndex == _storage.Length - 1)
                ExpandStorage();

            _lastIndex++;
            _storage[_lastIndex] = item;

            Print("After Add " + item + " :");
        }

        public void Insert(T item, int index)
        {
            ValidateIndex(index);
            if (_lastIndex == _storage.Length - 1)
                ExpandStorage();

            int j = _lastIndex;

            while (j >= index)
            {
                _storage[j + 1] = _storage[j];
                j--;
            }

            _storage[index] = item;
            _lastIndex++;
            Print("After Insert " + item + " on index " + index + " :");
        }

        public void DeleteItem(T item)
        {
            int k = _lastIndex;
            while (k >= 0)
            {
                if (_storage[k].Equals(item))
                {
                    Delete(k);
                }

                k--;
            }
            Print("After DeleteItem " + item + " :");
        }

        public void Delete(int index)
        {
            int j = index;

            while (j < _lastIndex)
            {
                _storage[j] = _storage[j + 1];
                j++;
            }

            _lastIndex--;
            Print("After Delete on index " + index + " :");
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
                if (_lastIndex == _storage.Length - 1)
                    ExpandStorage();

                _lastIndex++;
                _storage[_lastIndex] = item;
            }
            Print("After Merge :");
        }

        public void Traverse()
        {
            for (int i = 0; i <= _lastIndex; i++)
                Console.Write(_storage[i] + ", ");
            Console.WriteLine("");
        }
    }
}
