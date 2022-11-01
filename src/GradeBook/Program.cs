namespace GradeBook
{

    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Nikhil GradeBook");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.5);
            book.AddGrade(104.4);

            var stats = book.GetStatistics();
            
            System.Console.WriteLine($"The average grade is {stats.Average:N1}");
            System.Console.WriteLine($"The highest grade is {stats.High:N1}");
            System.Console.WriteLine($"The lowest grade is {stats.Low:N1}");
            System.Console.WriteLine($"The letter grade is {stats.Letter}");

        }
    }
}