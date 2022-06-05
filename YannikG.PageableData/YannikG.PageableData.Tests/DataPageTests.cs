using System;
using Moq;
using NUnit.Framework;

namespace YannikG.PageableData.Tests
{
	public class DataPageTests
	{
		private const int PAGE_SIZE = 50;
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

			this.testSubjectCountRound = new DataPage<string>(MOCK_DATA, TOTAL_COUNT_ROUND, this.pageableMock.Object);
			this.testSubjectCountNotRound = new DataPage<string>(MOCK_DATA, TOTAL_COUNT_NOT_ROUND, this.pageableMock.Object);
			this.testSubjectCountZero = new DataPage<string>(MOCK_DATA_EMPTY, TOTAL_COUNT_ZERO, this.pageableMock.Object);

		}

		[Test]
		public void Test_TotalPages_Happy()
        {
			Assert.AreEqual(TOTAL_PAGES_ROUND, this.testSubjectCountRound.TotalPages);
			Assert.AreEqual(TOTAL_PAGES_NOT_ROUND, this.testSubjectCountNotRound.TotalPages);
			Assert.AreEqual(TOTAL_PAGES_ZERO, this.testSubjectCountZero.TotalPages);

			this.pageableMock.Verify(m => m.PageSize, Times.Exactly(3));
		}
	}
}

