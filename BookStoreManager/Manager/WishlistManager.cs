
using BookStoreManager.Interface;
using BookStoreModel;
using BookStoreRepository.Interface;

namespace BookStoreManager.Manager
{
    public class WishlistManager : IWishlistManager
    {
        private readonly IWishlistRepository wishlistRepository;
        public WishlistManager(IWishlistRepository wishlistRepository)
        {
            this.wishlistRepository = wishlistRepository;
        }
        public WishlistModel AddToWishlist(WishlistModel wishlistModel)
        {
            try
            {
                return this.wishlistRepository.AddToWishlist(wishlistModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool DeleteWishlist(int WishlistID, int UserID)
        {
            try
            {
                return this.wishlistRepository.DeleteWishlist(WishlistID, UserID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<WishlistModel> GetAllWishlist(int UserID)
        {
            try
            {
                return this.wishlistRepository.GetAllWishlist(UserID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
