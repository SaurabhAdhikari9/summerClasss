using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResourceManagementSystem.Application.DTOs;
using ResourceManagementSystem.Application.Interfaces;
using ResourceManagementSystem.Domain.Models;

namespace ResourceManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        // Declaring a field of IUnitOfWork in order to access all of its properties, methods and attributes
        private readonly IUnitOfWork _unitOfWork;

        // Declaring a field of Mapper in order to map the model with its particular view model
        private readonly IMapper _mapper;

        // Injecting the UnitOfWork and Mapper instance to the constructor of this controller
        public CategoryController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #region API Calls

        /// <summary>
        /// Defining a Get method to retrieve all of the categories
        /// Use of the field to extract one of its repository, category
        /// Implementing the GetAll() function to retrieve all of its data in a listed form
        /// </summary>
        /// <returns>List of all available categories with required properties for an non empty list</returns>
        /// <returns>All the returned items in the list will be mapped with the DTO created</returns>
        [HttpGet("GetAllCategories")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<Category>> GetAllCategories()
        {
            var categories = _unitOfWork.Category.GetAll();

            if (categories.Count() == 0)
            {
                return BadRequest("No any categories have been added yet.");
            }

            return Ok(categories.Select(category => _mapper.Map<CategoryDTO>(category)));
        }

        /// <summary>
        /// Defining a Get By ID method to retrieve a single category
        /// Use of the field to extract one of its repository, category
        /// Implementing the Get() function and extracting by matching the paramater with all the sets of categories
        /// Once an object of the category is obtained, it is then extracted on the required properties once mapped to its DTO
        /// <param name="ID">Defined to inspect it with all the ID defined for all of the categories set up</param>
        /// <returns>An object of the matching category for its required class</returns>
        [HttpGet("{ID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Category> GetCategoryByID(string ID)
        {
            var category = _unitOfWork.Category.Get(ID);

            var categoryDTO = _mapper.Map<CategoryDTO>(category);

            if (categoryDTO == null)
            {
                return BadRequest("Category not found.");
            }

            return Ok(categoryDTO);
        }

        /// <summary>
        /// Defining an Add Category Post method to add a single category to the database
        /// Use of the field to extract one of its repository, category
        /// The param passed as the DTO is then mapped with its respective parent model class as for which to be added
        /// Implementing the Add() function by passing the object as its parameter and setting the created date time to now
        /// Addition of the object of category to its particular DbSet
        /// </summary>
        /// <param name="category">Defining an object of the category to be added to the db as a parameter</param>
        /// <returns>A success result when no any errors are found declaring a successful addition</returns>
        [HttpPost("AddCategory")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Category> AddCategory(CategoryDTO categoryViewModel)
        {
            var category = _mapper.Map<Category>(categoryViewModel);

            category.CreatedAt = DateTime.Now;

            _unitOfWork.Category.Add(category);

            _unitOfWork.Save();

            return Ok("Category successfully added.");
        }

        /// <summary>
        /// Defining an Update Category Put method to update an existing category from the database
        /// Use of the field to extract one of its repository, category
        /// The param passed as the DTO is then mapped with its respective parent model class as for which to be updated
        /// Implementing the Update() function by passing the manually written object as its parameter 
        /// Update of the object of category to its particular DbSet
        /// </summary>
        /// <param name="category">Defining an object of the category to be updated to the db as a parameter</param>
        /// <returns>A success result when no any errors are found declaring a successful modification</returns>
        [HttpPut("UpdateCategory")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Category> UpdateCategory(CategoryDTO categoryViewModel)
        {
            var category = _mapper.Map<Category>(categoryViewModel);

            var categoryObject = _unitOfWork.Category.Update(category);

            if (categoryObject == -1)
            {
                return BadRequest("Category not found.");
            }

            _unitOfWork.Save();

            return Ok("Category successfully updated.");
        }

        /// <summary>
        /// Defining an Delete Category method to delete an existing category from the database
        /// Use of the field to extract one of its repository, category
        /// Implementing the Delete() function by passing the ID of the category to be deleted
        /// Removal of the object of category from its particular DbSet
        /// </summary>
        /// <param name="ID">Defining the ID of the category which is to be removed</param>
        /// <returns>A success result when no any errors are found declaring a successful removal</returns>
        [HttpDelete("{ID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Category> DeleteCategory(string ID)
        {
            var categoryObject = _unitOfWork.Category.Delete(ID);

            if (categoryObject == -1)
            {
                return BadRequest("Category not found.");
            }

            _unitOfWork.Save();

            return Ok("Category successfully deleted.");
        }

        #endregion


    }
}
