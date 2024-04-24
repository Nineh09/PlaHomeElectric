using BusinessObject;
using Repository.IRepository;
using Repository.Repositories;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implement
{
	public class ImageService : IImageService
	{
		private readonly IImageRepository _imageRepo;
		private readonly IProductRepository _productRepo;
		
		public Task Add(Image entity)
		{
			try
			{
				_imageRepo.Add(entity);
				_imageRepo.Save();
				return Task.CompletedTask;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public Task Delete(Image entity)
		{
			try
			{
				
				_imageRepo.Delete(entity);
				_imageRepo.Save();
				return Task.CompletedTask;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public Task<List<Image>> GetAll(params Expression<Func<Image, object>>[]? includeProperties)
		{
			try
			{
				var image = _imageRepo.GetAll();
				return Task.FromResult(image);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public Task<Image?> GetById(int id)
		{
			try
			{
				var image = _imageRepo.GetById(id);
				if(image != null)
				{
					image.Product = _productRepo.GetById((int)image.ProductId!);
				}
				return Task.FromResult(image);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public Task Update(Image entity)
		{
			throw new NotImplementedException();
		}
	}
}
