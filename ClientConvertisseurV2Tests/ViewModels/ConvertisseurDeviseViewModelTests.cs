using ClientConvertisseurV2.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientConvertisseurV2.Models;

namespace ClientConvertisseurV2.ViewModels.Tests
{
    [TestClass()]
    public class ConvertisseurDeviseViewModelTests
    {
        [TestMethod()]
        public void ConvertisseurDeviseViewModelTest()
        {
            ConvertisseurDeviseViewModel convertisseurDevise = new ConvertisseurDeviseViewModel();
            Assert.IsNotNull(convertisseurDevise);
        }

        [TestMethod()]
        public void GetDataOnloadAsyncTest()
        {
            //Arrange
            ConvertisseurDeviseViewModel convertisseurDevise = new ConvertisseurDeviseViewModel();
            //Act
            convertisseurDevise.GetDataOnloadAsync();
            Thread.Sleep(1000);
            //Assert
            Assert.IsNotNull(convertisseurDevise.Devises);
        }

        [TestMethod()]
        public void ActionSetConversionTest()
        {
            // Arrange
            var listesDevises = new List<Devise>()
            {
                new Devise(1, "Dollar", 1.08),
                new Devise(2, "Franc Suisse", 1.07),
                new Devise(3, "Yen", 130.0)
            };

            var viewModel = new ConvertisseurDeviseViewModel();

            // On injecte les devises dans le VM
            viewModel.Devises = new ObservableCollection<Devise>(listesDevises);

            // Montant en euros
            viewModel.Montant = 107.0;

            // Sélection de la devise
            viewModel.DeviseSelected = viewModel.Devises.First(d => d.NomDevise == "Franc Suisse");

            // Act
            viewModel.BtnSetConversion.Execute(null); // <-- c’est ça qu’on teste

            // Assert
            Assert.AreEqual(100.0, viewModel.Euro, "Résultat attendu = 107");
        }
    }
}