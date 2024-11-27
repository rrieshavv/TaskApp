using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskApp.Services.Models;

namespace TaskApp.Services.Services.Transfer
{
	public interface ItransferService
	{
		Task<TransferSenderDetailsResponse> GetDetailsByEmailAsync(string email);

		Task<CommonResponse> TransferMoney(TransferModel transferModel);

	}
}
