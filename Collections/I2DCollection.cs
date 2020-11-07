using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtendedCollections
{
    interface I2DCollection<X,Y,T>
    {
        T TryGet(X x, Y y);
        T Get(X x, Y y);
        List<T> GetAllToList();
        List<T> GetInXToList(X x);
        List<T> GetInYToList(Y y);
        void Put(X x, Y y, T value);
        void Remove(X x, Y y);
    }

    interface I2DCollection<T>
    {
        T TryGet(int x, int y);
        T Get(int x, int y);
        List<T> GetAllToList();
        List<T> GetInXToList(int x);
        List<T> GetInYToList(int y);
        List<T> GetAnyInAreaToList(int x1, int x2, int y1, int y2);
        void Put(int x, int y, T value);
        void Remove(int x, int y);
    }
}
