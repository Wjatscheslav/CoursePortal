using System;
using CoursePortal.Context;
using CoursePortal.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;


namespace CoursePortal.Repository
{
    public class SubscriptionRepository
    {

        private readonly CourseContext _courseContext;

        public SubscriptionRepository(CourseContext courseContext)
        {
            this._courseContext = courseContext;
        }

        public Subscription Create(Subscription subscription)
        {
            Subscription createdSubscription = _courseContext.Subscriptions.Add(subscription);
            _courseContext.SaveChanges();

            return createdSubscription;
        }

        public Subscription Read(int id)
        {
            return _courseContext.Subscriptions
                .Include(subs => subs.Subscriber)
                .ToList()
                .Find(subs => subs.Id == id);
        }

        public List<Subscription> FindByUserId(int id)
        {
            return _courseContext.Subscriptions
                .Include(subs => subs.Subscriber)
                .Where(subs => subs.SubscriberId == id)
                .ToList();
        }

        public List<Subscription> ReadAll()
        {
            return _courseContext.Subscriptions
               .Include(subs => subs.Subscriber)
               .ToList();
        }

        public Subscription Delete(Subscription subscription)
        {
            _courseContext.Subscriptions.Remove(subscription);
            _courseContext.SaveChanges();

            return subscription;
        }
    }
}
