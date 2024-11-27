using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskApp.Services.Models
{
    public class LoginResponse
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public string Email { get; set; }
    }
}
