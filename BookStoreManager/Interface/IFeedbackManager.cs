
using BookStoreModel;

namespace BookStoreManager.Interface
{
    public interface IFeedbackManager
    {
        public FeedbackModel AddFeedback(FeedbackModel feedbackModel);
        public List<FeedbackModel> GetAllFeedback(int BookID);
    }
}
