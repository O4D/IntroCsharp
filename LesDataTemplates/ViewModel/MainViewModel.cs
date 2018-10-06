using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LesDataTemplates.Model;

namespace LesDataTemplates.ViewModel
{
    class MainViewModel
    {
        public List<Square> Elements { get; set; }
        public List<int> ElementsInt;
        public int UnInt = 1;
        public string UnString = "Lalala";

        public MainViewModel()
        {
            Elements = new List<Square>();
            Elements.Add(new Square());
            Elements.Add(new Square());
            Elements.Add(new Square());

            ElementsInt = new List<int>();
            ElementsInt.Add(0);
            ElementsInt.Add(1);
            ElementsInt.Add(2);
        }
    }
}
