using BusinessObject.Models;

namespace DataAccess.Repository.IRepositories;

public interface IRoleRepositories
{
    Task CreateAsync(Role entity);
    Task DeleteAsync(int id);
    Task<IEnumerable<Role>> GetAllAsync();
    Task<Role> GetByIdAsync(int id);
    Task UpdateAsync(Role entity);
}
