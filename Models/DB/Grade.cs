namespace ProjectCSharp_SchoolGradingSystem.Models.DB;

public class Grade
{
    public string Grade1 { get; set; }

    public string StudentStudentId { get; set; } = null!;

    public string SubjectId { get; set; } = null!;

    public string TeacherTeacherId { get; set; } = null!;

    public string Grade_description { get; set; } = null!;

    public string GradeId { get; set; } = null!;

    public virtual Class ClassClass { get; set; } = null!;

    public virtual Student StudentStudent { get; set; } = null!;

    public virtual Teacher TeacherTeacher { get; set; } = null!;
}