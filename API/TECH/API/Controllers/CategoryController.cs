using API.Models;
using Dto;
using Dto.Models;
using Dto.Search;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Service;

namespace API.Controllers
{
    [Route("/Category")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var data = _categoryService.GetAll();
            return Ok(new ApiResponse
            {
                Success = true,
                Data = data
            });
        }
        [HttpGet("GetDataPaging1")]
        public IActionResult GetDataPaging1(int PageIndex, int PageSize)
        {
          //  var data = _categoryService.GetPaging(search);
            return Ok(new ApiResponse
            {
                Success = true,
               // Data = data
            });
        }

        [HttpGet("GetDataPaging")]
        public IActionResult GetDataPaging([FromHeader]CategoryModelSearch search)
        {
            var data = _categoryService.GetPaging(search);            
            return Ok(new ApiResponse
            {
                Success = true,
                Data = data
            });
        }

        [HttpPost]
        [Route("/Add")]
        public IActionResult Add(CategoryModel model)
        {
            _categoryService.Add(model);
            return Ok(new ApiResponse
            {
                Success = true,
                Message = "success",
            });
        }
        [HttpPut]
        [Route("/Update")]
        public IActionResult Update(CategoryModel model)
        {
            var status = _categoryService.Update(model);
            return Ok(new ApiResponse
            {
                Success = status,
            });
        }
        [HttpDelete]
        [Route("/Delete")]
        public IActionResult Delete(CategoryModel model)
        {
            var status = _categoryService.Update(model);
            return Ok(new ApiResponse
            {
                Success = status,
            });
        }

    }
}
