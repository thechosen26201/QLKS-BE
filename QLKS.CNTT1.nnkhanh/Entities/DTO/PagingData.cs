namespace QLKS.CNTT1.nnkhanh.Entities.DTO
{
    public class PagingData<T>
    {
        
            /// <summary>
            /// dữ liệu trả về khi lọc & phân trang
            /// </summary>
            public List<T> Data { get; set; }
            /// <summary>
            /// Tổng số bản ghi thỏa mãn điều kiện
            /// </summary>
            public long totalCount { get; set; }
        
    }
}
