using BusinessObject.Models;

namespace DataAccess.Repository.IRepositories;

public interface IAccountRepositories
{
     Task CreateAsync(Account entity);
     Task DeleteAsync(int id);
     Task<IEnumerable<Account>> GetAllAsync();
     Task<Account> GetByIdAsync(int id);
     Task UpdateAsync(Account entity);
     Task<Account> Login(string email, string pass);
     Task<Account> ValidEmailAsync(string email);


}
