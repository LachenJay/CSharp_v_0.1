using System;
using System.Collections.Generic;

namespace ProjectCSharp_SchoolGradingSystem.Models.DB;

public partial class Teacher
{
    public string TeacherId { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string EMail { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<Grade> Grades { get; } = new List<Grade>();

    public virtual ICollection<Subject> Subjects { get; } = new List<Subject>();
}
