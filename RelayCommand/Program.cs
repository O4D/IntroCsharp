using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LesRelayCommand
{
    class Program
    {
        static void Main(string[] args)
        {
            InitialiserRelayCommandEtActions();
        }

        delegate int DelegateCalcul(int i);
        delegate void DelegateQueuDal();

        private static void InitialiserRelayCommandEtActions()
        {
            //Définit la fonction local affectée au délégué "calcul" prenant un int en paramètre
            DelegateCalcul calcul = x => x * x;
            DelegateQueuDal queDal = DoTheThing;

            ICommand rC1 = new RelayCommand<object>((object param) => DoTheThing());
            ICommand rC2 = new RelayCommand<object>(delegate (object obj) { DoTheThing(); });
            ICommand rC3 = new RelayCommand<object>(DoTheThingOBJ);
            //ICommand rC4 = new RelayCommand<object>(queDal);//Ne fonctionne pas
            Action<object> monAction = new Action<object>(DoTheThingOBJ);
            ICommand rC5 = new RelayCommand<object>(monAction);
        }

        private static void DoTheThing()
        {
            Console.WriteLine("DoTheThing");
        }

        private static void DoTheThingOBJ(object ob)
        {
            Console.WriteLine("DoTheThing");
        }
    }
}
