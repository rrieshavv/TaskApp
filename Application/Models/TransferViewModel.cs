using System.ComponentModel.DataAnnotations;

namespace Application.Models
{
	public class TransferViewModel
	{
		public SenderInfo? senderInfo { get; set; }
		public ReceiverInfo receiverInfo { get; set; }
		public PaymentDetail paymentDetail { get; set; }
	}

	public class SenderInfo
	{
	
		public string? Firstname { get; set; }
	
		public string? Middlename { get; set; }

		public string? Lastname { get; set; }
	
		public string? Address { get; set; }

		public string? Country { get; set; }
	}

	public class ReceiverInfo
	{
		[Required]
		public string Firstname { get; set; }
	
		public string? Middlename { get; set; }

		[Required]
		public string Lastname { get; set; }

		[Required]
		public string Address { get; set; }

		[Required]
		public string Country { get; set; }
	}

	public class PaymentDetail
	{
		[Required]
		[Display(Name = "Bank Name")]
		public string BankName { get; set; }

		[Required]
		[Display(Name ="Account Number")]
		public string AccountNumber { get; set; }

		[Required]
		[Display(Name ="Transfer Amount (MYR)")]
		public string TransferAmount { get; set; }

		[Display(Name = "Exchange Rate (Selling)")]
		public string? ExchangeRate { get; set; }

		[Display(Name ="Payout Amount (NPR)")]
		public string? PaymentAmount { get; set; }
	}
}
