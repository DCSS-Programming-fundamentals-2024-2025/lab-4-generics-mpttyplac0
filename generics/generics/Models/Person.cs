namespace generics.Models
{
    class Person {
    public int Id;
    public string Name;
}

class Student : Person {
    public void SubmitWork() {
        Console.WriteLine($"{Name} submitted their work.");
    }

    public void SayName() {
        Console.WriteLine($"I'm {Name}.");
    }
}

class Teacher : Person {
    public void GradeStudent(Student s, int grade) {
        Console.WriteLine($"{Name} graded {s.Name} with {grade}.");
    }

    public void ExpelStudent(Student s) {
        Console.WriteLine($"{Name} expelled {s.Name}.");
    }

    public void ShowPresentStudents(List<Student> students) {
        Console.WriteLine("Present students:");
        foreach (var student in students) {
            Console.WriteLine(student.Name);
        }
    }
}
}
