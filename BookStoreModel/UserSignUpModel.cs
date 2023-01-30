namespace BookStoreModel
{
    public class UserSignUpModel
    {
        public int UserID { get; set; }
        public string? FullName { get; set; }
        public string? EmailID { get; set; }
        public string? Password { get; set; }
        public long MobileNumber { get; set; }
    }
}