using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LesDataTemplates.Model;

namespace LesDataTemplates.ViewModel
{
    class PopinViewModel : BaseViewModel
    {
        public Action CloseHandler { get; set; }
        public RelayCommand<object> QuitCommand { get; set; }

        public PopinViewModel()
        {
            QuitCommand = new RelayCommand<object>(onQuit);
        }

        private void onQuit(object ob)
        {
            if (CloseHandler != null)
                CloseHandler();
        }
    }
}
