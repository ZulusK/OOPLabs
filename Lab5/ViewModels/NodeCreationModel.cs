using Lab5.UI;
using Lab5.UI.Buttons;
using Lab5.UI.Entities;
using Lab5.UI.Inputs;
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
    class NodeCreationModel : IDataErrorInfo
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
                if (columnName.Equals( "NodeNameToAdd"))
                {
                    if (string.IsNullOrEmpty(NodeNameToAdd))
                        result = "Please enter a Name of model";
                }
                else if (columnName.Equals ("NodeTypeToAdd"))
                {
                    if (string.IsNullOrEmpty(NodeTypeToAdd))
                        result = "Please select type of node";
                }
                return result;
            }
        }
        private DelegateCommand _SubmitCommand;
        private DelegateCommand _CancelCommand;
        private ICommand _CallBack;
        public string NodeNameToAdd { get; set; }
        public string NodeTypeToAdd { get; set; }
        public string NodeCSSToAdd { get; set; }

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

        public ICommand SubmitCommand
        {
            get
            {
                if (_SubmitCommand == null)
                {
                    _SubmitCommand = new DelegateCommand(Submit, CanExecuteSubmitCommand);
                }
                return _SubmitCommand;
            }
        }
        public bool CanExecuteSubmitCommand(object args)
        {
            return true;
        }
        private UINode CreateNewNode()
        {
            switch (NodeTypeToAdd)
            {
                case "PushButton":
                    return new PushButton("New button", NodeNameToAdd, new Rectangle(), NodeCSSToAdd);
                case "Label":
                    return new Label("New label", NodeNameToAdd, new Rectangle(), NodeCSSToAdd);
                case "TextArea":
                    return new TextInput(NodeNameToAdd, new Rectangle(), NodeCSSToAdd);
                case "UINode":
                default:
                    return new UINode(NodeNameToAdd, new Rectangle(), NodeCSSToAdd);
            }
        }
        public void Submit(object window)
        {
            if (_CallBack != null)
            {
                _CallBack.Execute(CreateNewNode());
            }
            if (window != null)
            {
                (window as Window).Close();
            }
        }

        public NodeCreationModel(ICommand addNodeCommand)
        {
            this._CallBack = addNodeCommand;
        }
    }
}
