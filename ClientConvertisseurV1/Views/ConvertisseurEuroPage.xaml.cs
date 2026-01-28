using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ClientConvertisseurV1.Models;

namespace ClientConvertisseurV1.Views
{
    public sealed partial class ConvertisseurEuroPage : Page, INotifyPropertyChanged
    {
        public ConvertisseurEuroPage()
        {
            InitializeComponent();
            DataContext = this;
            GetDataOnloadAsync();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        private double euro;
        public double Euro
        {
            get => euro;
            set
            {
                euro = value;
                OnPropertyChanged();
            }
        }

        private double resultat;
        public double Resultat
        {
            get => resultat;
            set
            {
                resultat = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Devise> devises;
        public ObservableCollection<Devise> Devises
        {
            get => devises;
            set
            {
                devises = value;
                OnPropertyChanged();
            }
        }

        private Devise deviseSelected;
        public Devise DeviseSelected
        {
            get => deviseSelected;
            set
            {
                deviseSelected = value;
                OnPropertyChanged();
            }
        }

        public async void GetDataOnloadAsync()
        {
            WSService ws = new WSService("https://localhost:7073/api/");
            List<Devise> result = await ws.GetDevisesAsync("devises");

            if (result == null)
            {
                await ShowMessageAsync("Erreur de connexion au service Web");
            }
            else
            {
                Devises = new ObservableCollection<Devise>(result);
            }
        }

        private async void BtnConvertir_Click(object sender, RoutedEventArgs e)
        {
            if (DeviseSelected != null)
            {
                Resultat = Euro * DeviseSelected.Taux;
            }
            else
            {
                await ShowMessageAsync("Veuillez sélectionner une devise");
            }
        }

        private async System.Threading.Tasks.Task ShowMessageAsync(string message)
        {
            ContentDialog dialog = new ContentDialog
            {
                Title = "Erreur",
                Content = message,
                CloseButtonText = "OK",
                XamlRoot = this.XamlRoot
            };

            await dialog.ShowAsync();
        }
    }
}
