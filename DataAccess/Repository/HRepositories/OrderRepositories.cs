using BusinessObject.Models;
using DataAccess.DAO;
using DataAccess.Repository.IRepositories;

namespace DataAccess.Repository.HRepositories;

public class OrderRepositories : IOrderRepositories
{
    public async Task CreateAsync(Order entity) => await OrderDAO.Instance.CreateAsync(entity);

    public async Task DeleteAsync(int id) => await OrderDAO.Instance.DeleteAsync(id);

    public async Task<IEnumerable<Order>> GetAllAsync() => await OrderDAO.Instance.GetAllAsync();

    public async Task<IEnumerable<Order>> GetAllByIDAsync(int id) => await OrderDAO.Instance.GetAllByIDAsync(id);

    public async Task<Order> GetByIdAsync(int id) => await OrderDAO.Instance.GetByIdAsync(id);

    public async Task UpdateAsync(Order entity) => await OrderDAO.Instance.UpdateAsync(entity);
}
