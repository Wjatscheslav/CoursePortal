using System;
namespace CoursePortal.Repository
{
    public interface UserRepository<Client>
    {

        public Client Create(Client user);
    }
}
