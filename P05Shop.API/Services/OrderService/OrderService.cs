using Microsoft.EntityFrameworkCore;
using P05Shop.API.Models;
using P06Shop.Shared;
using P06Shop.Shared.Services.OrderService;
using P06Shop.Shared.Shop;
using P07Shop.DataSeeder;

namespace P05Shop.API.Services.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly DataContext _dataContext;
      

        public OrderService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<ServiceResponse<Order>> CreateOrderAsync(Order Order)
        {
            try
            {
                _dataContext.Orders.Add(Order);
                await _dataContext.SaveChangesAsync();
                return new ServiceResponse<Order>() { Data = Order, Success = true };
            }
            catch (Exception)
            {
                return new ServiceResponse<Order>()
                {
                    Data = null,
                    Success = false,
                    Message = "Cannot create Order"
                };
            }
        }

        public async Task<ServiceResponse<bool>> DeleteOrderAsync(int id)
        {
            var Order = new Order() { Id = id };
            _dataContext.Orders.Attach(Order);
            _dataContext.Orders.Remove(Order);
            await _dataContext.SaveChangesAsync();

            return new ServiceResponse<bool>() { Data = true, Success = true };
        }

        public async Task<ServiceResponse<List<Order>>> GetOrdersAsync()
        {
            var Orders = await _dataContext.Orders.ToListAsync();

            try
            {
                var response = new ServiceResponse<List<Order>>()
                {
                    Data = Orders,
                    Message = "Ok",
                    Success = true
                };

                return response;
            }
            catch (Exception)
            {
                return new ServiceResponse<List<Order>>()
                {
                    Data = null,
                    Message = "Problem with database",
                    Success = false
                };
            }
        }

        public async Task<ServiceResponse<Order>> UpdateOrderAsync(Order Order)
        {
            try
            {
                var OrderToEdit = new Order() { Id = Order.Id };
                _dataContext.Orders.Attach(OrderToEdit);

                OrderToEdit.Date = Order.Date;
                OrderToEdit.TotalPrice = Order.TotalPrice;

                await _dataContext.SaveChangesAsync();
                return new ServiceResponse<Order> { Data = OrderToEdit, Success = true };
            }
            catch (Exception)
            {
                return new ServiceResponse<Order>
                {
                    Data = null,
                    Success = false,
                    Message = "An error occured while updating Order"
                };
            }
        }

        public async Task<ServiceResponse<Order>> GetOrderByIdAsync(int id)
        {
            try
            {
                var Order = await _dataContext.Orders.FindAsync(id);
                var response = new ServiceResponse<Order>()
                {
                    Data = Order,
                    Message = "Ok",
                    Success = true
                };

                return response;
            }
            catch (Exception)
            {
                return new ServiceResponse<Order>()
                {
                    Data = null,
                    Message = "Problem with database",
                    Success = false
                };
            }
        }
    }
}
