using BusinessObject;
using Repository.IRepository;
using Service.Interface;
using System.Linq.Expressions;
using System.Transactions;

namespace Service.Implement
{
    public class ProductService : IProductService
    {
        private  readonly IProductRepository _productRepo;
        private readonly ICategoryRepository _categoryRepo;
        public ProductService(IProductRepository productRepo, ICategoryRepository categoryRepository)
        {
            _productRepo = productRepo;
            _categoryRepo = categoryRepository;
        }

        public Task Add(Product entity)
        {
            try
            {
                entity.IsDeleted = false;
                _productRepo.Add(entity);
                _productRepo.Save();
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public Task Delete(Product entity)
        {
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                try
                {

                    var productInfor = _productRepo.GetById(entity.Id);
                    if (productInfor != null)
                    {
                        productInfor.IsDeleted= true;
                        _productRepo.Update(productInfor);
                        _productRepo.Save();
                        scope.Complete();
                    }

                }
                catch (Exception ex)
                {
                    scope.Dispose();
                    throw new Exception(ex.Message);
                }
            }
            return Task.CompletedTask;
        }

        public Task<List<Product>> GetAll(params Expression<Func<Product, object>>[]? includeProperties)
        {
            try
            {
                var getAllProduct = _productRepo.GetAll();
                return Task.FromResult(getAllProduct);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<Product?> GetById(int id)
        {
            try
            {
                var getProductById = _productRepo.GetById(id);
                if(getProductById != null)
                {
                    getProductById.Category = _categoryRepo.GetById((int)getProductById.CategoryId!);
                }
                return Task.FromResult(getProductById);
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task Update(Product entity)
        {
            try
            {
                _productRepo.Update(entity);
                _productRepo.Save();
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
