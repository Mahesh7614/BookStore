
using BookStoreManager.Interface;
using BookStoreModel;
using BookStoreRepository.Interface;

namespace BookStoreManager.Manager
{
    public class CartManager : ICartManager
    {
        private readonly ICartRepository cartRepository;
        public CartManager(ICartRepository cartRepository)
        {
            this.cartRepository = cartRepository;
        }
        public CartModel AddToCart(CartModel cartModel)
        {
            try
            {
                return this.cartRepository.AddToCart(cartModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public CartModel UpdateCart(CartModel cartModel)
        {
            try
            {
                return this.cartRepository.UpdateCart(cartModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool DeleteCart(int CartID, int UserID)
        {
            try
            {
                return this.cartRepository.DeleteCart(CartID, UserID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<CartModel> GetAllCart(int UserID)
        {
            try
            {
                return this.cartRepository.GetAllCart(UserID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
