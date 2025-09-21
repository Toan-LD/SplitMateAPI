namespace SplitMateAPI.Services.OtpServices
{
	public interface IOtpService
	{
		Task<string> GenerateOtpAsync(string email);
	} 
}
