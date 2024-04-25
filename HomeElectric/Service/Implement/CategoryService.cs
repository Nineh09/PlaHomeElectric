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
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _cateRepo;
        private readonly IProductRepository _productRepo;

        public CategoryService(ICategoryRepository cateRepo, IProductRepository productRepo)
        {
            _cateRepo = cateRepo;
            _productRepo = productRepo;
        }

        public Task Add(Category entity)
        {
            try
            {
                //entity.IsDeleted = false;
                _cateRepo.Add(entity);
                _cateRepo.Save();
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task Delete(Category entity)
        {
            try
            {
                var cate = _cateRepo.GetById(entity.Id);
                if (cate == null)
                {
                    throw new Exception("CategoryID was not exist ");
                }
                else
                {
                    var checkProduct = _productRepo.GetAll().Where(x => x.CategoryId == entity.Id && x.IsDeleted == true).ToList();
                    if (checkProduct != null)
                    {
                        throw new Exception("This category is containt product!");
                    }
                    else
                    {
                        entity.IsDeleted = true;
                        _cateRepo.Update(entity);
                        _cateRepo.Save();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Task.CompletedTask;
        }

        public Task<List<Category>> GetAll(params Expression<Func<Category, object>>[]? includeProperties)
        {
            try
            {
                var result = _cateRepo.GetAll();
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<Category?> GetById(int id)
        {
            try
            {
                var resultGet = _cateRepo.GetById(id);
                if (resultGet == null)
                {
                    throw new Exception("This id of category does not exist!");
                }
                else
                {
                    return Task.FromResult(resultGet)!;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<Category> GetCateName(string name)
        {
            Category category = _cateRepo.GetCateName(name);
            return Task.FromResult(category);
        }

        public Task Update(Category entity)
        {
            try
            {
                _cateRepo.Update(entity);
                _cateRepo.Save();
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}