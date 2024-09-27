using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass()]
    public class TrophiesRepositoryTests
    {

        //Arrange
        private TrophiesRepository _repo = new();
        private readonly Trophy _badBadTrophy = new() { Competition = "Drifting", Year = 1969 };


        [TestInitialize]        
        public void Initialize()
        {
            //Arrange
            _repo.Add(new Trophy { Competition = "Football", Year = 1972 });
            _repo.Add(new Trophy {  Competition = "", Year = 1993 });
            _repo.Add(new Trophy { Competition = "Basketball", Year = 1970 });
            _repo.Add(new Trophy { Competition = "Hockey", Year = 2022});

        }

   

        [TestMethod()]
        public void GetTest()
        {
            //Act
            IEnumerable<Trophy> trophies = _repo.Get();
            
            //Assert
            Assert.AreEqual(4, trophies.Count());


            //Act
            var result = _repo.Get(yearAfter: 2020);
           
            //Assert
            Assert.AreEqual(1, result.Count());


            //Act
            IEnumerable<Trophy> sortedTropies = _repo.Get(orderby: "year");

            //Assert
            Assert.AreEqual(sortedTropies.First().Year, 1970);


            //Act
            IEnumerable<Trophy> sortedTropies2 = _repo.Get(orderby: "competition");
            
            //Assert
            Assert.AreEqual("", sortedTropies2.First().Competition);
        }

        [TestMethod()]
        public void GetByIdTest()
        {
            Assert.IsNotNull(_repo.GetById(1));
            Assert.IsNull(_repo.GetById(5));
        }

        [TestMethod()]
        public void AddTest()
        {
            //Act
            Trophy t = new() { Competition = "Test", Year = 2021 };
            
            //Assert
            Assert.AreEqual(5, _repo.Add(t).Id);
            Assert.AreEqual(5, _repo.Get().Count());

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => _repo.Add(_badBadTrophy));
        }

        [TestMethod()]
        public void RemoveTest()
        {
         //Assert
            Assert.IsNull(_repo.Remove(100));
            Assert.AreEqual(1, _repo.Remove(1)?.Id);
            Assert.AreEqual(3, _repo.Get().Count());
        }

        [TestMethod()]
        public void UpdateTest()
        {
            
            Assert.AreEqual(4, _repo.Get().Count());
            Trophy t = new() { Competition = "Test", Year = 2021 };
            Assert.IsNull(_repo.Update(100, t));
            Assert.AreEqual(1, _repo.Update(1, t)?.Id);
            Assert.AreEqual(4, _repo.Get().Count());

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => _repo.Update(1, _badBadTrophy));

        }
    }
}