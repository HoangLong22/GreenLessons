using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GreenLesson.Models
{
    public class RegisterModel
    {
        [Key]
        public long ID { get; set; }

        [Display(Name = "Tên đăng nhập")]
        [Required(ErrorMessage ="Yêu cầu nhập tên đăng nhâp")]
        public string UserName { get; set; }

        [Display(Name = "Mật khẩu")]
        [StringLength(20,MinimumLength = 6, ErrorMessage ="Độ dài mật khẩu ít nhất 6 ký tự")]
        [Required(ErrorMessage = "Yêu cầu nhập mật khẩu")]
        public string Password { get; set; }

        [Display(Name = "Xác nhận mật khẩu")]
        [Compare("Password",ErrorMessage ="Xác nhận mật khẩu không đúng")]
        public string ConfirmPassword { get; set; }


        [Display(Name = "Họ và tên")]
        [Required(ErrorMessage = "Yêu cầu nhập học và tên")]
        public string Name { get; set; }

        [Display(Name = "Avartar")]
        public string Image { get; set; }


        [Display(Name = "Số điện thoại")]
        public string Phone { get; set; }


        [Display(Name = "Email")]
        public string Email { get; set; }


        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }
    }
}