using SplitMateAPI.Core;
using SplitMateAPI.Data;
using SplitMateAPI.DTOs;
using SplitMateAPI.Entities;
using SplitMateAPI.Repositories.UnitOfWorks;
using SplitMateAPI.Selectors;

namespace SplitMateAPI.Services.UserServices
{
	public class UserService : IUserService
	{
		private readonly IUnitOfWork _unitOfWork;
		public UserService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<Response<UserDto>> CreateUserAsync(string displayName,  string email, CancellationToken cancellationToken = default)
		{
			var existingUser = await _unitOfWork.Users.GetAllAsync(cancellationToken);

			if (existingUser.Any())
			{
				return new Response<UserDto>(
					status: false,
					message: "Email already exists",
					data: null,
					statusCode: 409);
			}

			var user = new User
			{
				Id = Guid.NewGuid(),
				DisplayName = displayName.Trim(),
				Email = email.Trim().ToLower()
			};

			await _unitOfWork.Users.AddAsync(user, cancellationToken);
			await _unitOfWork.SaveChangesAsync(cancellationToken);

			var userDto = new UserDto(user.Id, user.DisplayName, user.Email);

			return new Response<UserDto>(
				status: true,
				message: "User created successfully",
				data: userDto,
				statusCode: 201);
		}

		public async Task<Response<IEnumerable<UserDto>>> GetAllUsersAsync(CancellationToken cancellationToken = default)
		{
			var userDtos = await _unitOfWork.Users.GetAllAsync(selector: UserDtoSelector.ToDto, cancellationToken: cancellationToken);

			return new Response<IEnumerable<UserDto>>(
				status: true,
				message: userDtos.Any() ? "Users retrieved successfully" : "No users found",
				data: userDtos,
				statusCode: 200);
		}

		public async Task<Response<UserDto>> GetUserByIdAsync(Guid id, CancellationToken cancellationToken = default)
		{
			var userDto = await _unitOfWork.Users.GetByIdAsync(id: id, selector: UserDtoSelector.ToDto, cancellationToken: cancellationToken);

			if (userDto == null)
			{
				return new Response<UserDto>(
					status: false,
					message: "User not found",
					data: null,
					statusCode: 404);
			}

			return new Response<UserDto>(
				status: true,
				message: "User retrieved successfully",
				data: userDto,
				statusCode: 200);
		}
	}
}
