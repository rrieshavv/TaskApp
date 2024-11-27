using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TaskApp.Services.Models;
using static TaskApp.Services.Models.ExchangeRateResponse;

namespace TaskApp.Services.Services.ExchangeRate
{
	public class ExchangeRateService : IExchangeRateService
	{	
		private readonly HttpClient _httpClient;

        public ExchangeRateService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ExchangeRateResponse.Rate>> GetExchangeRatesAsync(string fromDate, string toDate)
		{
			string url = $"https://www.nrb.org.np/api/forex/v1/rates?page=1&per_page=5&from={fromDate}&to={toDate}";

			HttpResponseMessage response = await _httpClient.GetAsync(url);

			if (response.IsSuccessStatusCode)
			{
				string jsonResponse = await response.Content.ReadAsStringAsync();

				var apiResponse = JsonSerializer.Deserialize<ApiResponse>(jsonResponse, new JsonSerializerOptions
				{
					PropertyNameCaseInsensitive = true
				});

				return apiResponse?.Data?.Payload.FirstOrDefault()?.Rates ?? new List<ExchangeRateResponse.Rate>();
			}

			return new List<ExchangeRateResponse.Rate>();
		}

		public async Task<ExchangeRateResponse.Rate> GetExchangeRateByIso3(string fromDate , string toDate, string Iso3)
		{
			string url = $"https://www.nrb.org.np/api/forex/v1/rates?page=1&per_page=5&from={fromDate}&to={toDate}";

			HttpResponseMessage response = await _httpClient.GetAsync(url);
			if (response.IsSuccessStatusCode)
			{
				string jsonResponse = await response.Content.ReadAsStringAsync();

				var apiResponse = JsonSerializer.Deserialize<ApiResponse>(jsonResponse, new JsonSerializerOptions
				{
					PropertyNameCaseInsensitive = true
				});

				return apiResponse?.Data?.Payload.FirstOrDefault()?.Rates.FirstOrDefault(x=>x.Currency.Iso3 ==Iso3) ?? new ExchangeRateResponse.Rate();
			}

			return new ExchangeRateResponse.Rate();
		}
	}
}
