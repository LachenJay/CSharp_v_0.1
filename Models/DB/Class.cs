using System;
using System.Collections.Generic;

namespace ProjectCSharp_SchoolGradingSystem.Models.DB;

public partial class Class
{
    public string ClassId { get; set; } = null!;

    public virtual ICollection<Grade> Grades { get; } = new List<Grade>();

    public virtual ICollection<Student> Students { get; } = new List<Student>();

    public virtual Timetable? Timetable { get; set; }
}
