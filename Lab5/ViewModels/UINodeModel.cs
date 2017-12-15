using Lab5.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.ViewModels
{
    public class UINodeModel
    {
        UINode node;
        public string Name
        {
            get => node.Name;
            set => node.Name = value;
        }
        public string Type
        {
            get => node.GetType().Name;
        }
        public UINodeModel(UINode node)
        {
            this.node = node;
        }
    }
    public class UINodeCollectionModel : ObservableCollection<UINodeModel>
    {
        private static object _threadLock = new Object();
        private static UINodeCollectionModel current = null;

        public static UINodeCollectionModel Current
        {
            get
            {
                lock (_threadLock)
                    if (current == null)
                        current = new UINodeCollectionModel();

                return current;
            }
        }
        private UINodeCollectionModel()
        {
            this.Add(new UINodeModel(new UINode(null, new UI.Entities.Rectangle(), null)));
        }
    }
}
