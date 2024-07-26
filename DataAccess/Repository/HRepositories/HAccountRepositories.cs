using BusinessObject.Models;
using DataAccess.DAO;
using DataAccess.Repository.IRepositories;

namespace DataAccess.Repository.HAccountRepositories;

public class HAccountRepositories : IAccountRepositories
{
    public async Task CreateAsync(Account entity) => await AccountDAO.Instance.CreateAsync(entity);

    public async Task DeleteAsync(int id) => await AccountDAO.Instance.DeleteAsync(id);

    public async Task<IEnumerable<Account>> GetAllAsync() => await AccountDAO.Instance.GetAllAsync();

    public async Task<Account> GetByIdAsync(int id) => await AccountDAO.Instance.GetByIdAsync(id);

    public async Task<Account> Login(string email, string pass) => await AccountDAO.Instance.Login(email, pass);

    public async Task UpdateAsync(Account entity) => await AccountDAO.Instance.UpdateAsync(entity);

    public async Task<Account> ValidEmailAsync(string email) => await AccountDAO.Instance.ValidEmailAsync(email);
}
