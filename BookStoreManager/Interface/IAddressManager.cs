
using BookStoreModel;

namespace BookStoreManager.Interface
{
    public interface IAddressManager
    {
        public AddressModel AddAddress(AddressModel addressModel);
        public AddressModel UpdateAddress(AddressModel addressModel);
        public bool DeleteAddress(int AddressID, int UserID);
        public List<AddressModel> GetAllAddress(int UserID);
    }
}
