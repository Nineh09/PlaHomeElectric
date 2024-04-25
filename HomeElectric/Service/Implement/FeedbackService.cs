using BusinessObject;
using Repository.IRepository;
using Service.Interface;
using System.Linq.Expressions;

namespace Service.Implement
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IFeedbackRepository _feedbackRepository;
        public FeedbackService(IFeedbackRepository feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;
        }
        public Task Add(Product product, Feedback entity)
        {
            try
            {
                product.IsDeleted = false;
                _feedbackRepository.Add(entity);
                _feedbackRepository.Save();
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task Add(Feedback entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Feedback entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<Feedback>> GetAll(params Expression<Func<Feedback, object>>[]? includeProperties)
        {
            throw new NotImplementedException();
        }

        public Task<Feedback?> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Feedback entity)
        {
            throw new NotImplementedException();
        }
    }
}
