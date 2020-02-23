using CoursePortal.Models;
using System.Data.Entity;

namespace CoursePortal.Context
{
    public class CourseContext : DbContext
    {
        public CourseContext() : base("Server=localhost,5433;Database=Course;User Id=sa;Password=#assw@!d1")
        { }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Subscriber> Subscribers { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>()
                .HasRequired(course => course.Author)
                .WithMany(author => author.Courses)
                .HasForeignKey(course => course.AuthorId)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Course>()
                .HasRequired(course => course.Subject)
                .WithMany(subject => subject.Courses)
                .HasForeignKey(course => course.SubjectId)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Subscription>()
                .HasRequired(subscription => subscription.Course)
                .WithMany(course => course.Subscriptions)
                .HasForeignKey(subscription => subscription.CourseId)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Subscription>()
                .HasRequired(subscription => subscription.Subscriber)
                .WithMany(subscriber => subscriber.Subscriptions)
                .HasForeignKey(subscription => subscription.SubscriberId)
                .WillCascadeOnDelete(true);
        }
    }
}
