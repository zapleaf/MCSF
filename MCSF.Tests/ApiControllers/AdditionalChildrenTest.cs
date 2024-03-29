﻿using MCSF;
using MCSF.ApiControllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using System.Web.Http.Results;

namespace MCSF.Tests.ApiControllers
{
    [TestClass]
    public class AdditionalChildrenTest
    {
        [TestMethod]
        public async Task AdditionalChildren()
        {
            // Arrange
            AdditionalChildrenMultiplierController sut = new AdditionalChildrenMultiplierController();
            
            // Act
            var result = await sut.Get(2) as OkNegotiatedContentResult<decimal>;

            // Assert
            Assert.AreEqual(.77m, result.Content);
        }

        [TestMethod]
        public async Task AdditionalChildren_Over5Children()
        {
            // Arrange
            AdditionalChildrenMultiplierController sut = new AdditionalChildrenMultiplierController(); ;

            // Act
            var result = await sut.Get(5) as OkNegotiatedContentResult<decimal>;
            var result2 = await sut.Get(7) as OkNegotiatedContentResult<decimal>;

            // Assert
            Assert.AreEqual(result.Content, result2.Content);
        }

    }
}
