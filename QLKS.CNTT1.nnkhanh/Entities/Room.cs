using System.ComponentModel.DataAnnotations;

namespace QLKS.CNTT1.nnkhanh.Entities
{
    public class Room
    {
        /// <summary>
        /// ID phòng
        /// </summary>
        /// 
        [Key]
        public Guid RoomID { get; set; }

        /// <summary>
        /// Mã phòng
        /// </summary>
        public string RoomCode { get; set; }

        /// <summary>
        /// Tên phòng (Số hiệu phòng)
        /// </summary>
        public string RoomName { get; set; }

        /// <summary>
        /// Trạng thái phòng 0: còn trống 1: đã đặt
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// Giá phòng 
        /// </summary>
        public decimal RoomPrice { get; set; }

        /// <summary>
        /// Loại phòng
        /// </summary>
        public int RoomType { get; set; }

        /// <summary>
        /// ID giảm giá
        /// </summary>
        public Guid DiscountID {get; set; }

        /// <summary>
        /// Mã giảm giá
        /// </summary>
        public string DiscountCode { get; set; }

        /// <summary>
        /// ID đơn đặt phòng
        /// </summary>
        public Guid OrderID { get; set; }

        /// <summary>
        /// ID khách sạn
        /// </summary>
        public Guid HotelID { get; set; }

        /// <summary>
        /// Tên khách sạn
        /// </summary>
        public string HotelName { get; set; }

        /// <summary>
        /// Địa chỉ khách sạn
        /// </summary>
        public string HotelAddress { get; set; }

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
