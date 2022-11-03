using System.Collections.Generic;


namespace GradeBook
{

    public delegate void GradeAddedDelegate(object sender, EventArgs args);


    public abstract class Book : NamedObject
    {
        public Book(string name) : base(name)
        {
        }
        public abstract void AddGrade(double grade);
    }

    public class InMemoryBook : Book
    {
        public InMemoryBook(string name) : base(name)
        {
            grades = new List<double>();
            Name = name;
        }

        public char AddLetterGrade(double grade)
        {

            if (grade >= 90.0)
            {
                return('A');
            }
            else if (grade >= 80.0)
            {
                return('B');
            }
            else if (grade >= 70.0) 
            {
                return('C');
            }
            else if (grade >= 60.0)
            {
                return('D');
            }
            else
            {
                return('F');
            }
            
        }

        public override void AddGrade(double grade)
        {
            // Input validity check.
            if (grade <= 100 && grade >= 0)
            {
                //this.grades.Add(grade);
                grades.Add(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            } 

        }

        public event GradeAddedDelegate GradeAdded;


        public Statistics GetStatistics() 
        {
            var result = new Statistics();
            result.Low = double.MaxValue;
            result.High = double.MinValue;
            result.Average = 0.0;
            foreach(var grade in grades)
            {
                result.Low = Math.Min(grade, result.Low);
                result.High = Math.Max(grade, result.High);
                result.Average += grade;
            }
            result.Average /= grades.Count;

            result.Letter = AddLetterGrade(result.Average);

            return result;
        }

        private List<double> grades;

        public const string CATEGORY = "Science";
    }
}