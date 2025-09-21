using Microsoft.AspNetCore.Mvc;
using SplitMateAPI.Core;
using SplitMateAPI.Services.EmailServices;

namespace SplitMateAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly ILogger<AuthController> _logger;
		private readonly IEmailService _emailService;
		public AuthController(IEmailService emailService)
		{
			_emailService = emailService;
		}

        [HttpPost("register")]
        public async Task<Response<string>> Register(string email, string password)
		{
			var htmlBody = "<h1>Welcome to SplitMate!</h1><p>Thank you for registering.</p>";
			var result = await _emailService.SendMailAsync(email, "Đăng ký tài khoản", htmlBody);
			if (result)
			{
				return new Response<string>(true, "Email sent successfully", null, 200);
			}
			else
			{
				return new Response<string>(false, "Failed to send email", null, 500);
			}
		} 
    }
}
