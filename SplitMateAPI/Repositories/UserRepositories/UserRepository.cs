using SplitMateAPI.Data;
using SplitMateAPI.Entities;
using SplitMateAPI.Repositories.GenericRepositories;

namespace SplitMateAPI.Repositories.UserRepositories
{
	public class UserRepository : GenericRepository<User>, IUserRepository
	{
		public UserRepository(ApplicationDbContext context) : base(context)
		{
		}
	}
}
