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
    public class OrderController : ControllerBase
    {
        // Declaring a field of IUnitOfWork in order to access all of its properties, methods and attributes
        private readonly IUnitOfWork _unitOfWork;

        // Declaring a field of Mapper in order to map the model with its particular view model
        private readonly IMapper _mapper;

        // Injecting the UnitOfWork and Mapper instance to the constructor of this controller
        public OrderController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #region API Calls

        /// <summary>
        /// Defining a Get method to retrieve all of the orders
        /// Use of the field to extract one of its repository, order
        /// Implementing the GetAll() function to retrieve all of its data in a listed form
        /// </summary>
        /// <returns>List of all posted orders with required properties for an non empty list</returns>
        /// <returns>All the returned items in the list will be mapped with the DTO created</returns>
        [HttpGet("GetAllOrders")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<Product>> GetAllOrders()
        {
            var products = _unitOfWork.Product.GetAll(includeProperties: "Category");

            products.Select(product => _mapper.Map<ProductViewDTO>(product));

            var staffs = _unitOfWork.Staff.GetAll();

            staffs.Select(staff => _mapper.Map<StaffDTO>(staff));

            var orders = _unitOfWork.Order.GetAll(includeProperties: "OrderLines");

            if (orders.Count() != 0)
            {
                return Ok(orders.Select(order => _mapper.Map<OrderViewDTO>(order)));
            }

            return BadRequest("No any orders have been placed yet.");
        }

        /// <summary>
        /// Defining an Add Order Post method to add a single order to the database
        /// Use of the field to extract one of its repository, order
        /// The param passed as the DTO is then mapped with its respective parent model class as for which to be added
        /// Implementing the Add() function by passing the object as its parameter and setting the created date time to now
        /// Addition of the object of order to its particular DbSet
        /// </summary>
        /// <param name="order">Defining an object of the order to be added to the db as a parameter</param>
        /// <returns>A success result when no any errors are found declaring a successful order</returns>
        [HttpPost("PostOrder")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Order> AddOrder(OrderPostDTO orderViewModel)
        {
            var order = _mapper.Map<Order>(orderViewModel);

            for (int i = 0; i < order.OrderLines.Count; i++)
            {
                var orderObject = _unitOfWork.Order.Transaction(order.OrderLines[i].ProductID, order.OrderLines[i].Quantity);
                
                if(orderObject == -1)
                {
                    return BadRequest("Failure while ordering items.");
                }

                order.OrderLines[i].LineTotal = orderObject;

                order.TotalAmount += orderObject;
            }

            order.OrderedDate = DateTime.Now;

            _unitOfWork.Order.Add(order);

            _unitOfWork.Save();

            return Ok("Order Successfully Registered.");
        }

        #endregion
    }
}
