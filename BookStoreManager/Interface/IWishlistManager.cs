
using BookStoreModel;

namespace BookStoreManager.Interface
{
    public interface IWishlistManager
    {
        public WishlistModel AddToWishlist(WishlistModel wishlistModel);
        public bool DeleteWishlist(int WishlistID, int UserID);
        public List<WishlistModel> GetAllWishlist(int UserID);
    }
}
