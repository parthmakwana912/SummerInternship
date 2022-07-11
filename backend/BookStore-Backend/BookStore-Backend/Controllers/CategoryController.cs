using BookStore.Models.ViewModels;
using BookStore.Repository;
using BookStre.Models.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BackEnd_1.Controllers
{
    [ApiController]
    [Route("api/category")]
    public class CategoryController : ControllerBase
    {
        CategoryRepository _categoryRepository = new CategoryRepository();

        [HttpGet]
        [Route("List")]
        public IActionResult GetCatogires(string keyword, int pageIndex = 1, int pageSize = 10)
        {
            var categories = _categoryRepository.GetCategories(pageIndex, pageSize, keyword);
            ListResponse<CetegoryModel> listResponse = new ListResponse<CetegoryModel>()
            {
                Results = categories.Results.Select(c => new CetegoryModel(c)),
                TotalRecords = categories.TotalRecords,
            };

            return Ok(listResponse);
        }

        [Route("{id}")]
        [HttpGet]
        [ProducesResponseType(typeof(CetegoryModel), (int)HttpStatusCode.OK)]
        public IActionResult GetCategory(int id)
        {
            var category = _categoryRepository.GetCategory(id);
            

           
            if (category != null)
            {
                CetegoryModel categoryModel = new CetegoryModel(category);
                return Ok(categoryModel);
            }
            else
            {
                return Ok("Entered cetgroy's Id  is not found");
            }

        }

        [Route("add")]
        [HttpPost]
        [ProducesResponseType(typeof(CetegoryModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BadRequestObjectResult), (int)HttpStatusCode.BadRequest)]
        public IActionResult AddCategory(CetegoryModel model)
        {
            if (model == null)
                return BadRequest("Model is null");

            Category category = new Category()
            {
                Id = (int)model.Id,
                Name = model.Name
            };
            var response = _categoryRepository.AddCategory(category);
            CetegoryModel categoryModel = new CetegoryModel(response);

            return Ok(categoryModel);
        }

        [Route("update")]
        [HttpPut]
        [ProducesResponseType(typeof(CetegoryModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BadRequestObjectResult), (int)HttpStatusCode.BadRequest)]
        public IActionResult UpdateCategory(CetegoryModel model)
        {
            if (model == null)
                return BadRequest("Model is null");

            Category category = new Category()
            {
                Id = (int)model.Id,
                Name = model.Name
            };
            var response = _categoryRepository.UpdateCategory(category);
            CetegoryModel categoryModel = new CetegoryModel(response);

            return Ok(categoryModel);
        }

        [Route("delete/{id}")]
        [HttpDelete]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BadRequestObjectResult), (int)HttpStatusCode.BadRequest)]
        public IActionResult DeleteCategory(int id)
        {
            if (id == 0)
                return BadRequest("id is null");

            var response = _categoryRepository.DeleteCategory(id);
            return Ok(response);
        }
    }
}
