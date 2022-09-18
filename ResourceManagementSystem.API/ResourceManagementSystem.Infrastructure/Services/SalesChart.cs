using ResourceManagementSystem.Infrastructure.Data;
using ResourceManagementSystem.Domain.QueryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceManagementSystem.Infrastructure.Services
{
    public class SalesChart
    {
        // Assigning a field for the DbContext class to access its DbSets
        private readonly ApplicationDbContext _dbContext;

        //Contructor for SalesChart injecting the service of the DBContext
        public SalesChart(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Method to extract all the sales of product based on LINQ expressions
        public IQueryable<ProductSales> GetProductSales()
        {
            IQueryable<ProductSales> productCharts =
                (from order in _dbContext.OrderLines
                join product in _dbContext.Products on order.ProductID equals product.ID
                join category in _dbContext.Categories on product.CategoryID equals category.ID
                group order by new
                {
                    product.ID,
                    product.Name,
                    category.Title
                } into salesGroup
                select new ProductSales()
                {
                    Name = salesGroup.Key.Name,
                    Category = salesGroup.Key.Title,
                    Quantity = salesGroup.Sum(p => p.Quantity),
                    Sales = salesGroup.Sum(p => p.LineTotal)
                }).OrderByDescending(s => s.Sales);
            
            return productCharts;
        }

        // Method to extract all the sales accompanied by individual staff based on LINQ expressions
        public IQueryable<StaffSales> GetStaffSales()
        {
            IQueryable<StaffSales> staffCharts =
                (from order in _dbContext.Orders
                join staff in _dbContext.Staffs
                on order.StaffID equals staff.Id
                group order by new
                {
                    order.StaffID,
                    staff.Name
                } into salesGroup
                select new StaffSales()
                {
                    Name = salesGroup.Key.Name,
                    Sales = salesGroup.Sum(c => c.TotalAmount)
                }).OrderByDescending(s => s.Sales);

            return staffCharts;
        }
        
    }
}
