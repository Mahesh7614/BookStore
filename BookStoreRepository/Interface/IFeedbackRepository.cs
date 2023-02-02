
using BookStoreModel;

namespace BookStoreRepository.Interface
{
    public interface IFeedbackRepository
    {
        public FeedbackModel AddFeedback(FeedbackModel feedbackModel);
        public List<FeedbackModel> GetAllFeedback(int BookID);
    }
}
