using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DAO;

public class ProductDAO : SingletonBase<ProductDAO>, CrudBase<Product>
{
    public async Task CreateAsync(Product entity)
    {
        await appDbContext.Products.AddAsync(entity);
        await appDbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            appDbContext.Products.Remove(entity);
            await appDbContext.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await appDbContext.Products.Include(x => x.Category).ToListAsync();
    }

    public async Task<Product> GetByIdAsync(int id)
    {
        var entity = await appDbContext.Products.FindAsync(id);
        if (entity == null)
        {
            //
        }
        return entity;
    }

    public async Task UpdateAsync(Product entity)
    {
        var update = await GetByIdAsync(entity.ProductId);
        if (update is not null)
        {
            update.ProductName = entity.ProductName;
            update.Price = entity.Price;
            update.ImagePath = entity.ImagePath;
            update.CategoryID = entity.CategoryID;

            appDbContext.Products.Update(update);
            await appDbContext.SaveChangesAsync();
        }
        else
        {
            throw new Exception("Error");
        }
    }
    
}
