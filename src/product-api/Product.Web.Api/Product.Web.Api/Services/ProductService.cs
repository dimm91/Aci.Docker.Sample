using Microsoft.EntityFrameworkCore;
using Product.Sql.Context;

namespace Product.Web.Api.Services
{
    public class ProductService
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public ProductService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<IEnumerable<Sql.Context.Models.Product>> GetProducts() =>
            await _applicationDbContext.Products.ToListAsync();

        public async Task<Sql.Context.Models.Product?> GetProduct(Guid id) =>
            await _applicationDbContext.Products.FirstOrDefaultAsync(x => x.Id == id);
    }
}
