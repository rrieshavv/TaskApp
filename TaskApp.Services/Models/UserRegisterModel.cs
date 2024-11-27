﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskApp.Services.Models
{
	public class UserRegisterModel
	{
		public string Email { get; set; }
		public string Password { get; set; }
		public string Firstname { get; set; }
		public string Lastname { get; set; }
		public string? Middlename { get; set; }	
		public string Phone {  get; set; }
		public string Country { get; set; }
		public string Address { get; set; }
	}
}
