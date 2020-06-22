using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleDS
{
    interface IOperation<T>
    {
        void Add(T item);
        void Insert(T item, int index);
        void DeleteItem(T item);
        void Delete(int index);
        void Sort();
        void Search(T item);
        void Merge(T[] arritem);
        void Traverse();
    }


}
