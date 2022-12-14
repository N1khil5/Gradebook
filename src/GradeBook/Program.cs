namespace GradeBook
{

    class Program
    {
        static void Main(string[] args)
        {


            while (true)
            {
                System.Console.WriteLine("Please enter anything to continue or 'q' to quit");
                var choice = Console.ReadLine();
                if (choice == "q")
                {
                    break;
                }
                try
                {
                    System.Console.WriteLine("Please enter your name to initialise your own gradebook.");

                    var book = new InMemoryBook($"GradeBook");
                    var gradebookName = Console.ReadLine();
                    if (String.IsNullOrEmpty(gradebookName))
                    {
                        System.Console.WriteLine("You have not added a name. Default name added.");
                        book.Name = "Default";
                    }
                    else
                    {
                        book.Name = gradebookName;
                    }

                    createFile(book.Name);

                    book.GradeAdded += OnGradeAdded;

                    EnterGrades(book);

                    var stats = book.GetStatistics();

                    System.Console.WriteLine($"The statistics for {book.Name}\'s gradebook are as follows:");
                    System.Console.WriteLine($"The highest grade is {stats.High:N1}");
                    System.Console.WriteLine($"The lowest grade is {stats.Low:N1}");
                    System.Console.WriteLine($"The average grade is {stats.Average:N1}");
                    System.Console.WriteLine($"The letter grade is {stats.Letter}");
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
            }



        }

        private static void createFile(string name)
        {
            string fileName = $"{name}.txt";
            if (!File.Exists(fileName))
            {
                using (var writer = File.Create($"{name}.txt"))
                {
                    System.Console.WriteLine("A gradebook has been created");
                }
            }
            else
            {
                System.Console.WriteLine($"Will write to existing {name}\'s gradebook");
            }
        }

        private static void EnterGrades(IBook book)
        {
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
                    System.Console.WriteLine("***");
                }
            }
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            System.Console.WriteLine("A grade was added.");
        }
    }
}