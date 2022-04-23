using Microsoft.EntityFrameworkCore;
using User.Sql.Context;

namespace User.Web.Api.Services
{
    public class UserService
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public UserService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<IEnumerable<Sql.Context.Models.User>> GetProducts() =>
            await _applicationDbContext.Users.ToListAsync();

        public async Task<Sql.Context.Models.User?> GetProduct(Guid id) =>
            await _applicationDbContext.Users.FirstOrDefaultAsync(x => x.Id == id);

    }
}
