using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using QLKS.CNTT1.nnkhanh.Entities;
using Swashbuckle.AspNetCore.Annotations;

namespace QLKS.CNTT1.nnkhanh.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK, type: typeof(List<Discount>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public IActionResult getAllDiscounts()
        {
            try
            {
                string connectionString = DbContext.ConnectionString;
                using (var mySqlConnection = new MySqlConnection(connectionString))
                {
                    // câu lệnh truy vấn
                    string command = "SELECT * FROM discount d;";

                    // Chạy câu lệnh
                    var result = mySqlConnection.Query(command);

                    if (result != null)
                    {
                        // Trả về dữ liệu cho client
                        return StatusCode(StatusCodes.Status200OK, result);
                    }
                    else
                    {
                        return StatusCode(StatusCodes.Status400BadRequest, "e002");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(StatusCodes.Status400BadRequest, "e001");
            }
        }
    }
}
