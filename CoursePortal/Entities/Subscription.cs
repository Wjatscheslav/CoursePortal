using System;
namespace CoursePortal.Entities
{
    public class Subscription
    {
        public int Id { get; set; }
        public Course Course { get; set; }
        public int CourseId { get; set; }
        public Subscriber Subscriber { get; set; }
        public int SubscriberId { get; set; }
    }
}
