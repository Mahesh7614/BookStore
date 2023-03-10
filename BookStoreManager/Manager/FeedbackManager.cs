
using BookStoreManager.Interface;
using BookStoreModel;
using BookStoreRepository.Interface;

namespace BookStoreManager.Manager
{
    public class FeedbackManager : IFeedbackManager
    {
        private readonly IFeedbackRepository feedbackRepository;
        public FeedbackManager(IFeedbackRepository feedbackRepository)
        {
            this.feedbackRepository = feedbackRepository;
        }
        public FeedbackModel AddFeedback(FeedbackModel feedbackModel)
        {
            try
            {
                return this.feedbackRepository.AddFeedback(feedbackModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<FeedbackModel> GetAllFeedback(int BookID)
        {
            try
            {
                return this.feedbackRepository.GetAllFeedback(BookID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
