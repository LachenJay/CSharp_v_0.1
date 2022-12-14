using System.Collections.Generic;

namespace ProjectCSharp_SchoolGradingSystem.Models.DB;

public class Student
{
    public string StudentId { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string EMail { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string ClassClassId { get; set; } = null!;

    public virtual Class ClassClass { get; set; } = null!;

    public virtual ICollection<Grade> Grades { get; } = new List<Grade>();
}