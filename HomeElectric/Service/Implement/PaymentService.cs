using BusinessObject;
using Repository.IRepository;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implement
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;
        public PaymentService(IPaymentRepository paymentRepository, IOrderDetailRepository orderDetailRepository)
        {
            _paymentRepository = paymentRepository;
            _orderDetailRepository = orderDetailRepository;
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
                var listFeedback = _paymentRepository.GetById(id);
                if(listFeedback != null)
                {
                    listFeedback.OrderDetail = _orderDetailRepository.GetById((int)listFeedback.OrderDetailId!);
                }
                return Task.FromResult(listFeedback);
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
