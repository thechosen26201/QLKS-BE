using System.ComponentModel.DataAnnotations;

namespace QLKS.CNTT1.nnkhanh.Entities
{
    public class RoomOrder
    {
        /// <summary>
        /// ID đơn đặt phòng
        /// </summary>
        [Key]
        public Guid OrderID { get; set; }

        /// <summary>
        /// Mã đơn đặt phòng
        /// </summary>
        public string OrderCode { get; set; }

        /// <summary>
        /// Tổng giá
        /// </summary>
        public decimal TotalPrice { get; set; }

        /// <summary>
        /// Trạng thái đơn đặt phòng 0: đang xử lý 1: đã xử lý
        /// </summary>
        public int Status { get; set; } 
        /// <summary>
        /// ID phòng
        /// </summary>
        public Guid RoomID { get; set; }

        /// <summary>
        /// Tên phòng (Số hiệu phòng)
        /// </summary>
        public string RoomName { get; set; }

        /// <summary>
        /// Ngày đặt
        /// </summary>
        public DateTime BookedDate { get; set; }

        /// <summary>
        /// Ngày trả
        /// </summary>
        public DateTime LeftDate { get; set; }

        /// <summary>
        /// Tên khách hàng
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// ID khách sạn
        /// </summary>
        public Guid HotelID { get; set; }

        /// <summary>
        /// Tên khách sạn
        /// </summary>
        public string HotelName { get; set; }

        /// <summary>
        /// Mã khách sạn
        /// </summary>
        public string HotelCode { get; set; }

        /// <summary>
        /// Mã khách hàng
        /// </summary>
        public string CustomerCode { get; set; }

        /// <summary>
        /// Mã phương thức thanh toán
        /// </summary>
        public string PaymentCode { get; set; }

        /// <summary>
        /// Tên phương thức thanh toán
        /// </summary>
        public string PaymentName { get; set; }

        /// <summary>
        /// ID phương thức thanh toán
        /// </summary>
        public Guid PaymentID { get; set; }

        /// <summary>
        /// ID khách hàng
        /// </summary>
        public Guid CustomerID { get; set; }

        /// <summary>
        /// Số điện thoại
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// ID danh sách yêu thích
        /// </summary>
        public Guid WishlistID { get; set; }

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
