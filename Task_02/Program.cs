using Task_02;
using Task_02.Classes;

// Create a gradebook
var gradeBook = new GradeBook("Computer Science 101");

// Create students
var student1 = new Student("S001", "Alice Johnson", "alice@school.com");
var student2 = new Student("S002", "Bob Smith", "bob@school.com");
var student3 = new Student("S003", "Charlie Brown", "charlie@school.com");

// Add grades for students
student1.AddGrade("Math", 95.0);
student1.AddGrade("English", 88.0);
student1.AddGrade("Science", 92.0);

student2.AddGrade("Math", 78.0);
student2.AddGrade("English", 85.0);
student2.AddGrade("Science", 80.0);

student3.AddGrade("Math", 90.0);
student3.AddGrade("English", 92.0);
student3.AddGrade("Science", 89.0);

// Add students to gradebook
gradeBook.AddStudent(student1);
gradeBook.AddStudent(student2);
gradeBook.AddStudent(student3);

// Display all students
gradeBook.DisplayAllStudents();

// Get class average
Console.WriteLine("Class Average: " + $"{gradeBook.GetClassAverage():F2}");

// Get top students
var topStudents = gradeBook.GetTopStudents(2);
System.Console.WriteLine("Top 2 Students:");
foreach (var student in topStudents)
    System.Console.WriteLine(student.Name + ": " + $"{student.CalculateAverage():F2}");

// Get student info
System.Console.WriteLine(student1.GetStudentInfo());