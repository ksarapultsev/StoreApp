using System.ComponentModel.DataAnnotations;
using System;

namespace StoreApp.ViewModels
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Не указан Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароль введен неверно")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Не указан Email")]
        public string UserName { get; set; } 
        public string UserLogin { get; set; }
        public string UserPassword { get; set; }
        
        public DateTime RecordDateTimeStamp { get; set; }
    }
}
