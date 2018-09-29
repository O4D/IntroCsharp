using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesExceptions
{
    class MyException : Exception
    {
        public string myProperty { get; set; }

        public MyException(string mess) : base(mess)
        {
            myProperty = mess;
        }
    }
}
