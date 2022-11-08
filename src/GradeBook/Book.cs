namespace GradeBook
{

    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    // Convention to start the name of an interface with 'I'.
    // IBook is the Book interface.
    public interface IBook
    {
        // methods defined in an interface need to have a member available. 
        void AddGrade(double grade);
        Statistics GetStatistics();
        string Name { get; }
        event GradeAddedDelegate GradeAdded;
    }

    public abstract class Book : NamedObject, IBook
    {
        public Book(string name) : base(name)
        {
        }

        public abstract event GradeAddedDelegate GradeAdded;

        public abstract void AddGrade(double grade);

        public abstract Statistics GetStatistics();
    }

    public class InMemoryBook : Book
    {
        public InMemoryBook(string name) : base(name)
        {
            grades = new List<double>();
            Name = name;
        }

        public override void AddGrade(double grade)
        {
            string fileName = $"{Name}.txt";
            // Input validity check.
            if (grade <= 100 && grade >= 0)
            {
                try
                {
                    using (var writer = File.AppendText($"{Name}.txt"))
                    {
                        grades.Add(grade);
                        writer.WriteLine(grade);
                        if (GradeAdded != null)
                        {
                            GradeAdded(this, new EventArgs());
                        }
                    }

                }
                catch (System.Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }

        public override event GradeAddedDelegate GradeAdded;

        public override Statistics GetStatistics()
        {
            var result = new Statistics();
            if (grades.Count == 0)
            {
                return result;
            }
            else
            {
                for (var index = 0; index < grades.Count; index++)
                {
                    result.Add(grades[index]);
                }
                return result;
            }

        }

        private List<double> grades;

    }
}