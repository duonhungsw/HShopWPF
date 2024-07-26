using BusinessObject.Models;
using DataAccess.DAO;
using DataAccess.Repository.IRepositories;

namespace DataAccess.Repository.HRepositories;

public class CategoryRepositories : ICategoryRepositories
{
    public async Task CreateAsync(Category entity) => await CategoryDAO.Instance.CreateAsync(entity);

    public async Task DeleteAsync(int id) => await CategoryDAO.Instance.DeleteAsync(id);

    public async Task<IEnumerable<Category>> GetAllAsync() => await CategoryDAO.Instance.GetAllAsync();

    public async Task<Category> GetByIdAsync(int id) => await CategoryDAO.Instance.GetByIdAsync(id);
    public async Task UpdateAsync(Category entity) => await CategoryDAO.Instance.UpdateAsync(entity);
    public async Task<Category> checkExistAsync(string name) => await CategoryDAO.Instance.checkExistAsync(name);
}
