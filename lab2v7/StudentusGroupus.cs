using System.Collections.Generic; 

namespace Lab2v7;

public class StudentGroup
{
    private List<Student> _students = new List<Student>();

    public int Count
    {
        get { return _students.Count; }
    }

    public Student this[int id]
    {
        get
        {
            foreach (var student in _students)
            {
                if (student.ID == id)
                {
                    return student;
                }
            }
            return null; 
        }
    }

    public static StudentGroup operator +(StudentGroup group, Student student)
    {
        group._students.Add(student);
        return group;
    }

    public static StudentGroup operator -(StudentGroup group, Student student)
    {
        group._students.RemoveAll(s => s.ID == student.ID); 
        return group;
    }

    public static bool operator ==(StudentGroup group1, StudentGroup group2)
    {
        if (group1.Count != group2.Count) return false;
        for (int i = 0; i < group1.Count; i++)
        {
            if (group1._students[i].ID != group2._students[i].ID) return false;
        }
        return true;
    }

    public static bool operator !=(StudentGroup group1, StudentGroup group2)
    {
        return !(group1 == group2);
    }

    public static bool operator <=(StudentGroup group1, StudentGroup group2)
    {
        return group1.Count <= group2.Count;
    }

    public static bool operator >=(StudentGroup group1, StudentGroup group2)
    {
        return group1.Count >= group2.Count;
    }

    public static StudentGroup operator ++(StudentGroup group)
    {
        int nextId = group.Count + 1;
        group._students.Add(new Student(nextId, "New Student"));
        return group;
    }

    public static StudentGroup operator --(StudentGroup group)
    {
        if (group.Count > 0)
        {
            group._students.RemoveAt(group.Count - 1);
        }
        return group;
    }

    public static bool operator true(StudentGroup group)
    {
        return group.Count > 0;
    }

    public static bool operator false(StudentGroup group)
    {
        return group.Count == 0;
    }

    public void PrintStudents()
    {
        foreach (var student in _students)
        {
            Console.WriteLine(student);
        }
    }
}