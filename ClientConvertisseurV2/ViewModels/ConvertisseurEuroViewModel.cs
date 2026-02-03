using ClientConvertisseurV2.Models;
using ClientConvertisseurV2.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ClientConvertisseurV2.ViewModels
{
    public class ConvertisseurEuroViewModel: ObservableObject
    {
        public event EventHandler<string>? MessageRequested;
        public IRelayCommand BtnSetConversion { get; }

        public ConvertisseurEuroViewModel()
        {
            BtnSetConversion = new RelayCommand(ActionSetConversion);
            GetDataOnloadAsync();
        }

        public void ActionSetConversion()
        {
            if (DeviseSelected != null)
            {
                Resultat = Math.Round(Euro / DeviseSelected.Taux,2);
            }
            else
            {
                MessageRequested?.Invoke(this, "Veuillez sélectionner une devise");
            }
        }




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
            List<Devise>? result = await ws.GetDevisesAsync("devises");

            if (result == null)
                MessageRequested?.Invoke(this, "Erreur de connexion au service Web");
            else
                Devises = new ObservableCollection<Devise>(result);
        }
    }
}
