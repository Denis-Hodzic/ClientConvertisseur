using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClientConvertisseurV2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Interop;
using ClientConvertisseurV2.Models;

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

        //[TestMethod()]
        //public void ActionSetConversionTest()
        //{
        //    //Arrange
        //    List<Devise> listesDevises = new List<Devise>()
        //    {
        //        new Devise(1, "Dollar", 1.1),
        //        new Devise(2, "Livre", 0.9),
        //        new Devise(3, "Yen", 130.0)
        //    };
        //    ConvertisseurEuroViewModel convertisseurEuro = new ConvertisseurEuroViewModel();
        //    //Act
        //    convertisseurEuro.Euro = 100.0;
        //    var euroAmount = convertisseurEuro.Euro;
        //    convertisseurEuro.DeviseSelected = listesDevises.First(d => d.NomDevise == "Dollar");
        //    var deviseSelected = convertisseurEuro.DeviseSelected;
        //    var res= euroAmount * deviseSelected.Taux;
        //    //Assert
        //    Assert.AreEqual(105, res,"res attendu 108");
        //}

        [TestMethod()]
        public void GetDataOnLoadAsyncTest_OK()
        {
            //Arrange
            ConvertisseurEuroViewModel convertisseurEuro = new ConvertisseurEuroViewModel();
            //Act
            convertisseurEuro.Initialize();
            Thread.Sleep(1000);
            //Assert
            Assert.IsNotNull(convertisseurEuro.Devises);
        }
    }
}