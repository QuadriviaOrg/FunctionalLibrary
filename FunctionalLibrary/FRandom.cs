using System;

namespace Quadrivia.FunctionalLibrary
{
    public class FRandom
    {
        public readonly int Number;
        private readonly uint U;
        private readonly uint V;
        internal FRandom(int result, uint u, uint v)
        {
            Number = result;
            U = u;
            V = v;
        }

        //Create Random initialied with an explicit seed
        internal FRandom(uint u, uint v)
        {
            U = u;
            V = v;
        }

        public static FRandom Seed(uint u, uint v)
        {
            return new FRandom(u, v);
        }
        public static FRandom Seed(DateTime clockNow)
        {
            //TODO: shouldn't this be AND rather than shift?
            return new FRandom((uint)DateTime.Now.Ticks >> 16, 0);
        }

        public static FRandom Next(FRandom previous, int minValue, int maxValue)
        {
            var u = previous.U;
            var v = previous.V;
            uint u2 = 36969 * (u & 65535) + (u >> 16);
            uint v2 = 18000 * (v & 65535) + (v >> 16);
            double r1 = ((u2 << 16) + v2 + 1.0) * 2.328306435454494e-10;
            int r2 = (int) (minValue + r1 * (maxValue - minValue));
            return new FRandom(r2, u2, v2);
        }


    }
}

