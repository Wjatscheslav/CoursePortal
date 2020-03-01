using System;
using System.Collections.Generic;

namespace CoursePortal.Entities
{
    public class Subscriber
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public List<Subscription> Subscriptions { get; set; }
    }
}
