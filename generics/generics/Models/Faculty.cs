using generics.Interfaces;
using generics.Models;
using generics.Repositories;
class Faculty {
    public int Id;
    public string Name;

     private IRepository<Group, int> _groups = new InMemoryRepository<Group, int>();

     public void AddGroup(Group g) {
         _groups.Add(g.Id, g);
     }

     public void RemoveGroup(int groupId) {
        _groups.Remove(groupId);
    }

    public IEnumerable<Group> GetAllGroups() {
        return _groups.GetAll();
    }
    public Group GetGroup(int id) {
        return _groups.Get(id);
    }
    
    public void AddStudentToGroup(int groupId, Student s){
        var group = GetGroup(groupId);
        if (group != null)
        {
            group.AddStudent(s);
        }
        else
        {
            Console.WriteLine($"Group with ID {groupId} not found.");
        }

    }
    public void RemoveStudentFromGroup(int groupId, int studentId){
        var group = GetGroup(groupId);
        if (group != null)
        {
            group.RemoveStudent(studentId);
        }
        else
        {
            Console.WriteLine($"Group with ID {groupId} not found.");
        }

    }
    public IEnumerable<Student> GetAllStudentsInGroup(int groupId){
        var group = GetGroup(groupId);
        if (group != null)
        {
            return group.GetAllStudents();
        }
        else
        {
            Console.WriteLine($"Group with ID {groupId} not found.");
        }
        return Enumerable.Empty<Student>();

    }

    public Student FindStudentInGroup(int groupId, int studentId){
        var group = GetGroup(groupId);
        if (group != null)
        {
            return group.FindStudent(studentId);
        }
        else
        {
            Console.WriteLine($"Group with ID {groupId} not found.");
        }
        return null;
    }
}