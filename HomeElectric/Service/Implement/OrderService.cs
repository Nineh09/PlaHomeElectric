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
	public class OrderService : IOrderService
	{
		private readonly IOrderRepository _repositoryOrder;
		private readonly IProductRepository _productRepository;
		private readonly IUserRepository _userRepository;

		public OrderService(IOrderRepository repositoryOrder, IProductRepository productRepository, IUserRepository userRepository)
		{
			_repositoryOrder = repositoryOrder;
			_productRepository = productRepository;
			_userRepository = userRepository;
		}

		public Task Add(Order entity)
		{
			try
			{
				
				_repositoryOrder.Add(entity);
				_repositoryOrder.Save();
				return Task.CompletedTask;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public Task Delete(Order entity)
		{
			try
			{
				entity.IsDeleted = true;
				_repositoryOrder.Save();
				return Task.CompletedTask;
			}
			catch (Exception ex)
			{
				throw new NotImplementedException();
			}
		}

		public Task<List<Order>> GetAll(params Expression<Func<Order, object>>[]? includeProperties)
		{
			try
			{
				var listOrder = _repositoryOrder.GetAll(includeProperties);
				return Task.FromResult(listOrder);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public Task<Order?> GetById(int id)
		{
			try
			{
				var listOrder = _repositoryOrder.GetById(id);
				if(listOrder != null)
				{
					listOrder.User = _userRepository.GetById((int)listOrder.UserId!);
					
				}
				return Task.FromResult(listOrder);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public Task Update(Order entity)
		{
			try
			{
				_repositoryOrder.Update(entity);
				_repositoryOrder.Save();
				return Task.CompletedTask;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
	}
}
