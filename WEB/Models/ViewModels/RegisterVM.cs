using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WEB.Models.ViewModels
{
    public class RegisterVM
    {
        [Required(ErrorMessage ="kullanıcı adı gerekli!")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Email adı gerekli!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Şifre gerekli!")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Şifre (Tekrar) gerekli!")]
        [Compare("Password",ErrorMessage ="Şifreler uyuşmuyor!")]
        public string ConfirmPassword { get; set; }
    }
}
