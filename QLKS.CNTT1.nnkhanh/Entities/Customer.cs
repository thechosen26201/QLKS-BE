namespace QLKS.CNTT1.nnkhanh.Entities
{
    public class Customer
    {
        public Customer(string v1, string v2)
        {
            this.UserName = v1;
            this.Password = v2;
        }

        /// <summary>
        /// ID khách hàng
        /// </summary>
        public Guid CustomerID { get; set; }

        /// <summary>
        /// ID danh sách yêu thích
        /// </summary>
        public Guid WishlistID { get; set; }

        /// <summary>
        /// Tên khách hàng
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// ID tài khoản 
        /// </summary>
        public Guid AccountID { get; set; }

        /// <summary>
        /// Mã tài khoản
        /// </summary>
        public string AccountCode { get; set; }

        /// <summary>
        /// Mã khách hàng
        /// </summary>
        public string CustomerCode { get; set; }

        /// <summary>
        /// Địa chỉ khách hàng
        /// </summary>
        public string CustomerAddress { get; set; }

        /// <summary>
        /// Số điện thoại
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Ngày sinh
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Tên đăng nhập
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Mật khẩu
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Vai trò
        /// 0: Khách hàng
        /// 1: Admin (Quản trị viên)
        /// </summary>
        public int Role { get; set; }

        /// <summary>
        /// Hòm thư điện tử
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Ngày tạo
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Người tạo
        /// </summary>
        public string CreatedBy { get; set; } = "Nguyễn Nam Khánh";

        /// <summary>
        /// Ngày sửa
        /// </summary>
        public DateTime ModifiedDate { get; set; }

        /// <summary>
        /// Người sửa
        /// </summary>
        public string ModifiedBy { get; set; } = "Nguyễn Nam Khánh";
    }
}
