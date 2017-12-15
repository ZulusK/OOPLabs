using Lab5.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.ViewModels
{
    [Serializable]
    public class UINodeModel
    {
        UINode node;
        public uint ID
        {
            get => node.ID;
        }
        public string Name
        {
            get => node.Name;
            set => node.Name = value;
        }
        public string Type
        {
            get => node.GetType().Name;
        }
        public string CSS
        {
            get => node.CSS;
        }
        public UINodeModel(UINode node)
        {
            this.node = node;
        }
    }
    [Serializable]
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
