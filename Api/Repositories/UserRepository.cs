using Api.Models.Entities;
using Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories
{
    public class UserRepository : IUserRepository
    {
        private Context _context;

        public UserRepository(Context context)
        {
            _context = context;
        }

        public async Task<User> GetUserAsync(string login)
        {
           var user = await _context.Users
                .Where(x=> x.Login == login)
                .FirstOrDefaultAsync();
            return user;
        }
    }
}
