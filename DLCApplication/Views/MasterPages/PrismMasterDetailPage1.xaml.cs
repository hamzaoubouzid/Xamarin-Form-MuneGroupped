using DLCApplication.Models;
using DLCApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace DLCApplication.Views.MasterPages
{
    public partial class PrismMasterDetailPage1 : MasterDetailPage
    {
        private ObservableCollection<Grouping<string, RadioOption>> RadioOptionsList = new ObservableCollection<Grouping<string, RadioOption>>();
        List<MenuItems> Menuitems;
        public PrismMasterDetailPage1()
        {
            InitializeComponent();
            Detail = new NavigationPage(new HierachieDePersonnel());
            Initialize();
        }


        public async void Handle_Clicked(object sender, EventArgs e)
        {
            await this.DisplayAlert("", "Your selections have been saved", "OK");
            Initialize();
        }
        public void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var item = e.Item as RadioOption;

            if (item == null)
                return;
            foreach (var group in RadioOptionsList)
            {
                if (group.Contains(item))
                {
                    foreach (var s in group.Where(x => x.IsSelected))
                    {
                        s.IsSelected = false;
                    }

                    item.IsSelected = true;
                }
            }
        }

        public void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ListView_Radio.SelectedItem = null;
        }

        private void Initialize()
        {
            // Build a list of items
            var items = new List<RadioOption>()
            {
                new RadioOption(RadioCategory.Magasin, "Infos Magasin","Magasin.png", true),
                new RadioOption(RadioCategory.Magasin, "Hierarchie du personnel","Hierachie.png"),
                new RadioOption(RadioCategory.Produits, "Scan et  ajout des Produits","Scan.png"),
                new RadioOption(RadioCategory.Produits, "Consultation des produits","Consultation.png"),
                new RadioOption(RadioCategory.Controle, "Alertes", "Alertes.png"),
                new RadioOption(RadioCategory.Controle, "Controles", "Controles.png"),
                new RadioOption(RadioCategory.Controle, "Quitter l'application", "logout.png"),
            };

            // Copy items into a grouping
            var sorted = from item in items
                         group item by item.Category into radioGroups
                         select new Grouping<string, RadioOption>(radioGroups.Key.ToString(), radioGroups);
            // Add to list
            RadioOptionsList = new ObservableCollection<Grouping<string, RadioOption>>(sorted);
            ListView_Radio.ItemsSource = RadioOptionsList;
        }
    }
}