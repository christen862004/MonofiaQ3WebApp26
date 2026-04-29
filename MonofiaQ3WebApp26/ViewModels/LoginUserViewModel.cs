using System.ComponentModel.DataAnnotations;

namespace MonofiaQ3WebApp26.ViewModels
{
    public class LoginUserViewModel
    {
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RmemeberMe { get; set; }
    }
}
