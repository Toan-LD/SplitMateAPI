namespace SplitMateAPI.Core
{
	public class Response<T> where T : class
	{
		public Response() { }

		public Response(bool status, string? message = null, T? data = null, int? statusCode = null)
		{
			Status = status;
			Message = message;
			Data = data;
			StatusCode = statusCode;
		}

		public bool Status { get; set; }
		public string? Message { get; set; }
		public T? Data { get; set; }
		public int? StatusCode { get; set; }
	}
}
