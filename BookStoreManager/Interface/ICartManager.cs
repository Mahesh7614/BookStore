
using BookStoreModel;

namespace BookStoreManager.Interface
{
    public interface ICartManager
    {
        public CartModel AddToCart(CartModel cartModel);
        public CartModel UpdateCart(CartModel cartModel);
        public bool DeleteCart(int CartID, int UserID);
        public List<CartModel> GetAllCart(int UserID);
    }
}
