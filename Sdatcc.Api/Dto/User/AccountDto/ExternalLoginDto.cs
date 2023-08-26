using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sdatcc.Api.Dto.User.AccountDto
{
    public class ExternalLoginDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
