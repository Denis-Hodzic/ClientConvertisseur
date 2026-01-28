using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClientConvertisseurV2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientConvertisseurV2.Models;

namespace ClientConvertisseurV2.Tests
{
    [TestClass()]
    public class WSServiceTests
    {
        [TestMethod()]
        public void WSServiceTest()
        {
            WSService ws = new WSService("https://localhost:7073/api/");
            Assert.IsNotNull(ws);
        }

        [TestMethod()]
        public void GetDevisesAsyncTest()
        {
            //Arrange
            WSService ws = new WSService("https://localhost:7073/api/");
            //Act
            List<Devise> result = ws.GetDevisesAsync("devises").Result;
            List<Devise> expectedDevises = new List<Devise>
            {
                new Devise(1, "Dollar", 1.08),
                new Devise(2, "Franc Suisse", 1.07),
                new Devise(3, "Yen", 120.0)
            };
            //Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(List<Devise>));
            CollectionAssert.Contains(result, new Devise(1, "Dollar", 1.08));
            CollectionAssert.AreEqual(result, expectedDevises);
        }
    }
}