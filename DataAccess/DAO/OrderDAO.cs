using BusinessObject.Models;
using BusinessObject.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DAO;

public class OrderDAO : SingletonBase<OrderDAO>, CrudBase<Order>
{
    public async Task CreateAsync(Order entity)
    {
        await appDbContext.Orders.AddAsync(entity);
        await appDbContext.SaveChangesAsync();
    }
    
    public async Task DeleteAsync(int id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            appDbContext.Orders.Remove(entity);
            await appDbContext.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Order>> GetAllAsync()
    {
        return await appDbContext.Orders.Include(x => x.Product).Include(x=> x.Account).OrderByDescending(x => x.OrderId).ToListAsync();
    }
    public async Task<IEnumerable<Order>> GetAllByIDAsync(int id)
    {
        return await appDbContext.Orders.Include(x => x.Product).Include(x => x.Account).Where(x => x.AccountID == id).OrderByDescending(x => x.OrderId).ToListAsync();
    }

    public async Task<Order> GetByIdAsync(int id)
    {
        var entity = await appDbContext.Orders.FirstOrDefaultAsync(x => x.OrderId == id);
        if (entity == null)
        {
            //
        }
        return entity;
    }

    public async Task UpdateAsync(Order entity)
    {
        try
        {
            //OrderId
            //ProductID
            //Quantity
            //    OrderAddress
            //    OrderTotal
            //    Status
            var update = await GetByIdAsync(entity.OrderId);
            if (update != null)
            {
                update.OrderId = entity.OrderId;
                update.Product = entity.Product;
                update.Account = entity.Account;
                update.Quantity = entity.Quantity;
                update.OrderAddress = entity.OrderAddress;
                update.OrderTotal = entity.OrderTotal;
                update.Status = entity.Status;

                appDbContext.Orders.Update(update);
                await appDbContext.SaveChangesAsync();
            }
            else
            {
                //
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
