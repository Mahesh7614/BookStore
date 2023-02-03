
using BookStoreModel;

namespace BookStoreRepository.Interface
{
    public interface IOrderRepository
    {
        public PlaceOrderModel PlaceOrder(PlaceOrderModel placeOrderModel);
        public List<GetOrdersModel> GetAllOrders(int UserID);
        public bool DeleteOrder(int OrderID, int UserID);

    }
}
