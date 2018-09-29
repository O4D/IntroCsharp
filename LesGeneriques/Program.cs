using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LesGeneriques
{
    class Program
    {
        
        private string name;
        private string lgname;

        public void UpdateBDD(int id) => Console.Write("BDD Updated"); 

        static void Main(string[] args)
        {
            UtiliserListeTypeGenerique();

            UtiliserClasseTypeGenerique();            

        }


        private static void UtiliserListeTypeGenerique()
        {
            MaListeGenerique<int> mlgE = new MaListeGenerique<int>();

            for (int x = 0; x < 10; x++)
            {
                mlgE.AddHead(x);
            }

            foreach (int ite in mlgE)
            {
                Console.Write(ite + " ");
            }

            Console.WriteLine("\n FIN");
            Console.ReadLine();
        }

        private static void UtiliserClasseTypeGenerique()
        {
            DataRecuperator<int> dR = new DataRecuperator<int>(5);
            Console.WriteLine("\n" + dR.Data + "|" + dR.Iterator);

            DataRecuperator<string> dR2 = new DataRecuperator<string>("cacahouette");
            Console.WriteLine("\n" + dR2.Data);
            Console.ReadLine();
        }

       
        

        


        

        
    }
}
