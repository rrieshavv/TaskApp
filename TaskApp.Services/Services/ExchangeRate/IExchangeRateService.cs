using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskApp.Services.Models;

namespace TaskApp.Services.Services.ExchangeRate
{
    public interface IExchangeRateService
    {
        Task<List<ExchangeRateResponse.Rate>> GetExchangeRatesAsync(string from, string to);
        Task<ExchangeRateResponse.Rate> GetExchangeRateByIso3(string fromDate, string toDate, string Iso3);

	}
}
