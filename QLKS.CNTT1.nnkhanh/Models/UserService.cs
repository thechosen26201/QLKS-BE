namespace QLKS.CNTT1.nnkhanh.Models
{
    public class UserService
    {
        public bool IsValidUserInformation(Login model)
        {
            if (model.UserName.Equals("Jay") && model.Password.Equals("123456")) return true;
            else return false;
        }
    }
}
