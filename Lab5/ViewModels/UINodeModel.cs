using Lab5.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.ViewModels
{
    [Serializable]
    public class UINodeModel : ViewModelBase
    {
        UINode node;
        public uint ID
        {
            get => node.ID;
        }
        public string Name
        {
            get => node.Name;
            set
            {
                node.Name = value;
                OnPropertyChanged("Name");
            }
        }
        public string Type
        {
            get => node.GetType().Name;
        }
        public string CSS
        {
            get => node.CSS;
            set
            {
                node.CSS = value;
                OnPropertyChanged("CSS");
            }
        }


        public UINodeModel(UINode node)
        {
            this.node = node;
        }
    }
    [Serializable]
    public class UINodeCollectionModel : ObservableCollection<UINodeModel>,INotifyPropertyChanged
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
            this.CollectionChanged += items_CollectionChanged;
        }
        void items_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.OldItems != null)
            {
                foreach (INotifyPropertyChanged item in e.OldItems)
                    item.PropertyChanged -= item_PropertyChanged;
            }
            if (e.NewItems != null)
            {
                foreach (INotifyPropertyChanged item in e.NewItems)
                    item.PropertyChanged += item_PropertyChanged;
            }
        }

        void item_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            this.OnPropertyChanged(e);
        }
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
}
