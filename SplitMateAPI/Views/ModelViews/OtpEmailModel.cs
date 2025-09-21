namespace SplitMateAPI.Views.ModelViews
{
	public class OtpEmailModel
	{
		public string Email { get; set; } = string.Empty;
        public string OtpCode { get; set; } = string.Empty;
        public int ExpiryMinutes { get; set; }
		public DateTime GeneratedAt { get; set; } = DateTime.Now;
        public DateTime ExpiryTime => GeneratedAt.AddMinutes(ExpiryMinutes);
		public int RemainingSeconds 
		{
			get
			{
				var remaining = (ExpiryTime - DateTime.Now);
				return remaining.TotalSeconds < 0 ? 0 : (int)remaining.TotalSeconds;
            }
		}
	}
}
