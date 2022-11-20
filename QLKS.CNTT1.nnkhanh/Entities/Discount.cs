namespace QLKS.CNTT1.nnkhanh.Entities
{
    public class Discount
    {
        /// <summary>
        /// Id giảm giá
        /// </summary>
        public Guid DiscountID { get; set; }

        /// <summary>
        /// Mã giảm giá
        /// </summary>
        public string DiscountCode { get; set; }

        /// <summary>
        /// Tỷ lệ giảm giá
        /// </summary>
        public decimal DiscountPercentage { get; set; }

        /// <summary>
        /// Ngày hết hạn
        /// </summary>
        public DateTime ExpiredDate { get; set; }

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
