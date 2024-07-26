using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.IRepositories
{
    public interface ICategoryRepositories
    {
        Task CreateAsync(Category entity);
        Task DeleteAsync(int id);
        Task<IEnumerable<Category>> GetAllAsync();
        Task<Category> GetByIdAsync(int id);
        Task UpdateAsync(Category entity);
        Task<Category> checkExistAsync(string name);
    }
}
