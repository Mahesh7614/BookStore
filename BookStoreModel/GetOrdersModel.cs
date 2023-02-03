
namespace BookStoreModel
{
    public class GetOrdersModel
    {
        public int OrderID { get; set; }
        public int CartID { get; set; }
        public int AddressID { get; set; }
        public int Total_Price { get; set; }
        public DateTime Date_Time { get; set; }
        public int UserID { get; set; }
    }
}
