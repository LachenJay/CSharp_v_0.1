using Microsoft.EntityFrameworkCore;

namespace ProjectCSharp_SchoolGradingSystem.Models.DB;

public partial class SchoolSystem1Context : DbContext
{
    public SchoolSystem1Context()
    {
    }

    public SchoolSystem1Context(DbContextOptions<SchoolSystem1Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<Grade> Grades { get; set; }

    public virtual DbSet<Student> Student { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    public virtual DbSet<Timetable> Timetables { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=E:\\GIT\\CSHARP_V_0.1\\SCHOOLSYSTEM1\\SCHOOLSYSTEM1.MDF;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.AdminId).HasName("admin_pk");

            entity.ToTable("admin");

            entity.Property(e => e.AdminId)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("admin_id");
            entity.Property(e => e.EMail)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("e_mail");
            entity.Property(e => e.Name)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Surname)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("surname");
        });

        modelBuilder.Entity<Class>(entity =>
        {
            entity.HasKey(e => e.ClassId).HasName("class_pk");

            entity.ToTable("class");

            entity.Property(e => e.ClassId)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("class_id");
        });

        modelBuilder.Entity<Grade>(entity =>
        {
            entity.HasKey(e => e.GradeId).HasName("grade_pk");

            entity.ToTable("grades");

            entity.Property(e => e.GradeId)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("grade_id");
            entity.Property(e => e.Grade1)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("grade");
            entity.Property(e => e.SubjectId)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("subject_id");
            entity.Property(e => e.Grade_description)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("grade_description");
            entity.Property(e => e.StudentStudentId)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("student_student_id");
            entity.Property(e => e.TeacherTeacherId)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("teacher_teacher_id");

            entity.HasOne(d => d.ClassClass).WithMany(p => p.Grades)
                .HasForeignKey(d => d.SubjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("subject_fk");

            entity.HasOne(d => d.StudentStudent).WithMany(p => p.Grades)
                .HasForeignKey(d => d.StudentStudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("grades_student_fk");

            entity.HasOne(d => d.TeacherTeacher).WithMany(p => p.Grades)
                .HasForeignKey(d => d.TeacherTeacherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("grades_teacher_fk");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("student_pk");

            entity.ToTable("student");

            entity.Property(e => e.StudentId)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("student_id");
            entity.Property(e => e.ClassClassId)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("class_class_id");
            entity.Property(e => e.EMail)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("e_mail");
            entity.Property(e => e.Name)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Surname)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("surname");

            entity.HasOne(d => d.ClassClass).WithMany(p => p.Students)
                .HasForeignKey(d => d.ClassClassId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("student_class_fk");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.SubjectId).HasName("subject_pk");

            entity.ToTable("subject");

            entity.Property(e => e.SubjectId)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("subject_id");
            entity.Property(e => e.Name)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.TeacherTeacherId)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("teacher_teacher_id");

            entity.HasOne(d => d.TeacherTeacher).WithMany(p => p.Subjects)
                .HasForeignKey(d => d.TeacherTeacherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("subject_teacher_fk");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.TeacherId).HasName("teacher_pk");

            entity.ToTable("teacher");

            entity.Property(e => e.TeacherId)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("teacher_id");
            entity.Property(e => e.EMail)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("e_mail");
            entity.Property(e => e.Name)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Surname)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("surname");
        });

        modelBuilder.Entity<Timetable>(entity =>
        {
            entity.HasKey(e => e.TimetableId).HasName("timetable_pk");

            entity.ToTable("timetable");

            entity.HasIndex(e => e.SubjectSubjectId, "timetable__idx").IsUnique();

            entity.HasIndex(e => e.ClassClassId, "timetable__idxv1").IsUnique();

            entity.Property(e => e.TimetableId)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("timetable_id");
            entity.Property(e => e.ClassClassId)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("class_class_id");
            entity.Property(e => e.SubjectSubjectId)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("subject_subject_id");

            entity.HasOne(d => d.ClassClass).WithOne(p => p.Timetable)
                .HasForeignKey<Timetable>(d => d.ClassClassId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("timetable_class_fk");

            entity.HasOne(d => d.SubjectSubject).WithOne(p => p.Timetable)
                .HasForeignKey<Timetable>(d => d.SubjectSubjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("timetable_subject_fk");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}