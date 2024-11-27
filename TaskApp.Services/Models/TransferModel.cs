using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskApp.Services.Models
{
	public class TransferModel
	{
		public string UserEmail { get; set; }
		public string Firstname { get; set; }
		public string? Middlename { get; set; } 
		public string Lastname { get; set; }
		public string Address { get; set; }
		public string Country { get; set; }
		public string BankName { get; set; }
		public string AccountNumber { get; set; }
		public decimal TransferAmount { get; set; }
		public string TransferIso3 { get; set; }
		public decimal ExchangeRate { get; set; }
		public decimal PayoutAmount { get; set; }
		public string PayoutIso3 { get; set; }
	}
}
