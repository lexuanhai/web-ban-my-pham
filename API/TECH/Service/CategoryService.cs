using Dto;
using Dto.Models;
using Dto.Search;
//using Dto.Search;
using Reponsitory;

namespace Service
{
    public interface ICategoryService
    {
        List<CategoryModel> GetAll();
        void Add(CategoryModel model);
        bool Update(CategoryModel model);
        List<CategoryModel> GetPaging(CategoryModelSearch search);
    }
    public class CategoryService: ICategoryService
    {

        private readonly ICategoryReponsitory _categoryRepository;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="repository"></param>
        public CategoryService(
            ICategoryReponsitory categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        /// <summary>
        /// Get All Category
        /// <returns>List All CategoryModel from DB</returns>
        public List<CategoryModel> GetAll()
        {
            //var data  = _categoryRepository.GetAll();            
            var categories = _categoryRepository.GetAll().Select(c => new CategoryModel()
            {
                Id = c.Id,
                Name = c.Name,
                ParentId = c.ParentId,
            }).ToList();

            return categories;
        }
        public void Add(CategoryModel model)
        {
            //if (model != null)
            //{
            //   _categoryRepository.Add(model);
            //}
        }
        public bool Update(CategoryModel model)
        {
            //if (model != null && model.Id > 0)
            //{
            //    var status = _categoryRepository.Update(model);
            //    return status;
            //}
            return false;
        }
        public List<CategoryModel> GetPaging(CategoryModelSearch search)
        {
            var data = _categoryRepository.GetDataPaging(search).Select(c => new CategoryModel()
            {
                Id = c.Id,
                Name = c.Name,
                ParentId = c.ParentId,
            }).ToList();
            return data;
        }
        public bool Delete(int id)
        {
            if (id > 0)
            {
                var status = _categoryRepository.Delete(id);
                return status;
            }
            return false;
        }
    }
}