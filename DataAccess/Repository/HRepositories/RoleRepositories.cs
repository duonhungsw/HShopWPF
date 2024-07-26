using BusinessObject.Models;
using DataAccess.DAO;
using DataAccess.Repository.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.HRepositories
{
    public class RoleRepositories : IRoleRepositories
    {
        public async Task CreateAsync(Role entity) => await RoleDAO.Instance.CreateAsync(entity);

        public async Task DeleteAsync(int id) => await RoleDAO.Instance.DeleteAsync(id);

        public async Task<IEnumerable<Role>> GetAllAsync() => await RoleDAO.Instance.GetAllAsync();

        public async Task<Role> GetByIdAsync(int id) => await RoleDAO.Instance.GetByIdAsync(id);

        public async Task UpdateAsync(Role entity) => await RoleDAO.Instance.UpdateAsync(entity);
    }
}
