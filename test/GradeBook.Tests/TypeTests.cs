using Xunit.Abstractions;
using Xunit;
namespace GradeBook.Tests
{
    public class TypeTests
    {
        [Fact] 
        public void GetBookReturnsDifferentObjects()
        {
            // Test cases not receiving actual value and fail. Does not check the other test cases in this instance.
            var book1 = GetBook("Book1");
            var book2 = GetBook("Book2");

            Assert.Equal("Book1", book1.Name);
            Assert.Equal("Book2", book2.Name);
            Assert.NotSame(book1, book2);
        }

        [Fact]
        public void TwoVariablesCanReferenceSameObject()
        {
            var book1 = GetBook("Book 1");
            var book2 = book1;

            Assert.Same(book1, book2);
        }

        Book GetBook(string name)
        {
            return new Book(name);
        }
    }
}