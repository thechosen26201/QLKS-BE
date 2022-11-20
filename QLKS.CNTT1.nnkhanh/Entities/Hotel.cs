namespace QLKS.CNTT1.nnkhanh.Entities
{
    public class Hotel
    {
        /// <summary>
        /// ID khách sạn
        /// </summary>
        public Guid HotelID { get; set; }

        /// <summary>
        /// Mã khách sạn
        /// </summary>
        public string HotelCode { get; set; }

        /// <summary>
        /// Tên khách sạn
        /// </summary>
        public string HotelName { get; set; }

        /// <summary>
        /// Địa chỉ khách sạn
        /// </summary>
        public string HotelAddress { get; set; }

        /// <summary>
        /// Đánh giá
        /// </summary>
        public int Rate { get; set; }

        /// <summary>
        /// ID dịch vụ
        /// </summary>
        public Guid ServiceID { get; set; }

        /// <summary>
        /// Tên dịch vụ
        /// </summary>
        public string ServiceName { get; set; }

        /// <summary>
        /// Mã dịch vụ
        /// </summary>
        public string ServiceCode { get; set; }

        /// <summary>
        /// Ngày tạo
        /// </summary>
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        /// <summary>
        /// Người tạo
        /// </summary>
        public string CreatedBy { get; set; } = "Nguyễn Nam Khánh";

        /// <summary>
        /// Ngày sửa
        /// </summary>
        public DateTime ModifiedDate { get; set; } = DateTime.Now;

        /// <summary>
        /// Người sửa
        /// </summary>
        public string ModifiedBy { get; set; } = "Nguyễn Nam Khánh";
    }
}
