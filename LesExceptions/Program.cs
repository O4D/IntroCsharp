using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesExceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            MakeACalcul();
            Console.ReadLine();
        }

        static double SafeDivision(double x, double y)
        {
            if (y == 0)
                throw new MyException("Exception non basique");

            return x / y;
        }

        static double SafeDivisionOnSystemException(double i, double y)
        {
            Exception exc = new Exception("Exception basique");
            if (i == 0 || y == 0)
                throw exc;

            return i / y;

        }

        public static void MakeACalcul()
        {
            double a = 98, b = 0;
            double result = 0;

            try
            {
                result = SafeDivision(a, b);
                Console.WriteLine("{0} divided by {1} = {2}", a, b, result);
            }
            catch (MyException e)
            {
                //Console.WriteLine("There's an exception ! : "+e.myProperty);
                throw;
            }


            try
            {
                result = SafeDivisionOnSystemException(0, 28);
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
