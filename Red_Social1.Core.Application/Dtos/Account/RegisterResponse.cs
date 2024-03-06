using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Red_Social1.Core.Application.Dtos.Account
{
    public class RegisterResponse
    {
        public bool HasError { get; set; }
        public string? Error { get; set; }   
    }
}
