using BusinessObject.Models;

namespace DataAccess.Repository.IRepositories;

public interface IProductRepositories
{
    Task CreateAsync(Product entity);
    Task DeleteAsync(int id);
    Task<IEnumerable<Product>> GetAllAsync();
    Task<Product> GetByIdAsync(int id);
    Task UpdateAsync(Product entity);
}
