using Lab5.ViewModels;
using System.Windows;
using System.Windows.Input;

namespace Lab5
{
    public partial class EditWindow : Window
    {
        public EditWindow(ICommand callback, UINodeModel node)
        {
            InitializeComponent();
            DataContext = new NodeEditModel(callback, node);

        }
    }
}
