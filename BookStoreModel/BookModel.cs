
namespace BookStoreModel
{
    public class BookModel
    {
        public int BookID { get; set; }
        public string? BookName { get; set; }
        public string? AuthorName { get; set; }
        public int Ratings { get; set; }
        public long No_Of_Peoples_Rated { get; set; }
        public int Discount_Price { get; set; }
        public int Original_Price { get; set; }
        public string? BookDetails { get; set; }
        public string? BookImage { get; set; }
        public int Book_Quantity { get; set; }
    }
}
