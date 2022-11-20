using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using Swashbuckle.AspNetCore.Annotations;
using QLKS.CNTT1.nnkhanh.Entities;

namespace QLKS.CNTT1.nnkhanh.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        [HttpGet("{hotelID}")]
        [SwaggerResponse(StatusCodes.Status200OK, type: typeof(Service))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public IActionResult GetService([FromRoute] Guid hotelID)
        {
            try
            {
                string connectionString = DbContext.ConnectionString;

                using (var mySqlConnection = new MySqlConnection(connectionString))
                {
                    // Chuẩn bị tên Stored procedure
                    //string storedProcedureName = "Proc_ServiceJoinServiceDetail_GetService";
                    string storedProcedureName = "SELECT * FROM service s INNER JOIN servicedetail s1 ON s.ServiceID = s1.ServiceID WHERE s1.HotelID IN (@v_hotelID);";
                    // Chuẩn bị tham số đầu vào cho stored procedure
                    var parameters = new DynamicParameters();
                    parameters.Add("@v_hotelID", hotelID);
                    var result = mySqlConnection.QueryMultiple(storedProcedureName, parameters);
                    if (result != null)
                    {
                        var service = result.Read<Service>().ToList();
                        return StatusCode(StatusCodes.Status200OK, service);
                    }
                    return StatusCode(StatusCodes.Status404NotFound, "e002");
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "e001");
            }
        }
    }
}
