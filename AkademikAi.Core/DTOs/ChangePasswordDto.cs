using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkademikAi.Core.DTOs
{
    public class ChangePasswordDto
    {
        [Required(ErrorMessage="Mevcut şifre Gereklidir")]
        public string CurrentPassword { get; set; }
        [Required(ErrorMessage="Yeni şifre Gereklidir")]
        [MinLength(6, ErrorMessage = "Şifre en az 6 karakter olmalıdır.")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage ="Yeni şifre tekrarı gereklidir")]
        [Compare("NewPassword", ErrorMessage = "Yeni şifreler eşleşmiyor.")]
        public string ConfirmPassword { get; set; }
       
    }
}
