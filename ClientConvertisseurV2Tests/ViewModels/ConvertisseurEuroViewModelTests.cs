using ClientConvertisseurV2.Models;
using ClientConvertisseurV2.ViewModels;
using Microsoft.UI.Xaml.Interop;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientConvertisseurV2.ViewModels.Tests
{
    [TestClass()]
    public class ConvertisseurEuroViewModelTests
    {
        [TestMethod()]
        public void ConvertisseurEuroViewModelTest()
        {
            ConvertisseurEuroViewModel convertisseurEuro = new ConvertisseurEuroViewModel();
            Assert.IsNotNull(convertisseurEuro);
        }

        [TestMethod]
        public void ActionSetConversionTest()
        {
            // Arrange
            var listesDevises = new List<Devise>()
            {
                new Devise(1, "Dollar", 1.08),
                new Devise(2, "Franc Suisse", 1.07),
                new Devise(3, "Yen", 130.0)
            };

            var viewModel = new ConvertisseurEuroViewModel();

            // On injecte les devises dans le VM
            viewModel.Devises = new ObservableCollection<Devise>(listesDevises);

            // Montant en euros
            viewModel.Euro = 100.0;

            // Sélection de la devise
            viewModel.DeviseSelected = viewModel.Devises.First(d => d.NomDevise == "Franc Suisse");

            // Act
            viewModel.BtnSetConversion.Execute(null); // <-- c’est ça qu’on teste

            // Assert
            Assert.AreEqual(107.0, viewModel.Resultat, "Résultat attendu = 107");
        }


        [TestMethod()]
        public void GetDataOnLoadAsyncTest_OK()
        {
            //Arrange
            ConvertisseurEuroViewModel convertisseurEuro = new ConvertisseurEuroViewModel();
            //Act
            convertisseurEuro.GetDataOnloadAsync();
            Thread.Sleep(1000);
            //Assert
            Assert.IsNotNull(convertisseurEuro.Devises);
        }

        [TestMethod()]
        public void GetDataOnLoadAsyncTest_NotOK()
        {
            //Arrange
            ConvertisseurEuroViewModel convertisseurEuro = new ConvertisseurEuroViewModel();
            //Act
            convertisseurEuro.GetDataOnloadAsync();
            Thread.Sleep(1000);
            //Assert
            Assert.IsNull(convertisseurEuro.Devises);
        }
    }
}