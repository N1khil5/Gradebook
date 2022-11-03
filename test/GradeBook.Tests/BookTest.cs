using Xunit.Abstractions;
namespace GradeBook.Tests
{
    public class BookTests
    {
        private readonly ITestOutputHelper output;

        public BookTests(ITestOutputHelper output) 
        {
            this.output = output;
        }

        [Fact] //attribute
        public void BookCalculatesGradeStatistics()
        {
            // Arrange
            var book = new InMemoryBook("");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.5);

            // Act
            var result = book.GetStatistics();

            // Assert
            Assert.Equal(85.7, result.Average,1);
            output.WriteLine($"The average we expected is 85.7, the program returned {result.Average}");
            Assert.Equal(90.5, result.High,1);
            output.WriteLine($"The maximum grade value we expected is 90.5, the program returned {result.High}");
            Assert.Equal(77.5, result.Low,1);
            output.WriteLine($"The lowest grade value we expected is 77.5, the program returned {result.Low}");
            Assert.Equal('B', result.Letter);
        }
    }
}