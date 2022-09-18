using Microsoft.AspNetCore.Mvc;
using ResourceManagementSystem.Infrastructure.Services;

namespace ResourceManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChartController : ControllerBase
    {
        // Declaring a field of Sales Chart in order to access all of its methods and attributes
        private readonly SalesChart _salesChart;

        // Injecting the UnitOfWork instance to the constructor of this controller
        public ChartController(SalesChart salesChart)
        {
            _salesChart = salesChart;
        }

        #region API Calls

        /// <summary>
        /// Defining a Get method to retrieve all of the staffs involved in total transaction
        /// Implementing the GetStaffSales() function to retrieve all of its data in a queryable listed form
        /// </summary>
        /// <returns>List of all sales completed by individual staffs in Json format</returns>
        [HttpGet("GetAllStaffSales")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public JsonResult StaffSalesChart()
        {
            var chart = _salesChart.GetStaffSales();

            return new JsonResult(chart);
        }

        /// <summary>
        /// Defining a Get method to retrieve all of the products sales involved in all transaction
        /// Implementing the GetProductSales() function to retrieve all of its data in a queryable listed form
        /// </summary>
        /// <returns>List of all sales for individual products in Json format</returns>
        [HttpGet("GetAllProductSales")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public JsonResult ProductSalesChart()
        {
            var chart = _salesChart.GetProductSales();

            return new JsonResult(chart);
        }

        #endregion
    }
}
