using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskApp.Services.Models
{
	public class ExchangeRateResponse
	{
		public class Currency
		{
			public string Iso3 { get; set; }
			public string Name { get; set; }
			public int Unit { get; set; }
		}

		public class Rate
		{
			public Currency Currency { get; set; }
			public string Buy { get; set; }
			public string Sell { get; set; }
		}

		public class Payload
		{
			public string Date { get; set; }
			public string PublishedOn { get; set; }
			public string ModifiedOn { get; set; }
			public List<Rate> Rates { get; set; }
		}

		public class Data
		{
			public List<Payload> Payload { get; set; }
		}

		public class ApiResponse
		{
			public Data Data { get; set; }
		}

	}
}
