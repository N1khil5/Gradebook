namespace GradeBook
{

    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Nikhil GradeBook");

            while (true)
            {
                Console.WriteLine("Please add the grades in this gradebook or 'q' to quit");
                var input = Console.ReadLine();
                if (input == "q")
                {
                    break;
                }
                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);                
                }
                catch (ArgumentException ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
                finally
                {
                    System.Console.WriteLine("Grade not added, please try again if you want to add more grades.");
                }

            }

            var stats = book.GetStatistics();
            
            System.Console.WriteLine($"The average grade is {stats.Average:N1}");
            System.Console.WriteLine($"The highest grade is {stats.High:N1}");
            System.Console.WriteLine($"The lowest grade is {stats.Low:N1}");
            System.Console.WriteLine($"The letter grade is {stats.Letter}");

        }
    }
}