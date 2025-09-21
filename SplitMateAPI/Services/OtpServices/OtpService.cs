using SplitMateAPI.Services.EmailServices;
using System.Collections.Concurrent;

namespace SplitMateAPI.Services.OtpServices
{
	public class OtpService : IOtpService
	{
		private readonly ILogger<OtpService> _logger;
		private readonly IConfiguration _configuration;
		private readonly IEmailService _emailService;
        private readonly ConcurrentDictionary<string, _OtpData> _otpStore = new();

        private readonly int _otpLength;
        private readonly int _otpExpiryMinutes;
        private readonly int _maxRetries;
        private readonly int _resendCooldownMinutes;

        public OtpService(ILogger<OtpService> logger, IConfiguration configuration, IEmailService emailService)
		{
            _logger = logger;
            _emailService = emailService;
            _configuration = configuration;

            _otpLength = configuration.GetValue<int>("Otp:Length", 6);
            _otpExpiryMinutes = configuration.GetValue<int>("Otp:ExpiryMinutes", 5);
            _maxRetries = configuration.GetValue<int>("Otp:MaxRetries", 3);
            _resendCooldownMinutes = configuration.GetValue<int>("Otp:ResendCooldownMinutes", 1);
        }
        public Task<string> GenerateOtpAsync(string email)
		{
            throw new NotImplementedException();
        }
	}
}
