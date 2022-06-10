using System;
using NUnit.Framework;

namespace YannikG.PageableData.Tests
{
	public class PageableTests
	{
		private const int PAGE_SIZE = 50;
		private const int CURRENT_PAGE_3 = 3;
		private const int SKIP_ON_PAGE_3 = 150;
		private const string SORT_FIELD = "testField";

        [Test]		
		public void Test_Skip_and_Take_Happy()
        {
			var pageable = new Pageable()
			{
				CurrentPage = CURRENT_PAGE_3,
				PageSize = PAGE_SIZE
			};

			Assert.AreEqual(SKIP_ON_PAGE_3, pageable.Skip);
			Assert.AreEqual(PAGE_SIZE, pageable.Take);
        }

        [Test]
		public void Test_IsSorted_and_SortField_Happy()
        {
			var pageable = new Pageable();

			Assert.False(pageable.IsSorted);

			pageable.SortByField = SORT_FIELD;

			Assert.True(pageable.IsSorted);
			Assert.AreEqual(SORT_FIELD, pageable.SortByField);
;        }
	}
}

