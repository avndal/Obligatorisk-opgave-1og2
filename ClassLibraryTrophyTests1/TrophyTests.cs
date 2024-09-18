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
        //Arrange
        private readonly Trophy _trophy = new Trophy() { Id = 1, Competition = "Football", Year = 1992 };
        private readonly Trophy _nullTitle = new Trophy() { Id = 2, Year = 1992 };
        private readonly Trophy _emptyTitle = new Trophy() { Id = 3, Competition = "", Year = 1992 };
        private readonly Trophy _yearLow = new Trophy() { Id = 4, Competition = "Football", Year = 1969 };
        private readonly Trophy _yearHigh = new Trophy() { Id = 4, Competition = "Football", Year = 2025 };




        [TestMethod()]
        public void ToStringTest()
        {

            //Act 
            string result = _trophy.ToString();
            
            //Assert
            Assert.AreEqual("1 + Football + 1992", result);

        }

        [TestMethod()]
        public void ValidateCompetitionTest()
        {
            //Act 

            //Assert
            Assert.ThrowsException<ArgumentNullException>(()=> _nullTitle.ValidateCompetition());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => _emptyTitle.ValidateCompetition());
        }

        [TestMethod()]
        public void ValidateYearTest()
        {
            //Act 

            //Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(()=> _yearLow.ValidateYear());
            Assert.ThrowsException<ArgumentOutOfRangeException>(()=> _yearHigh.ValidateYear());


        }

    }
}