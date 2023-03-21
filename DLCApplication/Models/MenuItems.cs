using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace DLCApplication.Models
{
    public  class MenuItems
    {
        public int Id { get; set; }
        public string  Icon { get; set; }
        public string  NameOfPage { get; set; }
    }
    public class Grouping<K, T> : ObservableCollection<T>
    {
        public K Key { get; private set; }
        public bool IsVisible { get; set; } = true;
        public Grouping(K key, IEnumerable<T> items)
        {
            Key = key;
            foreach (var item in items)
                this.Items.Add(item);
        }
    }

    public class RadioOption : INotifyPropertyChanged
    {
        public RadioCategory Category { get; }
        public string Title { get; }
        private bool _isSelected { get; set; }

        public string  Icon { get; set; }


        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                if (value != _isSelected)
                {
                    this._isSelected = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public RadioOption(RadioCategory category, string title, string icon, bool isSelected = false)
        {
            this.Category = category;
            this.Title = title;
            this.IsSelected = isSelected;
            this.Icon  = icon;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    public enum RadioCategory
    {
        Magasin,
        Produits,
        Controle,
    }
}
