using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using P04WeatherForecastAPI.Client.Models;
using P04WeatherForecastAPI.Client.Services.WeatherServices;
using P06Shop.Shared.MessageBox;
using P06Shop.Shared.Services.OrderService;
using P06Shop.Shared.Shop;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

namespace P04WeatherForecastAPI.Client.ViewModels
{
    public partial class OrdersViewModel : ObservableObject
    {
        private const int ItemsPerPage = 10;
        private int currentPage = 1;
        public int TotalPages => (int)Math.Ceiling((double)Orders.Count / ItemsPerPage);
        private readonly IOrderService _orderService;
        private readonly OrderDetailsView _orderDetailsView;
        private readonly IMessageDialogService _messageDialogService;
        public ObservableCollection<Order> Orders { get; set; }
        public ObservableCollection<Order> DisplayedOrders { get; set; }

        [ObservableProperty]
        private String currentPageText = "1";

        [ObservableProperty]
        private Order selectedOrder;

        public OrdersViewModel(
            IOrderService OrderService,
            IMessageDialogService messageDialogService,
            OrderDetailsView orderDetailsView
        )
        {
            _orderDetailsView = orderDetailsView;
            _messageDialogService = messageDialogService;
            _orderService = OrderService;
            Orders = new ObservableCollection<Order>();
            DisplayedOrders = new ObservableCollection<Order>();
        }

        public async Task GetOrders()
        {
            Orders.Clear();
            var OrdersResult = await _orderService.GetOrdersAsync();
            if (OrdersResult.Success)
            {
                foreach (var p in OrdersResult.Data)
                {
                    Orders.Add(p);
                }
                UpdateDisplayedOrders();
            }
        }

        private void UpdateDisplayedOrders()
        {
            int startIndex = (currentPage - 1) * ItemsPerPage;           
            DisplayedOrders.Clear();
            for(int i=startIndex; i<startIndex+ItemsPerPage+1&&i<Orders.Count; i++)
            {
                DisplayedOrders.Add(Orders[i]);
            }
        }

        private void GoToPage(int pageNumber)
        {
            if (pageNumber < 1 || pageNumber > TotalPages)
                return;

            currentPage = pageNumber;
            CurrentPageText = $"{currentPage}";
            UpdateDisplayedOrders();
        }

        [RelayCommand]
        public void PrevPage()
        {
            GoToPage(currentPage - 1);
        }

        [RelayCommand]
        public void NextPage()
        {
            GoToPage(currentPage + 1);
        }

        [RelayCommand]
        public async Task ShowDetails(Order order)
        {
            _orderDetailsView.Show();
            _orderDetailsView.DataContext = this;
            SelectedOrder = order;
        }

        public async Task CreateOrder()
        {
            var newOrder = new Order()
            {
                TotalPrice = selectedOrder.TotalPrice,
                Date = selectedOrder.Date,
            };

            var result = await _orderService.CreateOrderAsync(newOrder);
            if (result.Success)
                await GetOrders();
            else
                _messageDialogService.ShowMessage(result.Message);
        }

        public async Task UpdateOrder()
        {
            var OrderToUpdate = new Order()
            {
                Id = selectedOrder.Id,
                TotalPrice = selectedOrder.TotalPrice,
                Date = selectedOrder.Date,
            };

            await _orderService.UpdateOrderAsync(OrderToUpdate);
            GetOrders();
        }

        public async Task DeleteOrder()
        {
            await _orderService.DeleteOrderAsync(selectedOrder.Id);
            await GetOrders();
        }



        [RelayCommand]
        public async Task Save()
        {
            if (selectedOrder.Id == 0)
            {
                CreateOrder();
            }
            else
            {
                UpdateOrder();
            }
        }

        [RelayCommand]
        public async Task Delete()
        {
            DeleteOrder();
        }


        [RelayCommand]
        public async Task New()
        {
            _orderDetailsView.Show();
            _orderDetailsView.DataContext = this;
            SelectedOrder = new Order
            {
                Date = DateTime.Now
            };
        }



    }
}
