using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp16
{
    internal class Class1
    {
        public int flip(int bit)
        {
            return 1 ^ bit;
        }

        //Возвращаем 1, если число положительное, и 0, если отрицательное
        public int sign(int a)
        {
            int temp = (a >> 31) & 0x1;
            int temp1 = flip(temp);
            return temp1;
        }

        public int getMax(int a, int b)
        {
            int k = sign(a - b);
            int q = flip(k);
            return a * k + b * q;
        }





        public int MaximumNeg(int a, int b)
        {
            if (a > 0 || b > 0)
            {
                return 1;
            }

            return -1 + MaximumNeg(++a,++b);
        }





        public int Maximum(int a, int b)
        {
            if (a < 0 && b < 0)
            {
                return -1;
            }

            return 1 + Maximum(--a, --b);
        }
    }
}
