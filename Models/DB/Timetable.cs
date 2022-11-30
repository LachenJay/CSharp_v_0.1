using System;
using System.Collections.Generic;

namespace ProjectCSharp_SchoolGradingSystem.Models.DB;

public partial class Timetable
{
    public string TimetableId { get; set; } = null!;

    public string ClassClassId { get; set; } = null!;

    public string SubjectSubjectId { get; set; } = null!;

    public virtual Class ClassClass { get; set; } = null!;

    public virtual Subject SubjectSubject { get; set; } = null!;
}
