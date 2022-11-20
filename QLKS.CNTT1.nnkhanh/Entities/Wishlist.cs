namespace QLKS.CNTT1.nnkhanh.Entities
{
    public class Wishlist
    {
        /// <summary>
        /// ID danh sách yêu thích
        /// </summary>
        public Guid WishlistID { get; set; }

        /// <summary>
        /// ID khách sạn
        /// </summary>
        public Guid? HotelID { get; set; }
        /// <summary>
        /// Mã khách sạn
        /// </summary>
        public string? HotelCode { get; set; }

        /// <summary>
        /// Tên khách sạn
        /// </summary>
        public string? HotelName { get; set; }

        /// <summary>
        /// ID khách hàng
        /// </summary>
        public Guid CustomerID { get; set; }

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
