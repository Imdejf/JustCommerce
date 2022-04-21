using JustCommerce.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Shared.UnitTests.ModelsTests
{
    public sealed class PagedListTests
    {
        private IEnumerable<int> InitData => Enumerable.Range(0, 1000);

        [Fact]
        public void When_PageNumber_Is_Less_Than_One_Exception_Is_Rised()
        {
            Assert.Throws<ArgumentException>(() => PagedList<int>.Create(InitData.AsQueryable(), 0, 10));
            Assert.Throws<ArgumentException>(() => PagedList<int>.Create(InitData.AsQueryable(), -1023, 10));
        }

        [Fact]
        public void When_PageSize_Is_Less_Than_One_Exception_Is_Rised()
        {
            Assert.Throws<ArgumentException>(() => PagedList<int>.Create(InitData.AsQueryable(), 1, 0));
            Assert.Throws<ArgumentException>(() => PagedList<int>.Create(InitData.AsQueryable(), 1, -32));
        }

        [Fact]
        public void TotalPages_Is_Initialized_Properly()
        {
            var list = PagedList<int>.Create(InitData.AsQueryable(), 1, 20);

            Assert.Equal(1000 / 20, list.TotalPages);
        }

        [Fact]
        public void TotalCount_Is_Initialized_Properly()
        {
            var list = PagedList<int>.Create(InitData.AsQueryable(), 1, 20);

            Assert.Equal(1000, list.TotalCount);
        }

        [Fact]
        public void Count_Is_Initialized_Properly()
        {
            var list = PagedList<int>.Create(InitData.AsQueryable(), 1, 20);

            Assert.Equal(20, list.Items.Count);
        }

        [Fact]
        public void PageNumber_Is_Initialized_Properly()
        {
            var list = PagedList<int>.Create(InitData.AsQueryable(), 3, 20);

            Assert.Equal(3, list.PageNumber);
        }

        [Fact]
        public void HasNextPage_Is_Initialized_Properly()
        {
            var list = PagedList<int>.Create(InitData.AsQueryable(), 1, 20);

            Assert.True(list.HasNextPage);

            list = PagedList<int>.Create(InitData.AsQueryable(), 5, 210);

            Assert.False(list.HasNextPage);
        }

        [Fact]
        public void HasPreviousPage_Is_Initialized_Properly()
        {
            var list = PagedList<int>.Create(InitData.AsQueryable(), 1, 20);

            Assert.False(list.HasPreviousPage);

            list = PagedList<int>.Create(InitData.AsQueryable(), 4, 25);

            Assert.True(list.HasPreviousPage);
        }

        [Fact]
        public void Cast_Function_Works_Properly()
        {
            var list = PagedList<int>.Create(InitData.AsQueryable(), 1, 10);
            var cast = list.CastItems(c => c * 2);
            IList<int> compareList = Enumerable.Range(0, 10).Select(c => c * 2).ToList();
            Assert.True(Enumerable.SequenceEqual(compareList, cast.Items));
        }
    }
}
