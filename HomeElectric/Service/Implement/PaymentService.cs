using BusinessObject;
using Repository.IRepository;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implement
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentService(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public Task Add(Payment entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Payment entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<Payment>> GetAll(params Expression<Func<Payment, object>>[]? includeProperties)
        {
            try
            {
                return Task.FromResult(_paymentRepository.GetAll());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<Payment?> GetById(int id)
        {
            try
            {
                return Task.FromResult(_paymentRepository.GetById(id));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task Update(Payment entity)
        {
            throw new NotImplementedException();
        }
    }
}
