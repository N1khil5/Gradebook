namespace GradeBook;
using System;
using System.IO;
using System.Text;

public class DiskBook : Book
{
    public DiskBook(string name) : base(name)
    {
    }

    public override event GradeAddedDelegate GradeAdded;

    public override void AddGrade(double grade)
    {
        string fileName = $"{Name}.txt";

        try
        {
            if (File.Exists(fileName))
            {
                using(var writer = File.AppendText($"{Name}.txt"))
                {
                    writer.WriteLine(grade);
                    if(GradeAdded != null)
                    {
                        GradeAdded(this, new EventArgs());
                    }
                }
            }
            using (StreamWriter writer = new StreamWriter(fileName));
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
        using(var writer = File.AppendText($"{Name}.txt"))
        {
            writer.WriteLine(grade);
            if(GradeAdded != null)
            {
                GradeAdded(this, new EventArgs());
            }
        }

    }

    public override Statistics GetStatistics()
    {
        var result = new Statistics();
        using(var reader = File.OpenText($"{Name}.txt"))
        {
            var line = reader.ReadLine();
            while (line != null)
            {
                var number = double.Parse(line);
                result.Add(number);
                line = reader.ReadLine();
            }
        }
        return result;
    }
}