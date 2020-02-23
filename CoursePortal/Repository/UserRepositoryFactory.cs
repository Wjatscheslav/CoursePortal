using System;
using System.Collections.Generic;
using CoursePortal.Entities;
using CoursePortal.Models;

namespace CoursePortal.Repository
{
    public class UserRepositoryFactory
    {

        private List<UserRepository<Client>> repositories = new List<UserRepository<Client>>();

        public UserRepositoryFactory(
            SubscriberRepository subscriberRepository,
            AuthorRepository authorRepository)
        {
            repositories.Add(subscriberRepository);
        }

        public UserRepository<Client> GetUserRepository(User user)
        {
            if (user.isAuthor)
            {
                return authorRepository;
            }
            return subscriberRepository;
        }
    }
}
