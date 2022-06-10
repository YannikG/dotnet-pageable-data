using System;
using Moq;
using NUnit.Framework;

namespace YannikG.PageableData.Tests
{
	public class DataPageTests
	{
		private const int PAGE_SIZE = 50;

		// index starts at 0
		private const int CURRENT_PAGE = 1;

		private const string SORT_FIELD = "testField";

		private const SortDirectionEnum SORT_DIRECTION = SortDirectionEnum.Descending;

		private const long TOTAL_COUNT_ROUND = 100;
		private const long TOTAL_COUNT_NOT_ROUND = 123;
		private const long TOTAL_COUNT_ZERO = 0;

		private const int TOTAL_PAGES_ROUND = 2;
		private const int TOTAL_PAGES_NOT_ROUND = 3;
		private const int TOTAL_PAGES_ZERO = 0;

		private string[] MOCK_DATA = { "test1", "test2", "test3", "test4" };
		private string[] MOCK_DATA_EMPTY = { };

		private Mock<IPageable> pageableMock;

		private DataPage<string> testSubjectCountRound;
		private DataPage<string> testSubjectCountNotRound;
		private DataPage<string> testSubjectCountZero;

		[SetUp]
		public void Setup()
        {
			this.pageableMock =  new Mock<IPageable>();

			this.pageableMock
				.Setup(m => m.PageSize)
				.Returns(PAGE_SIZE);

			this.pageableMock
				.Setup(m => m.CurrentPage)
				.Returns(CURRENT_PAGE);

			this.pageableMock
				.Setup(m => m.IsSorted)
				.Returns(true);

			this.pageableMock
				.Setup(m => m.SortByField)
				.Returns(SORT_FIELD);

			this.pageableMock
				.Setup(m => m.SortDirection)
				.Returns(SORT_DIRECTION);

			this.testSubjectCountRound = new DataPage<string>(MOCK_DATA, TOTAL_COUNT_ROUND, this.pageableMock.Object);
			this.testSubjectCountNotRound = new DataPage<string>(MOCK_DATA, TOTAL_COUNT_NOT_ROUND, this.pageableMock.Object);
			this.testSubjectCountZero = new DataPage<string>(MOCK_DATA_EMPTY, TOTAL_COUNT_ZERO, this.pageableMock.Object);

		}

		[Test]
		public void Test_TotalItems_Happy()
		{
			Assert.AreEqual(TOTAL_COUNT_ROUND, this.testSubjectCountRound.TotalItems);
			Assert.AreEqual(TOTAL_COUNT_NOT_ROUND, this.testSubjectCountNotRound.TotalItems);
			Assert.AreEqual(TOTAL_COUNT_ZERO, this.testSubjectCountZero.TotalItems);
		}


		[Test]
		public void Test_TotalItemsOnPage_Happy()
		{
			Assert.AreEqual(MOCK_DATA.Length, this.testSubjectCountRound.TotalItemsOnPage);
			Assert.AreEqual(MOCK_DATA.Length, this.testSubjectCountNotRound.TotalItemsOnPage);
			Assert.AreEqual(MOCK_DATA_EMPTY.Length, this.testSubjectCountZero.TotalItemsOnPage);
		}

		[Test]
		public void Test_Content_Happy()
		{
			Assert.AreEqual(MOCK_DATA, this.testSubjectCountRound.Content);
			Assert.AreEqual(MOCK_DATA, this.testSubjectCountNotRound.Content);
			Assert.AreEqual(MOCK_DATA_EMPTY, this.testSubjectCountZero.Content);
		}

		[Test]
		public void Test_TotalPages_Happy()
        {
			Assert.AreEqual(TOTAL_PAGES_ROUND, this.testSubjectCountRound.TotalPages);
			Assert.AreEqual(TOTAL_PAGES_NOT_ROUND, this.testSubjectCountNotRound.TotalPages);
			Assert.AreEqual(TOTAL_PAGES_ZERO, this.testSubjectCountZero.TotalPages);

			this.pageableMock.Verify(m => m.PageSize, Times.Exactly(3));
		}

		[Test]
		public void Test_PageSize_Happy()
		{
			Assert.AreEqual(PAGE_SIZE, this.testSubjectCountRound.PageSize);
			Assert.AreEqual(PAGE_SIZE, this.testSubjectCountNotRound.PageSize);
			Assert.AreEqual(PAGE_SIZE, this.testSubjectCountZero.PageSize);

			this.pageableMock.Verify(m => m.PageSize, Times.Exactly(3));
		}

		[Test]
		public void Test_CurrentPage_Happy()
		{
			Assert.AreEqual(CURRENT_PAGE, this.testSubjectCountRound.CurrentPage);
			Assert.AreEqual(CURRENT_PAGE, this.testSubjectCountNotRound.CurrentPage);
			Assert.AreEqual(CURRENT_PAGE, this.testSubjectCountZero.CurrentPage);

			this.pageableMock.Verify(m => m.CurrentPage, Times.Exactly(3));
		}

		[Test]
		public void Test_IsSorted_Happy()
		{
			Assert.True(this.testSubjectCountRound.IsSorted);
			Assert.True(this.testSubjectCountNotRound.IsSorted);
			Assert.True(this.testSubjectCountZero.IsSorted);

			this.pageableMock.Verify(m => m.IsSorted, Times.Exactly(3));
		}

		[Test]
		public void Test_SortByField_Happy()
		{
			Assert.AreEqual(SORT_FIELD, this.testSubjectCountRound.SortByField);
			Assert.AreEqual(SORT_FIELD, this.testSubjectCountNotRound.SortByField);
			Assert.AreEqual(SORT_FIELD, this.testSubjectCountZero.SortByField);

			this.pageableMock.Verify(m => m.SortByField, Times.Exactly(3));
		}

		[Test]
		public void Test_SortDirection_Happy()
		{
			Assert.AreEqual(SORT_DIRECTION, this.testSubjectCountRound.SortDirection);
			Assert.AreEqual(SORT_DIRECTION, this.testSubjectCountNotRound.SortDirection);
			Assert.AreEqual(SORT_DIRECTION, this.testSubjectCountZero.SortDirection);

			this.pageableMock.Verify(m => m.SortDirection, Times.Exactly(3));
		}
	}
}