using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DAO;

public class RoleDAO : SingletonBase<RoleDAO>, CrudBase<Role>
{
    public async Task CreateAsync(Role entity)
    {
        await appDbContext.Roles.AddAsync(entity);
        await appDbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            appDbContext.Roles.Remove(entity);
            await appDbContext.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Role>> GetAllAsync()
    {
        return await appDbContext.Roles.ToListAsync();
    }

    public async Task<Role> GetByIdAsync(int id)
    {
        var account = await appDbContext.Roles.FirstOrDefaultAsync(x => x.RoleId == id);
        if (account == null)
        {
            //
        }
        return account;
    }



    public async Task UpdateAsync(Role entity)
    {
        var update = await GetByIdAsync(entity.RoleId);
        if (update is not null)
        {
            update.RoleName = entity.RoleName;
            update.Accounts = entity.Accounts;

            appDbContext.Roles.Update(update);
            await appDbContext.SaveChangesAsync();
        }
        else
        {
            throw new Exception("Error");
        }
    }

}
