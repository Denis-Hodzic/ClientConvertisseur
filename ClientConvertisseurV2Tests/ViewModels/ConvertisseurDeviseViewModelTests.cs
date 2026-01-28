using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClientConvertisseurV2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Assert.Fail();
        }

        [TestMethod()]
        public void ActionSetConversionTest()
        {
            Assert.Fail();
        }
    }
}