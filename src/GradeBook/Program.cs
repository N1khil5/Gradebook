namespace GradeBook
{

    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Please enter your name to initialise your own gradebook.");

            var book = new Book($"GradeBook");
            book.Name = Console.ReadLine();

            book.GradeAdded += OnGradeAdded;
            book.GradeAdded += OnGradeAdded;
            book.GradeAdded -= OnGradeAdded;
            book.GradeAdded += OnGradeAdded;

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
                    // Converting the input string into a double so it can be added to the gradebook array.
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
                    System.Console.WriteLine("");
                }

            }

            var stats = book.GetStatistics();

            System.Console.WriteLine($"The statistics for {book.Name}\'s gradebook are as follows:");
            System.Console.WriteLine($"The gradebook category is {Book.CATEGORY}");
            System.Console.WriteLine($"The highest grade is {stats.High:N1}");
            System.Console.WriteLine($"The lowest grade is {stats.Low:N1}");
            System.Console.WriteLine($"The average grade is {stats.Average:N1}");
            System.Console.WriteLine($"The letter grade is {stats.Letter}");

        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            System.Console.WriteLine("A grade was added.");
        }
    }
}