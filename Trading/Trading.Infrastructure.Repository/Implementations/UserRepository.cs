using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Trading.Infrastructure.Data.Model;
using Trading.Infrastructure.Persistent;
using Trading.Infrastructure.Repository.Interfaces;

namespace Trading.Infrastructure.Repository.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly TradingDbContext Context;

        public UserRepository(TradingDbContext context)
        {
            Context = context;
        }

        public async Task<User> Register(User user)
        {
            var newUser = await Context.User.AddAsync(user);

            await Context.SaveChangesAsync();

            return newUser.Entity;
        }

        public async Task<User> Login(string email, string password)
        {
            return await Context.User.FirstOrDefaultAsync(user => user.Email == email && user.Password == password);
        }
    }
}
