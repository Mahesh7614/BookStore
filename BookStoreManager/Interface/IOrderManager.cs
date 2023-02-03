
using BookStoreModel;

namespace BookStoreManager.Interface
{
    public interface IOrderManager
    {
        public PlaceOrderModel PlaceOrder(PlaceOrderModel placeOrderModel);
        public List<GetOrdersModel> GetAllOrders(int UserID);
        public bool DeleteOrder(int OrderID, int UserID);

    }
}
