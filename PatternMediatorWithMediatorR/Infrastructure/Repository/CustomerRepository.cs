using PatternMediatorWithMediatorR.Infrastructure.Model;

namespace PatternMediatorWithMediatorR.Infrastructure.Repository;

public class CustomerRepository : IRepository<Customer>
{
    public CustomerRepository()
    {
        
    }

    private static Dictionary<Guid, Customer> Customers = new Dictionary<Guid, Customer>();

    public async Task<IEnumerable<Customer>> GetAll()
    {
        return await Task.Run(() => Customers.Values.ToList());
    }

    public async Task<Customer> Get(Guid id)
    {
        return await Task.Run(() => Customers.GetValueOrDefault(id));
    }

    public async Task Save(Customer customer)
    {
        await Task.Run(() => Customers.Add(customer.Id, customer));
    }

    public async Task Edit(Customer customer)
    {
        await Task.Run(() =>
        {
            Customers.Remove(customer.Id);
            Customers.Add(customer.Id, customer);
        });
    }

    public async Task Delete(Guid id)
    {
        await Task.Run(() => Customers.Remove(id));
    }
}


