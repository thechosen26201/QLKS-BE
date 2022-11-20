namespace QLKS.CNTT1.nnkhanh.Entities
{
    public class Servicedetail
    {
        /// <summary>
        /// ID khách sạn
        /// </summary>
        public Guid HotelID { get; set; }

        /// <summary>
        /// ID dịch vụ
        /// </summary>
        public Guid ServiceID { get; set; }

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
