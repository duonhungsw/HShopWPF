using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace DataAccess.DAO;

public class CategoryDAO : SingletonBase<CategoryDAO>, CrudBase<Category>
{ 
    
    public async Task CreateAsync(Category entity)
    {
        await appDbContext.Categories.AddAsync(entity);
        await appDbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            appDbContext.Categories.Remove(entity);
            await appDbContext.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Category>> GetAllAsync()
    {
        var list = await appDbContext.Categories.Include(x => x.Products).ToListAsync();
        return list;
    }

    public async Task<Category> GetByIdAsync(int id)
    {
        var entity = await appDbContext.Categories.FirstOrDefaultAsync(x => x.CategoryId == id);
        if (entity == null)
        {
            //
        }
        return entity;
    }
    public async Task<Category> checkExistAsync(string name)=> 
                                    await appDbContext.Categories.SingleOrDefaultAsync(c => c.CategoryName == name);
    public async Task UpdateAsync(Category entity)
    {
        var update = await GetByIdAsync(entity.CategoryId);
        if (update is not null)
        {
            update.CategoryName = entity.CategoryName;
            update.Products = entity.Products;
            appDbContext.Categories.Update(update);
            await appDbContext.SaveChangesAsync();
        }
        else
        {
            throw new Exception("Error");
        }
        
    }
    public static string NormalizeCategoryName(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            return string.Empty;
        }
        var normalized = name.ToLowerInvariant();
        normalized = Regex.Replace(normalized, @"[\p{P}\p{S}\s]", "");
        return normalized;
    }
}
