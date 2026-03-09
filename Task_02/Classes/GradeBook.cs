namespace Task_02.Classes;

public class GradeBook
{
    public string ClassName { get; set; }
    private HashSet<Student> Students;

    public GradeBook(string className)
    {
        ClassName = className;
        Students = new();
    }

    public bool AddStudent(Student student) => Students.Add(student);

    public bool RemoveStudent(string studentId)
    {
        var student = Students.FirstOrDefault(x => x.Id == studentId);
        if (student is null)
            return false;

        return Students.Remove(student);
    }
    public Student FindStudent(string studentId)
    {
        var student = Students.FirstOrDefault(x => x.Id == studentId);
        if (student is null)
            return null;

        return student;
    }
    public double GetClassAverage()
    {
        return Students.Average(x => x.CalculateAverage());
    }
    public List<Student> GetTopStudents(int count)
    {
        if (count > Students.Count)
            throw new ArgumentOutOfRangeException(nameof(count));

        var stds = Students.OrderByDescending(x => x.CalculateAverage())
                    .Take(count).ToList();

        return stds;
    }

    public void DisplayAllStudents()
    {
        System.Console.WriteLine($"=== {ClassName} - All Students ===");

        foreach (var student in Students)
        {
            Console.WriteLine($"{student.Id} - {student.Name}: {student.CalculateAverage():F2} ({student.GetLetterGrade()})");
        }
    }
}

