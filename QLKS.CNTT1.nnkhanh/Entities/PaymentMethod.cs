using System.ComponentModel.DataAnnotations;

namespace QLKS.CNTT1.nnkhanh.Entities
{
    public class PaymentMethod
    {
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
        [Key]
        public Guid PaymentID { get; set; }

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
