namespace WPAssign.Controllers
{
	public class TicketAddRequestModel
	{
		public string To { get; set; }
		public string From { get; set; }
		public string Token { get; set; }
		public string Amount { get; set; }
	}
}