using Lab5.Dialogs;
using Lab5.Services;
using Lab5.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;

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
            this.LoadCommand.Execute(null);
        }

        #endregion
        private DialogService dialogs = new DialogService();
        private DelegateCommand _ExitCommand;
        private DelegateCommand _SaveCommand;
        private DelegateCommand _LoadCommand;
        private DelegateCommand _ShowAddDialogCommand;
        private DelegateCommand _RemoveCommand;
        private DelegateCommand _ShowEditWindowCommand;
        private DelegateCommand _ClearCommand;
        private DelegateCommand _AddNodeCommand;
        private DelegateCommand _EditNodeCommand;

        UINodeModel _selected;
        public UINodeModel Selected
        {
            get { return _selected; }
            set
            {
                _selected = value;
                OnPropertyChanged("Selected");
            }
        }


        public ICommand ShowAddDialogCommand
        {
            get
            {
                if (_ShowAddDialogCommand == null)
                {
                    _ShowAddDialogCommand = new DelegateCommand(ExecuteShowAddDialog, (args) => true);
                }
                return _ShowAddDialogCommand;
            }
        }
        public ICommand ExitCommand
        {
            get
            {
                if (_ExitCommand == null)
                {
                    _ExitCommand = new DelegateCommand(ExecuteExit, (args) => true);
                }
                return _ExitCommand;
            }
        }
        public ICommand AddNodeCommand
        {
            get
            {
                if (_AddNodeCommand == null)
                {
                    _AddNodeCommand = new DelegateCommand(ExecuteAddNode, (args) => true);

                }

                return _AddNodeCommand;
            }
        }
        public ICommand EditNodeCommand
        {
            get
            {
                if (_EditNodeCommand == null)
                {
                    _EditNodeCommand = new DelegateCommand(ExecuteEditNode, (args) => true);

                }

                return _EditNodeCommand;
            }
        }

        public ICommand RemoveCommand
        {
            get
            {
                if (_RemoveCommand == null)
                {
                    _RemoveCommand = new DelegateCommand(ExecuteRemove, (args) => true);
                }
                return _RemoveCommand;
            }
        }
        public ICommand SaveCommand
        {
            get
            {
                if (_SaveCommand == null)
                {
                    _SaveCommand = new DelegateCommand(ExecuteSaveCommand, (args) => true);
                }
                return _SaveCommand;
            }
        }
        public ICommand LoadCommand
        {
            get
            {
                if (_LoadCommand == null)
                {
                    _LoadCommand = new DelegateCommand(ExecuteLoadCommand, (args) => true);
                }
                return _LoadCommand;
            }
        }
        public ICommand ClearCommand
        {
            get
            {
                if (_ClearCommand == null)
                {
                    _ClearCommand = new DelegateCommand(ExecuteClearCommand, (args) => true);
                }
                return _ClearCommand;
            }
        }
        public ICommand ShowEditWindowCommand
        {
            get
            {
                if (_ShowEditWindowCommand == null)
                {
                    _ShowEditWindowCommand = new DelegateCommand(ExecuteShowEditDialog, (args) => true);
                }
                return _ShowEditWindowCommand;
            }

        }
        private void ExecuteClearCommand(object args)
        {
            // check, is user is sure
            if (MessageBox.Show("Are you sure?", "Alert, clear!", MessageBoxButton.YesNo) != MessageBoxResult.Yes) return;
            this.Nodes.Clear();
        }
        private void ExecuteLoadCommand(object args)
        {
            try
            {
                if (dialogs.OpenFileDialog() == true)
                {
                    var loadedNodes = NodeService.Load(dialogs.FilePath);
                    Nodes.Clear();
                    foreach (var node in loadedNodes)
                    {
                        Nodes.Add(node);
                    }
                    dialogs.ShowMessage("Файл загружен");
                }
            }
            catch (Exception ex)
            {
                dialogs.ShowMessage(ex.Message);
            }
        }

        private void ExecuteSaveCommand(object args)
        {
            try
            {
                if (dialogs.SaveFileDialog("data.bin") == true)
                {
                    NodeService.Save(dialogs.FilePath, Nodes.ToList());
                    dialogs.ShowMessage("Файл сохранен");
                }
            }
            catch (Exception ex)
            {
                dialogs.ShowMessage(ex.Message);
            }
        }
        private void ExecuteExit(object sender)
        {
            Console.WriteLine("exit");
            Application.Current.Shutdown();
        }
        public void ExecuteAddNode(object node)
        {
            if (node != null)
            {
                this.Nodes.Add(new UINodeModel(node as UINode));
            }
        }
        private void ExecuteShowAddDialog(object sender)
        {
            var subWindow = new UINodeCreationWindow(AddNodeCommand);
            subWindow.Show();
        }
        private void ExecuteShowEditDialog(object sender)
        {
            var subWindow = new EditWindow(EditNodeCommand, Selected);
            subWindow.Show();
        }

        private void ExecuteRemove(Object args)
        {
            // check, is user is sure


            if (MessageBox.Show("Are you sure?", "Alert, remove!", MessageBoxButton.YesNo) != MessageBoxResult.Yes) return;
            if (args == null) return;
            UInt32 id = (UInt32)args;
            var index = this
                .Nodes
                .Select((v, i) => new { v, i })
                .First((obj) => { return (obj.v.ID.Equals(id)); }).i;
            if (index >= 0)
                this.Nodes.RemoveAt(index);
        }
        public void ExecuteEditNode(object node)
        {

        }

    }
    [ValueConversion(typeof(object), typeof(bool))]
    public class Object2BoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            return value != null;
        }

        public object ConvertBack(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }



    public class CSS2ColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter,
           System.Globalization.CultureInfo culture)
        {
            try
            {
                return new SolidColorBrush((Color)ColorConverter.ConvertFromString(value as String));
            }
            catch (Exception err)
            {
                return new SolidColorBrush(Colors.Aqua);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
