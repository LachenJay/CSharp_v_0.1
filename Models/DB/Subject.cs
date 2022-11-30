using System;
using System.Collections.Generic;

namespace ProjectCSharp_SchoolGradingSystem.Models.DB;

public partial class Subject
{
    public string SubjectId { get; set; } = null!;

    public string? Name { get; set; }

    public string TeacherTeacherId { get; set; } = null!;

    public virtual Teacher TeacherTeacher { get; set; } = null!;

    public virtual Timetable? Timetable { get; set; }
}
