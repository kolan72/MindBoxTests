using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trips;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Trips.Tests
{
    [TestClass()]
    public class TripHelperTests
    {
        [TestMethod()]
        public void SortCards_Really_Sorted()
        {
            List<Tuple<string, string>> cards = new List<Tuple<string, string>>()
            {
                new Tuple<string, string>("Мельбурн", "Кельн"),
                new Tuple<string, string>("Париж" , "Вена"),
                new Tuple<string, string>("Москва" , "Париж"),
                new Tuple<string, string>("Кельн" , "Москва")
            };

            var sortedCards = (new TripHelper()).SortCards(cards).ToList();

            var n = Enumerable.Range(0, sortedCards.Count() - 1)
                              .Where(i =>sortedCards[i].Item2 != sortedCards[i + 1].Item1)
                              .ToList();

            Assert.AreEqual(n.Count(), 0);
        }


        [TestMethod()]
        public void SortCards_Counts_TheSame()
        {
            List<Tuple<string, string>> cards = new List<Tuple<string, string>>()
            {
                new Tuple<string, string>("Мельбурн", "Кельн"),
                new Tuple<string, string>("Париж" , "Вена"),
                new Tuple<string, string>("Москва" , "Париж"),
                new Tuple<string, string>("Кельн" , "Москва")
            };

            Assert.AreEqual(cards.Count, (new TripHelper()).SortCards(cards).Count());
        }
    }
}
