using API.Data.Constants;
using API.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

/// <summary>
/// Data context
/// </summary>
public partial class DataContext : IdentityDbContext<User, Role, Guid>
{
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="options"></param>
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }

    /// <summary>
    /// User
    /// </summary>
    public virtual DbSet<User> User { get; set; }

    /// <summary>
    /// Role
    /// </summary>
    public virtual DbSet<Role> Role { get; set; }

    /// <summary>
    /// Achievement
    /// </summary>
    public virtual DbSet<Achievement> Achievement { get; set; }

    /// <summary>
    /// Answer
    /// </summary>
    public virtual DbSet<Answer> Answer { get; set; }

    /// <summary>
    /// Topic
    /// </summary>
    public virtual DbSet<Topic> Topic { get; set; }

    /// <summary>
    /// Class
    /// </summary>
    public virtual DbSet<Class> Class { get; set; }

    /// <summary>
    /// Course
    /// </summary>
    public virtual DbSet<Course> Course { get; set; }

    /// <summary>
    /// Notification
    /// </summary>
    public virtual DbSet<Notification> Notification { get; set; }

    /// <summary>
    /// Question
    /// </summary>
    public virtual DbSet<Question> Question { get; set; }

    /// <summary>
    /// Test
    /// </summary>
    public virtual DbSet<Test> Test { get; set; }

    /// <summary>
    /// Admin
    /// </summary>
    public virtual DbSet<Admin> Admin { get; set; }

    /// <summary>
    /// Teacher
    /// </summary>
    public virtual DbSet<Teacher> Teacher { get; set; }

    /// <summary>
    /// Student
    /// </summary>
    public virtual DbSet<Student> Student { get; set; }

    /// <summary>
    /// Feedback
    /// </summary>
    public virtual DbSet<Feedback> Feedback { get; set; }

    /// <summary>
    /// StudentJoinClass
    /// </summary>
    public virtual DbSet<StudentJoinClass> StudentJoinClass { get; set; }

    /// <summary>
    /// StudentJoinTest
    /// </summary>
    public virtual DbSet<StudentJoinTest> StudentJoinTest { get; set; }

    /// <summary>
    /// TestAnswer
    /// </summary>
    public virtual DbSet<TestAnswer> TestAnswer { get; set; }

    /// <summary>
    /// UserEarnedAchievement
    /// </summary>
    public virtual DbSet<UserEarnedAchievement> UserEarnedAchievement { get; set; }

    /// <summary>
    /// On model creating
    /// </summary>
    /// <param name="builder"></param>
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Config Role
        builder.Entity<IdentityUserRole<Guid>>().HasKey(x => new { x.UserId, x.RoleId });

        // Config Student Join Class
        builder.Entity<StudentJoinClass>()
            .HasOne(x => x.Student)
            .WithMany(x => x.StudentJoinClasses)
            .HasForeignKey(x => x.StudentId)
            .OnDelete(DeleteBehavior.NoAction);

        // Config Student Join Test
        builder.Entity<StudentJoinTest>()
            .HasOne(x => x.Test)
            .WithMany(x => x.StudentJoinTests)
            .HasForeignKey(x => x.StudentId)
            .OnDelete(DeleteBehavior.NoAction);

        // Config Feedback
        builder.Entity<Feedback>()
            .HasOne(x => x.User)
            .WithMany(x => x.Feedbacks)
            .HasForeignKey(x => x.FeedbackId)
            .OnDelete(DeleteBehavior.NoAction);

        // Config TestAnswer
        builder.Entity<TestAnswer>()
            .HasOne(x => x.Student)
            .WithMany(x => x.TestAnswers)
            .HasForeignKey(x => x.TestAnswerId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Entity<TestAnswer>()
            .HasOne(x => x.Question)
            .WithMany(x => x.TestAnswers)
            .HasForeignKey(x => x.QuestionId)
            .OnDelete(DeleteBehavior.NoAction);

        // Config Notification
        builder.Entity<Notification>()
            .HasOne(x => x.Teacher)
            .WithMany(x => x.Notifications)
            .HasForeignKey(x => x.TeacherId)
            .OnDelete(DeleteBehavior.NoAction);

        // Config Test
        builder.Entity<Test>()
            .HasOne(x => x.Course)
            .WithMany(x => x.Tests)
            .HasForeignKey(x => x.CourseId)
            .OnDelete(DeleteBehavior.NoAction);

        OnModelCreatingPartial(builder);
    }

    partial void OnModelCreatingPartial(ModelBuilder builder);
}
