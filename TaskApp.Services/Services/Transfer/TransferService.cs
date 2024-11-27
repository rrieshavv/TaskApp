using TaskApp.Services.Library;
using TaskApp.Services.Models;

namespace TaskApp.Services.Services.Transfer
{
	public class TransferService : ItransferService
	{
		private readonly DAO _dao;
		public TransferService(DAO dao)
		{
			_dao = dao;
		}
		public async Task<TransferSenderDetailsResponse> GetDetailsByEmailAsync(string email)
		{
			var query = "SELECT firstname, middlename, lastname, address, country FROM tbl_user WHERE email = @Email";
			var parameters = new { Email = email };
			var result = await _dao.QueryAsync<TransferSenderDetailsResponse>(query, parameters);

			return result.FirstOrDefault();
		}

		public async Task<CommonResponse> TransferMoney(TransferModel transferModel)
		{
			var result = await _dao.ExecuteStoredProcedureAsync<CommonResponse>("sp_money_transfer", new
			{
				UserEmail = transferModel.UserEmail,
				Firstname = transferModel.Firstname,
				Middlename = transferModel.Middlename,
				Lastname = transferModel.Lastname,
				Address = transferModel.Address,
				Country = transferModel.Country,
				BankName = transferModel.BankName,
				AccountNumber = transferModel.AccountNumber,
				ExchangeRate = transferModel.ExchangeRate,
				TransferAmount = transferModel.TransferAmount,
				PayoutAmount = transferModel.PayoutAmount,
				TransferIso3 = transferModel.TransferIso3,
				PayoutIso3 = transferModel.PayoutIso3
			});

			return result.FirstOrDefault();
		}
	}
}
