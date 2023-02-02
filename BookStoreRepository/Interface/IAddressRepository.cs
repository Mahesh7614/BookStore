
using BookStoreModel;

namespace BookStoreRepository.Interface
{
    public interface IAddressRepository
    {
        public AddressModel AddAddress(AddressModel addressModel);
        public AddressModel UpdateAddress(AddressModel addressModel);
        public bool DeleteAddress(int AddressID, int UserID);
        public List<AddressModel> GetAllAddress(int UserID);
    }
}
