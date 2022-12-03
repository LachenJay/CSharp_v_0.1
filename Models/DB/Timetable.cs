namespace ProjectCSharp_SchoolGradingSystem.Models.DB;

public class Timetable
{
    public string TimetableId { get; set; } = null!;

    public string ClassClassId { get; set; } = null!;

    public string SubjectSubjectId { get; set; } = null!;

    public virtual Class ClassClass { get; set; } = null!;

    public virtual Subject SubjectSubject { get; set; } = null!;
}