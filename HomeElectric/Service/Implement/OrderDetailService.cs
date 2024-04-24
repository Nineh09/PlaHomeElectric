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
	public class OrderDetailService : IOrderDetailService
	{
		private readonly IOrderDetailRepository _orderDetailRepository;
		private readonly IOrderRepository _orderRepository;
		private readonly IFeedbackRepository _feedbackRepository;
		private readonly IProductRepository _productRepository;

		public OrderDetailService(IOrderDetailRepository orderDetailRepository, IOrderRepository orderRepository, IFeedbackRepository feedbackRepository, IProductRepository productRepository)
		{
			_orderDetailRepository = orderDetailRepository;
			_orderRepository = orderRepository;
			_feedbackRepository = feedbackRepository;
			_productRepository = productRepository;
		}

		public Task Add(OrderDetail entity)
		{
			try
			{
				_orderDetailRepository.Add(entity);
				_orderDetailRepository.Save();
				return Task.CompletedTask;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public Task Delete(OrderDetail entity)
		{
			try
			{
				entity.IsDeleted = true;
				_orderDetailRepository.Save();
				return Task.CompletedTask;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public Task<List<OrderDetail>> GetAll(params Expression<Func<OrderDetail, object>>[]? includeProperties)
		{
			try
			{
				var listOrderDetail = _orderDetailRepository.GetAll(includeProperties);
				return Task.FromResult(listOrderDetail);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public Task<OrderDetail?> GetById(int id)
		{
			try
			{
				var listOrderDetail = _orderDetailRepository.GetById(id);
				if(listOrderDetail != null)
				{
					listOrderDetail.Product = _productRepository.GetById((int)listOrderDetail.ProductId!);
					listOrderDetail.Order = _orderRepository.GetById((int)listOrderDetail.OrderId!);
				}
				return Task.FromResult(listOrderDetail);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public Task Update(OrderDetail entity)
		{
			_orderDetailRepository.Update(entity);
			_orderDetailRepository.Save();
			return Task.CompletedTask;
		}
	}
}
