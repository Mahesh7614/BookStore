
using BookStoreModel;

namespace BookStoreRepository.Interface
{
    public interface IWishlistRepository
    {
        public WishlistModel AddToWishlist(WishlistModel wishlistModel);
        public bool DeleteWishlist(int WishlistID, int UserID);
        public List<WishlistModel> GetAllWishlist(int UserID);

    }
}
