using Stocking.Domain.AggregatesModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    public class AjouterArticle
    {
        private readonly Category _testCategory = Category.Alimentaire;
        private readonly string _testReference = "AR9999";
        private readonly string _testName = "test article name";
        private readonly int _testQuantity = 2;
        private readonly decimal _testHT = 100;
        private readonly bool _testIsTakeAway = false;

        [Fact]
        public void AddsArticleInStockIfNotPresent()
        {
            var stock = new Stock();
            var article = new Article(_testReference, _testName, _testQuantity);
            stock.AddArticle(article);

            var firstItem = stock.Articles.Single();
            Assert.Equal(_testReference, firstItem.Reference);
            Assert.Equal(_testName, firstItem.Name);
            Assert.Equal(_testQuantity, firstItem.Quantity);
            //Assert.Equal(_testHT, firstItem.HT);

        }
    }
}
