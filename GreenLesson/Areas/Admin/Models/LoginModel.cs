using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GreenLesson.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Mời bạn nhập tên đăng nhập")]
        public string UserName { set; get; }

        [Required(ErrorMessage = "Mời bạn nhập mật khẩu")]
        public string Password { set; get; }

        public bool RememberMe { set; get; }
    }
}