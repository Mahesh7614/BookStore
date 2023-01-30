
using BookStoreModel;

namespace BookStoreRepository.Interface
{
    public interface IUserRepository
    {
        public UserSignUpModel SignUp(UserSignUpModel userSignUp);
        public string Login(string EmailID, string Password);
        public string ForgotPassword(string emailID);
        public bool ResetPassword(string Password, string emailID);
    }
}
