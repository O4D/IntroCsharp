using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LesDataTemplates
{
    public class RelayCommand<T> : ICommand
    {
        #region private fields
        private readonly Action<T> execute;
        private readonly Predicate<T> canExecute;
        #endregion        

        /// <summary>
        /// Initializes a new instance of the RelayCommand class
        /// </summary>
        /// <param name="execute">The execution logic.</param>
        public RelayCommand(Action<T> execute)
            : this(execute, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the RelayCommand class
        /// </summary>
        /// <param name="execute">The execution logic.</param>
        /// <param name="canExecute">The execution status logic.</param>
        public RelayCommand(Action<T> execute, Predicate<T> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");

            this.execute = execute;
            this.canExecute = canExecute;
        }

        public void Execute(object parameter)
        {
            this.execute((T)parameter);
        }

        public bool CanExecute(object parameter)
        {
            return this.canExecute == null ? true : this.canExecute((T)parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                if (this.canExecute != null)
                    //CommandManager.RequerySuggested += value;
                    Console.Write(canExecute);
            }
            remove
            {
                if (this.canExecute != null)
                    //CommandManager.RequerySuggested -= value;
                    Console.Write(canExecute);
            }
        }
    }
}
