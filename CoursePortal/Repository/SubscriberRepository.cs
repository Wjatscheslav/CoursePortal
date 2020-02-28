using System;
using CoursePortal.Context;
using CoursePortal.Models;
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
        public Subscriber FindById(int id)
        {
            return _courseContext.Subscribers.Where(subs => subs.Id == id).SingleOrDefault();
        }

        public Subscriber FindByLogin(string login)
        {
            return _courseContext.Subscribers.Where(subs => subs.Login == login).SingleOrDefault();
        }
    }

}
