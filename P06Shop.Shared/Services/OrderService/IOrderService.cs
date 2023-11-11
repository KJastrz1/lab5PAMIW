using P06Shop.Shared;
using P06Shop.Shared.Shop;

namespace P06Shop.Shared.Services.OrderService
{
    public interface IOrderService
    {
        Task<ServiceResponse<List<Order>>> GetOrdersAsync();

        Task<ServiceResponse<Order>> UpdateOrderAsync(Order Order);

        Task<ServiceResponse<bool>> DeleteOrderAsync(int id);

        Task<ServiceResponse<Order>> CreateOrderAsync(Order Order);

        Task<ServiceResponse<Order>> GetOrderByIdAsync(int id);
    }
}
