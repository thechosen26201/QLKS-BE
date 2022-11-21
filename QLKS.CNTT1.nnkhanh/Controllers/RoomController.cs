using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using QLKS.CNTT1.nnkhanh.Entities;
using QLKS.CNTT1.nnkhanh.Entities.DTO;
using Swashbuckle.AspNetCore.Annotations;

namespace QLKS.CNTT1.nnkhanh.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK, type: typeof(PagingData<Room>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public IActionResult GetPaging([FromQuery] string? keyword, [FromQuery] Guid? hotelID, [FromQuery] int pageSize = 10, [FromQuery] int pageNumber = 1)
        {
            try
            {
                // Kết nối với DB                
                string connectionString = DbContext.ConnectionString;
                using (var mySqlConnection = new MySqlConnection(connectionString))
                {
                    // Chuẩn bị tên Stored procedure
                    string storedProcedureName = "Proc_Room_GetPaging";

                    // Chuẩn bị tham số đầu vào cho stored procedure
                    var parameters = new DynamicParameters();
                    parameters.Add("v_Offset", (pageNumber - 1) * pageSize);
                    parameters.Add("v_Limit", pageSize);
                    parameters.Add("v_Sort", "ModifiedDate DESC");

                    var orConditions = new List<string>();
                    //var andConditions = new List<string>();
                    var conditionString = new List<string>();
                    string whereClause = "";

                    if(keyword != null)
                    {
                        orConditions.Add($"h.HotelName LIKE '%{keyword}%'");
                        orConditions.Add($"h.HotelAddress LIKE '%{keyword}%'");
                    }

                    if (hotelID != null)
                    {
                        conditionString.Add($"h.HotelID = '{hotelID}'");
                    }

                    if (conditionString.Count > 0)
                    {
                        whereClause = $"({string.Join("", conditionString)})";
                    }
                    if(orConditions.Count > 0)
                    {
                        if(whereClause.Length > 0)
                        {
                            whereClause += $" AND {string.Join(" OR ", orConditions)}";
                        }
                        whereClause += $" {string.Join(" OR ", orConditions)}";
                    }

                    parameters.Add("v_Where", whereClause);

                    // Thực hiện gọi vào DB để chạy stored procedure với tham số đầu vào ở trên
                    var multipleResults = mySqlConnection.QueryMultiple(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);

                    // Xử lý kết quả trả về từ DB
                    if (multipleResults != null)
                    {
                        var rooms = multipleResults.Read<Room>().ToList();
                        var totalCount = multipleResults.Read<long>().Single();
                        return StatusCode(StatusCodes.Status200OK, new PagingData<Room>()
                        {
                            Data = rooms,
                            totalCount = totalCount
                        });
                    }
                    else
                    {
                        return StatusCode(StatusCodes.Status400BadRequest, "e002");
                    }
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "e001");
            }
        }
    }
}
