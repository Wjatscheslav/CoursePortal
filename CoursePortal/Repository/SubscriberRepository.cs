using System;
using CoursePortal.Context;
using CoursePortal.Models;

namespace CoursePortal.Repository
{
    public class SubscriberRepository
    {
        private readonly CourseContext _courseContext;

        public SubscriberRepository(CourseContext courseContext)
        {
            _courseContext = courseContext;
        }

        public Subscriber Create(Subscriber subscriber)
        {
            Subscriber createdSubscriber = _courseContext.Subscribers.Add(subscriber);
            _courseContext.SaveChanges();

            return createdSubscriber;
        }
    }

}
