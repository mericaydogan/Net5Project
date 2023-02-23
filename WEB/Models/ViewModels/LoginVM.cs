﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WEB.Models.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage ="Kullanıcı adı boş geçilemez!")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Şifre boş geçilemez!")]

        public string Password { get; set; }
    }
}
