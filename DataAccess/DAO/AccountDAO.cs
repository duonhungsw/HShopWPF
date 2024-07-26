using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update;

namespace DataAccess.DAO;

public class AccountDAO : SingletonBase<AccountDAO>, CrudBase<Account>
{
    public async Task CreateAsync(Account entity)
    {
        await appDbContext.Accounts.AddAsync(entity);
        await appDbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            appDbContext.Accounts.Remove(entity);
            await appDbContext.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Account>> GetAllAsync()
    {
        return await appDbContext.Accounts.Include(x => x.Role).ToListAsync();
    }

    public async Task<Account> GetByIdAsync(int id)
    {
        var account = await appDbContext.Accounts.FirstOrDefaultAsync(x => x.AccountId == id);
        if (account == null)
        {
            //
        }
        return account;
    }

    public async Task<Account> ValidEmailAsync(string email)
    {
        var account = await appDbContext.Accounts.FirstOrDefaultAsync(x => x.AccountEmail.Equals(email));
        if (account == null)
        {
            //
        }
        return account;
    }


    public async Task UpdateAsync(Account entity)
    {
        var update = await GetByIdAsync(entity.AccountId);
        if (update is not null)
        {
            update.AccountPhone = entity.AccountPhone;
            update.AccountId = entity.AccountId;
            update.AccountName = entity.AccountName;
            update.AccountAddress = entity.AccountAddress;
            update.AccountPassword = entity.AccountPassword;
            update.RoleID = entity.RoleID;
            update.Gender = entity.Gender;
            update.AccountEmail = entity.AccountEmail;

            appDbContext.Accounts.Update(update);
            await appDbContext.SaveChangesAsync();
        }
        else
        {
            throw new Exception("Error");
        }
    }
    public async Task<Account> Login(string email, string pass)
    {
        var account = await appDbContext.Accounts
                            .Include(x => x.Role).
                            FirstOrDefaultAsync(x => x.AccountEmail.ToLower().Equals(email) && 
                                                                    x.AccountPassword.ToLower().Equals(pass));
        if (account == null)
        {
            //
        }
        return account;
    }

}
