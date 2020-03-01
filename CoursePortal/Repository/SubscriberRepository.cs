using System;
using CoursePortal.Context;
using CoursePortal.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CoursePortal.Repository
{
    public class SubscriberRepository
    {
        private CourseContext _courseContext;

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
        public Subscriber Read(int id)
        {
            return _courseContext.Subscribers
                .Include(subs => subs.Subscriptions)
                .ToList()
                .Find(subs => subs.Id == id);
        }

        public Subscriber FindByLogin(string login)
        {
            return _courseContext.Subscribers
                .Include(subs => subs.Subscriptions)
                .ToList()
                .Find(subs => subs.Login == login);
        }
    }

}
