using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TaskApp.Services.Library;
using TaskApp.Services.Models;
using static System.Net.Mime.MediaTypeNames;

namespace TaskApp.Services.Services.User
{
	public class UserService : IUserService
	{
		private readonly DAO _dao;
		public UserService(DAO dao)
		{
			_dao = dao;
		}

		public async Task<LoginResponse> Login(string email, string password)
		{
			try
			{
				var result = await _dao.ExecuteStoredProcedureAsync<LoginResponse>("sp_login_user", new
				{
					Email = email,
					Password = password
				});
				return result.FirstOrDefault();
			}
			catch (Exception ex)
			{
				return new LoginResponse
				{
					Code = 1,
					Message = "Error occured while logging you in."
				};
			}
		}

		public async Task<CommonResponse> Register(UserRegisterModel registerModel)
		{
			try
			{
				var result = await _dao.ExecuteStoredProcedureAsync<CommonResponse>("sp_register_user", new
				{
					FirstName = registerModel.Firstname,
					LastName = registerModel.Lastname,
					MiddleName = registerModel.Middlename,
					Email = registerModel.Email,
					Phone = registerModel.Phone,
					Password = registerModel.Password,
					Country = registerModel.Country,
					Address = registerModel.Address
				});
				return result.FirstOrDefault();
			}
			catch (Exception ex)
			{
				return new CommonResponse
				{
					Code = 1,
					Message = "Server error occured while registration."
				};
			}
		}
	}
}
