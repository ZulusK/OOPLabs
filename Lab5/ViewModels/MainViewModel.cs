using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Lab5.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        #region Implementation of INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }

        protected virtual void OnPropertyChanged(PropertyChangedEventArgs args)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, args);
        }
        #endregion
    }
    public class DelegateCommand : ICommand
    {
        public delegate void ICommandOnExecute(object parameter);
        public delegate bool ICommandOnCanExecute(object parameter);

        private ICommandOnExecute _execute;
        private ICommandOnCanExecute _canExecute;

        public DelegateCommand(ICommandOnExecute onExecuteMethod, ICommandOnCanExecute onCanExecuteMethod)
        {
            _execute = onExecuteMethod;
            _canExecute = onCanExecuteMethod;
        }

        #region ICommand Members

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute.Invoke(parameter);
        }

        public void Execute(object parameter)
        {
            _execute.Invoke(parameter);
        }

        #endregion
    }

    class MainViewModel : ViewModelBase
    {


        #region Constructor

        public UINodeCollectionModel Nodes { get; set; }

        public string NameToAddNode { get; set; }
        public string CSSToAddNode { get; set; }
        public string TypeOfNodeToAddNode { get; set; }

        public MainViewModel()
        {
            Nodes = UINodeCollectionModel.Current;
        }

        #endregion
        private DelegateCommand _ExitCommand;
        private DelegateCommand _ShowAddDialogCommand;

        public ICommand ExitCommand
        {
            get
            {
                if (_ExitCommand == null)
                {
                    _ExitCommand = new DelegateCommand(Exit, CanExecuteExitCommand);
                }
                return _ExitCommand;
            }
        }
        private void Exit(object sender)
        {
            Console.WriteLine("exit");
            Application.Current.Shutdown();
        }
        public bool CanExecuteExitCommand(object args)
        {
            return true;
        }
        public ICommand ShowAddDialogCommand
        {
            get
            {
                if (_ShowAddDialogCommand == null)
                {
                    _ShowAddDialogCommand = new DelegateCommand(ShowAddDialog, CanExecuteShowAddDialogCommand);
                }
                return _ShowAddDialogCommand;
            }
        }
        private void ShowAddDialog(object sender)
        {
            var subWindow = new UINodeCreationWindow();
            subWindow.Show();
        }
        public bool CanExecuteShowAddDialogCommand(object args)
        {
            return true;
        }
        private ICommand _AddNode;
        public ICommand AddNode
        {
            get
            {
                if (_AddNode == null)
                {
                    _AddNode = new DelegateCommand(ExecuteAddNode, CanExecuteAddNode);

                }

                return _AddNode;
            }
        }
        public void ExecuteAddNode(object args)
        {
            Console.WriteLine("Call add node");
        }
        public bool CanExecuteAddNode(object args)
        {
            return true;
        }
    }
}
