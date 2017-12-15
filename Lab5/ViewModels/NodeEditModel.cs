using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace Lab5.ViewModels
{
    class NodeEditModel : IDataErrorInfo
    {
        public string Error
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string this[string columnName]
        {
            get
            {
                string result = null;
                if (columnName.Equals("NodeName"))
                {
                    if (string.IsNullOrEmpty(NodeName))
                        result = "Please enter a Name of model";
                }
                return result;
            }
        }
        private DelegateCommand _SubmitCommand;
        private DelegateCommand _CancelCommand;
        private ICommand _CallBack;
        public string NodeName { get; set; }
        public string NodeCSS { get; set; }
        private UINodeModel Node;
        public ICommand SubmitCommand
        {
            get
            {
                if (_SubmitCommand == null)
                {
                    _SubmitCommand = new DelegateCommand(Submit, a=>true);
                }
                return _SubmitCommand;
            }
        }
        public ICommand CancelCommand
        {
            get
            {
                if (_CancelCommand == null)
                {
                    _CancelCommand = new DelegateCommand(Cancel, CanExecuteCancelCommand);
                }
                return _CancelCommand;
            }
        }
        public bool CanExecuteCancelCommand(object args)
        {
            return true;
        }
        public void Cancel(object window)
        {
            if (window != null)
            {
                (window as Window).Close();
            }
        }
        public void Submit(object window)
        {
            Node.CSS = this.NodeCSS;
            Node.Name = this.NodeName;
            if (_CallBack != null)
            {
                _CallBack.Execute(Node);
            }
            if (window != null)
            {
                (window as Window).Close();
            }
        }

        public NodeEditModel(ICommand editNodeCallback, UINodeModel node)
        {
            this.Node = node;
            this.NodeCSS = node.CSS;
            this.NodeName = node.Name;
            this._CallBack = editNodeCallback;
        }
    }
}
