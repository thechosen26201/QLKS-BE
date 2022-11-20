using System.ComponentModel.DataAnnotations;

namespace QLKS.CNTT1.nnkhanh.Models
{
    public class Login
    {
        public Login(string userName, string password)
        {
            this.UserName = userName;
            this.Password = password;
        }
        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage = "Không để trống")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Không để trống")]
        public string Password { get; set; }
    }
}
