using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace FullCart.Application.DTOs.Account
{
    public class ForgotPasswordRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
