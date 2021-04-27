using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtendedCollections
{
    public struct Point2D
    {
        public int i { get; set; }
        public int j { get; set; }

        public Point2D(int i, int j)
        {
            this.i = i;
            this.j = j;
        }

        public override int GetHashCode()
        {
            const uint hash = 0x9e3779b9;
            var seed = i + hash;
            seed ^= j + hash + (seed << 6) + (seed >> 2);
            return (int)seed;
        }

        public override bool Equals(object obj)
        {
            return obj is Point2D d &&
                   i == d.i &&
                   j == d.j;
        }
    }

    public struct Point2D<I,J>
    {
        public I i { get; set; }
        public J j { get; set; }

        public Point2D(I i, J j)
        {
            this.i = i;
            this.j = j;
        }

        public override int GetHashCode()
        {
            int hash = 0;
            hash ^= i.GetHashCode();
            hash ^= j.GetHashCode();
            return hash;
        }

        public override bool Equals(object obj)
        {
            return obj is Point2D<I, J> d &&
                   i.Equals(d.i) &&
                   j.Equals(d.j);
        }
    }
}
