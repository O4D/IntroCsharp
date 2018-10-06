using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LesDataTemplates.Model;

namespace LesDataTemplates.ViewModel
{
    class MainViewModel// : BaseViewModel
    {
        public List<object> Elements { get; set; }
        //public PopinViewModel Popin { get; set; }
        //public RelayCommand<object> PopinCommand { get; set; }

        public MainViewModel()
        {
            Elements = new List<object>();
            Elements.Add(new Square());
            Elements.Add(new Square());
            Elements.Add(new Circle());
            Elements.Add(new Square());
            Elements.Add(new Circle());

            //PopinCommand = new RelayCommand<object>(onPopin);
        }

        //private void onPopin(object obj)
        //{
        //    if (Popin == null)
        //    {
        //        Popin = new PopinViewModel();
        //        Popin.CloseHandler = ClosePopin;
        //        Notify("Popin");
        //    }
        //}

        //private void ClosePopin()
        //{
        //    Popin = null;
        //    Notify("Popin");
        //}
    }
}
