
using BookStoreManager.Interface;
using BookStoreRepository.Interface;

namespace BookStoreManager.Manager
{
    public class AdminManager : IAdminManager
    {
        private readonly IAdminRepository adminRepository;

        public AdminManager(IAdminRepository adminRepository)
        {
            this.adminRepository = adminRepository;
        }
        public string AdminLogin(string EmailID, string Password)
        {
            try
            {
                return this.adminRepository.AdminLogin(EmailID, Password);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
