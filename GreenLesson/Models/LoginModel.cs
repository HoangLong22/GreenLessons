using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GreenLesson.Models
{
    public class LoginModel
    {
        [Key]
        public long ID { get; set; }

        [Display(Name ="Tên đăng nhập")]
        [Required(ErrorMessage ="Bạn phải nhập tên đăng nhâp")]
        public  string UserName { set; get; }

        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Bạn phải nhập mật khẩu")]
        public string Password { set; get; }
    }
}