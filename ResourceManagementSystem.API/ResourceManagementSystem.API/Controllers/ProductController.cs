using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResourceManagementSystem.Application.DTOs;
using ResourceManagementSystem.Application.Interfaces;
using ResourceManagementSystem.Domain.Models;

namespace ResourceManagementSystem.API.Controllers
{
    [Route("/api/controller")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        // Declaring a field of IUnitOfWork in order to access all of its properties, methods and attributes
        private readonly IUnitOfWork _unitOfWork;

        // Declaring a field of Mapper in order to map the model with its particular view model
        private readonly IMapper _mapper;

        // Injecting the UnitOfWork and Mapper instance to the constructor of this controller
        public ProductController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #region API Calls

        /// <summary>
        /// Defining a Get method to retrieve all of the products
        /// Use of the field to extract one of its repository, product
        /// Implementing the GetAll() function to retrieve all of its data in a listed form
        /// </summary>
        /// <returns>List of all available products with required properties for an non empty list</returns>
        /// <returns>All the returned items in the list will be mapped with the DTO created</returns>
        [HttpGet("GetAllProducts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<Product>> GetAllProducts()
        {
            var products = _unitOfWork.Product.GetAll(includeProperties: "Category");

            if (products.Count() != 0)
            {
                return Ok(products.Select(product => _mapper.Map<ProductViewDTO>(product)));
            }

            return BadRequest("No any products added to the list yet.");
        }

        /// <summary>
        /// Defining a Get By ID method to retrieve a single product
        /// Use of the field to extract one of its repository, product
        /// Implementing the Get() function and extracting by matching the paramater with all the sets of product
        /// Once an object of the product is obtained, it is then extracted on the required properties once mapped to its DTO
        /// <param name="ID">Defined to inspect it with all the ID defined for all of the products set up</param>
        /// <returns>An object of the matching product for its required class</returns>
        [HttpGet("{ID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Product> GetProductByID(string ID)
        {
            var product = _unitOfWork.Product.Get(ID);

            var productDTO = _mapper.Map<ProductUpsertDTO>(product);

            if (productDTO != null)
            {
                return Ok(productDTO);
            }

            return BadRequest("Product not found.");
        }

        /// <summary>
        /// Defining an Add Product Post method to add a single product to the database
        /// Use of the field to extract one of its repository, product
        /// The param passed as the DTO is then mapped with its respective parent model class as for which to be added
        /// Implementing the Add() function by passing the object as its parameter and setting the created date time to now
        /// Addition of the object of product to its particular DbSet
        /// </summary>
        /// <param name="product">Defining an object of the product to be added to the db as a parameter</param>
        /// <returns>A success result when no any errors are found declaring a successful addition</returns>
        [HttpPost("AddProduct")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Product> AddProduct(ProductUpsertDTO productViewModel)
        {
            var product = _mapper.Map<Product>(productViewModel);

            product.CreatedAt = DateTime.Now;

            _unitOfWork.Product.Add(product);
            
            _unitOfWork.Save();

            return Ok("Product Successfully Added.");
        }

        /// <summary>
        /// Defining an Update Product Put method to update an existing product from the database
        /// Use of the field to extract one of its repository, product
        /// The param passed as the DTO is then mapped with its respective parent model class as for which to be updated
        /// Implementing the Update() function by passing the manually written object as its parameter 
        /// Update of the object of product to its particular DbSet
        /// </summary>
        /// <param name="product">Defining an object of the product to be updated to the db as a parameter</param>
        /// <returns>A success result when no any errors are found declaring a successful modification</returns>
        [HttpPut("UpdateProduct")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Product> UpdateProduct(ProductUpsertDTO productViewModel)
        {
            var product = _mapper.Map<Product>(productViewModel);

            var productObject = _unitOfWork.Product.Update(product);

            if(productObject == -1)
            {
                return BadRequest("Product not found.");
            }

            _unitOfWork.Save();

            return Ok("Product Successfully Updated.");
        }

        /// <summary>
        /// Defining an Delete Product method to delete an existing product from the database
        /// Use of the field to extract one of its repository, product
        /// Implementing the Delete() function by passing the ID of the product to be deleted
        /// Removal of the object of product from its particular DbSet
        /// </summary>
        /// <param name="ID">Defining the ID of the product which is to be removed</param>
        /// <returns>A success result when no any errors are found declaring a successful removal</returns>
        [HttpDelete("{ID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Product> DeleteProduct(string ID)
        {
            var productObject = _unitOfWork.Product.Delete(ID);

            if(productObject == -1)
            {
                return BadRequest("Product not found.");
            }

            _unitOfWork.Save();

            return Ok("Product successfully deleted.");
        }

        #endregion


    }
}