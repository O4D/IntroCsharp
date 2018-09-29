using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesParams
{
    class Program
    {
        static void Main(string[] args)
        {
            UtiliserParams();
        }

        private static void UtiliserParams()
        {
            TakeThis(1, 2, 3, 1, 2, 4);
            TakeThis(1, "saucisson", 3, 1, 2, 4);

            Console.ReadLine();
        }

        private static void TakeThis(params int[] list)
        {
            foreach (int i in list)
                Console.WriteLine(i);
        }

        private static void TakeThis(params object[] list)
        {
            for (int i = 0; i < list.Length; i++)
                Console.WriteLine(list[i]);
        }

    }
}
