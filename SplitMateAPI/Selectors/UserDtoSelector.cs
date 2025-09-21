using SplitMateAPI.DTOs;
using SplitMateAPI.Entities;
using System.Linq.Expressions;

namespace SplitMateAPI.Selectors
{

	public sealed record UserDtoSelector
	{
		public static Expression<Func<User, UserDto>> ToDto =>
			user => new UserDto(
				user.Id,
				user.DisplayName,
				user.Email);
	}
}
