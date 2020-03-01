using CoursePortal.Entities;
using System.Data.Entity;

namespace CoursePortal.Context
{
    public class CourseContext : DbContext
    {
        public CourseContext() : base("Server=192.168.99.100,5433;Database=Course;User Id=sa;Password=#assw@!d1")
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
                .HasForeignKey(course => course.AuthorId);

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
                .HasForeignKey(subscription => subscription.SubscriberId);

            modelBuilder.Entity<Subscriber>()
                .HasMany(subs => subs.Subscriptions)
                .WithRequired(subscription => subscription.Subscriber)
                .HasForeignKey(subscription => subscription.SubscriberId);

            modelBuilder.Entity<Author>()
                .HasMany(auth => auth.Courses)
                .WithRequired(course => course.Author)
                .HasForeignKey(course => course.AuthorId);

        }
    }
}
