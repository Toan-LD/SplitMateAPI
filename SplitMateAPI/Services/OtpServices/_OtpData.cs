namespace SplitMateAPI.Services.OtpServices
{
	public class _OtpData
	{
		public string Code { get; set; } = string.Empty;
		public string Email { get; set; } = string.Empty;
		public DateTime CreatedAt { get; set; }
		public DateTime ExpiresAt { get; set; }
        public int Attempts { get; set; }
        public bool IsUsed { get; set; }
        public DateTime? VerifiedAt { get; set; }
    }
}
