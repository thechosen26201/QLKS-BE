namespace QLKS.CNTT1.nnkhanh.Entities
{
    public class Service
    {
        /// <summary>
        /// ID dịch vụ
        /// </summary>
        public Guid ServiceID { get; set; }

        /// <summary>
        /// Mã dịch vụ
        /// </summary>
        public string ServiceCode { get; set; }

        /// <summary>
        /// Tên dịch vụ
        /// </summary>
        public string ServiceName { get; set; }

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
