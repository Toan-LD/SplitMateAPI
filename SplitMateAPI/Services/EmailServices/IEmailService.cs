namespace SplitMateAPI.Services.EmailServices
{
	public interface IEmailService
	{
		Task<bool> SendMailAsync(string to, string subject, string htmlBody, string? textBody = null);
	}
}
