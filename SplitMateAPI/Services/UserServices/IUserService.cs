using SplitMateAPI.Core;
using SplitMateAPI.DTOs;

namespace SplitMateAPI.Services.UserServices
{
	public interface IUserService
	{
		Task<Response<UserDto>> GetUserByIdAsync(Guid id, CancellationToken cancellationToken = default);
		Task<Response<IEnumerable<UserDto>>> GetAllUsersAsync(CancellationToken cancellationToken = default);
		Task<Response<UserDto>> CreateUserAsync(string displayName, string email, CancellationToken cancellationToken = default);
	}
}
