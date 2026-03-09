using System.ComponentModel;

namespace Task_02;

public class Student
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    private Dictionary<string, double> Grades;

    public Student(string id, string name, string email)
    {
        Id = id;
        Name = name;
        Email = email;
        Grades = new Dictionary<string, double>();
    }

    public bool AddGrade(string subName, double grade)
    {
        if(grade < 0 && grade > 100)
            throw new ArgumentOutOfRangeException(nameof(grade), "Grade must be between 0 and 100");
        Grades[subName] = grade;
        return true;
    }
    public double GetGrade(string subName)
    {
        if (!Grades.ContainsKey(subName))
            throw new ArgumentException($"Subject Name {subName} not found");
        
        return Grades[subName];
    }
    public double CalculateAverage()
    {
        return Grades.Values.Average();
    }

    public char GetLetterGrade()
    {
        var num = CalculateAverage();
        if (num <= 59)
            return 'F';
        else if (num >= 60 && num < 69)
            return 'D';
        else if (num >= 70 && num < 79)
            return 'C';
        else if (num >= 80 && num < 89)
            return 'B';
        else
            return 'A';
    }

    public string GetStudentInfo()
    {
        var sub = "\n";
        foreach (var pair in Grades)
        {
            sub += $"   {pair.Key}: {pair.Value}\n";
        }
        return $"=== Student Information ===\n" +
            $"Id: {Id}\n" +
            $"Name: {Name}\n" +
            $"Email: {Email}\n" +
            $"Grades: {sub}" +
            $"Average: {CalculateAverage():F2} ({GetLetterGrade()})";
    }

    public override bool Equals(object? obj)
    {
        if (obj is Student other)
            return Id == other.Id;
        return false;
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(Id);
    }
}