using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass()]
    public class TrophyTests
    {

        private readonly Trophy _trophy = new Trophy() { Id = 1, Competition = "Football", Year = 1992 };
        private readonly Trophy _nullTitle = new Trophy() { Id = 2, Year = 1992 };
        private readonly Trophy _emptyTitle = new Trophy() { Id = 3, Competition = "", Year = 1992 };
        private readonly Trophy _yearLow = new Trophy() { Id = 4, Competition = "Football", Year = 1892 };




        [TestMethod()]
        public void ToStringTest()
        {
            //Arrange

            //Act 

            //Assert
            Assert.AreEqual("1 Football 1992", _trophy.ToString());

        }

        [TestMethod()]
        public void ValidateCompetitionTest()
        {
            //Arrange

            //Act 

            //Assert
        }

        [TestMethod()]
        public void ValidateYearTest()
        {
            //Arrange

            //Act 

            //Assert
        }

    }
}