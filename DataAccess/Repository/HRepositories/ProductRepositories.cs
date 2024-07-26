using BusinessObject.Models;
using DataAccess.DAO;
using DataAccess.Repository.IRepositories;

namespace DataAccess.Repository.HRepositories;

public class ProductRepositories : IProductRepositories
{
    public async Task CreateAsync(Product entity) => await ProductDAO.Instance.CreateAsync(entity);

    public async Task DeleteAsync(int id) => await ProductDAO.Instance.DeleteAsync(id);

    public async Task<IEnumerable<Product>> GetAllAsync() => await ProductDAO.Instance.GetAllAsync();

    public async Task<Product> GetByIdAsync(int id) => await ProductDAO.Instance.GetByIdAsync(id);

    public async Task UpdateAsync(Product entity) => await ProductDAO.Instance.UpdateAsync(entity);
}
