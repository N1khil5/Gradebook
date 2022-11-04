using System.Collections.Generic;


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
        string Name {get;}
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

        public override event GradeAddedDelegate GradeAdded;

        public override Statistics GetStatistics() 
        {
            var result = new Statistics();
            if (grades.Count == 0)
            {
                //result.Letter = AddLetterGrade(result.Average);
                return result;
            }
            else
            {
                for(var index = 0; index < grades.Count; index++)
                {
                    result.Add(grades[index]);
                }

                //result.Letter = AddLetterGrade(result.Average);

                return result;
            }

        }

        private List<double> grades;

    }
}