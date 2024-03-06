using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Red_Social1.Core.Application.Dtos.Account
{
    public class UserResponse
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }

        public string PhoneNumber { get; set; }

        public string PhotoUrl { get; set; }

        public bool HasError { get; set; }
        public string? Error { get; set; }
    }
}
