using BusinessObject.Models;

namespace DataAccess.Repository.IRepositories;
public interface IOrderRepositories
{
    Task CreateAsync(Order entity);
    Task DeleteAsync(int id);
    Task<IEnumerable<Order>> GetAllAsync();
    Task<Order> GetByIdAsync(int id);
    Task UpdateAsync(Order entity);
    Task<IEnumerable<Order>> GetAllByIDAsync(int id);
}
