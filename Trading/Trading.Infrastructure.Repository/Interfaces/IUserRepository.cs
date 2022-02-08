using System.Threading.Tasks;
using Trading.Infrastructure.Data.Model;

namespace Trading.Infrastructure.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<User> Register(User user);

        Task<User> Login(string email, string password);
    }
}
