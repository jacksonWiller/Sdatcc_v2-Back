﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sdatcc.Api.Dto.User.ManegeDto
{
    public class RemoveLoginDto
    {
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }
    }
}
