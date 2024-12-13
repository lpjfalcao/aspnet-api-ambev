using SalesManagementSystem.Domain.Entities;
using SalesManagementSystem.Domain.Interfaces.Repositories;

namespace SalesManagementSystem.ORM.Repositories
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(DefaultContext context) : base(context)
        {
        }
    }
}
