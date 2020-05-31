using System.ComponentModel.DataAnnotations;
using System;

namespace StoreApp.ViewModels
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Не указан Email")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный адрес")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Не указан пароль")]
        [Compare("Password", ErrorMessage = "Пароль введен неверно")]
        public string ConfirmPassword { get; set; }


        [Required(ErrorMessage = "Не указано имя")]
        public string UserName { get; set; }


        [Required(ErrorMessage = "Не указан логин")]
        public string UserLogin { get; set; }
               
        public DateTime RecordDateTimeStamp { get; set; }
    }
}
