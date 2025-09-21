using SplitMateAPI.Repositories.UserRepositories;

namespace SplitMateAPI.Repositories.UnitOfWorks
{
	public class RepositoryContainer
	{
		public IUserRepository UserRepository { get; }
		public RepositoryContainer(IUserRepository userRepository)
		{
			UserRepository = userRepository;
		}
	}
}
