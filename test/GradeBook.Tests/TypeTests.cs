using Xunit.Abstractions;
using Xunit;

namespace GradeBook.Tests
{
    public class TypeTests
    {

        [Fact]
        public void Test1()
        {
            var x = GetInt();
            x = SetInt(ref x);
            Assert.Equal(42, x);
        }

        private int GetInt()
        {
            return 3;
        }

        private int SetInt(ref int x)
        {
            return 42;
        }

        [Fact]
        public void CSharpCanPassByRef()
        {
            // SetName works when you pass by reference but not when you pass by value so GetBookSetName changes the value here. 
            var book1 = GetBook("Book 1");
            GetBookSetName(ref book1, "New Names");

            Assert.Equal("New Names", book1.Name);
        }

        private void GetBookSetName(ref Book book, string name)
        {
            book = new Book(name);
        }

        [Fact]
        public void CSharpCanPassByValue()
        {
            // GetBookSetName will not be able to change the value of the book1 variable so will remain as 'Book 1'.
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New Names");

            Assert.Equal("Book 1", book1.Name);
        }

        private void GetBookSetName(Book book, string name)
        {
            book = new Book(name);
            book.Name = name;
        }

        [Fact]
        public void CanSetNameFromReference()
        {
            var book1 = GetBook("Book 1");
            SetName(book1, "New Name");

            Assert.Equal("New Name", book1.Name);
        }

        private void SetName(Book book, string name)
        {
            book.Name = name;
        }


        [Fact]
        public void StringsBehaveLikeValueTypes()
        {
            string name = "Nikhil";
            var upper = MakeUpperCase(name);

            Assert.Equal("Nikhil", name);
            Assert.Equal("NIKHIL", upper);
        }

        private string MakeUpperCase(string parameter)
        {
            return parameter.ToUpper();
        }

        [Fact] 
        public void GetBookReturnsDifferentObjects()
        {
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
            Assert.NotSame(book1, book2);
        }

        [Fact]
        public void TwoVariablesCanReferenceSameObject()
        {
            var book1 = GetBook("Book 1");
            var book2 = book1;

            Assert.Same(book1, book2);
            // Assert.Same is the same as checking if the object reference is the same.
            Assert.True(Object.ReferenceEquals(book1, book2));
        }

        Book GetBook(string name)
        {
            return new Book(name);
        }
    }
}