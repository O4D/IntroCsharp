using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesGeneriques
{
    class DataRecuperator<T>
    {
        private T data;
        public T Data { get {
                return data;
            } set { data = value; } }

        public int Iterator { get; set; }

        public DataRecuperator(T param) : this(param,2)
        {
        }

        public DataRecuperator(T param, int nb)
        {
            data = param;
            Iterator = nb;
        }

        /*
         * On NE peut PAS apeller une autre méthode automatiquement à la manière du contructeur this(value)
        public T GetMyData() //: this.GetMyData(1)
        { }

        public T GetMyData(int it)
        {
            T currentData = data;
            if (it > 1)
                for (int i = 1; i < it; i++)
                    Console.Write(i+" iterations");
        }
        */
    }
}
