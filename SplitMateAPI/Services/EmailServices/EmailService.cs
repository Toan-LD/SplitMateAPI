
using Resend;

namespace SplitMateAPI.Services.EmailServices
{
	public class EmailService : IEmailService
	{

		private readonly ILogger<EmailService> _logger;
		private readonly string _fromEmail;
		private readonly IResend _resend;
		public EmailService(ILogger<EmailService> logger, IConfiguration configuration)
		{
			_fromEmail = configuration["Resend:FromMail"] ?? "";
			_logger = logger;
			_resend = ResendClient.Create(configuration["Resend:ApiKey"]);

        }

		public async Task<bool> SendMailAsync(string to, string subject, string htmlBody, string? textBody = null)
		{
			var message = new EmailMessage();
			message.From = _fromEmail;
			message.To.Add(to);
			message.Subject = subject;
			message.HtmlBody = htmlBody;

			if (!string.IsNullOrEmpty(textBody))
			{
				message.TextBody = textBody;
			}

			var response = await _resend.EmailSendAsync(message);

			if (response.Success)
			{
				_logger.LogInformation("Email sent successfully.");
				return true;
			} 
			else
			{
				_logger.LogError("Failed to send email: {Error}", response.Exception);
				return false;
			}
		}
	}
}
