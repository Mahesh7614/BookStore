
namespace BookStoreModel
{
    public class FeedbackModel
    {
        public int FeedbackID { get; set; }
        public int Rating { get; set; }
        public string? Comment { get; set; }
        public int BookID { get; set; }
        public int UserID { get; set; }
    }
}
