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
    public class HotelsController : ControllerBase
    {
        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK, type: typeof(List<Hotel>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public IActionResult getAllHotels()
        {
            try
            {
                string connectionString = DbContext.ConnectionString;

                using (var mySqlConnection = new MySqlConnection(connectionString))
                {
                    // Chuẩn bị tên Stored procedure
                    string storedProcedureName = "Proc_Hotel_GetAllHotel";
                    
                    var result = mySqlConnection.Query<Hotel>(storedProcedureName, commandType: System.Data.CommandType.StoredProcedure);
                    if (result != null) { 
                        return StatusCode(StatusCodes.Status200OK, result);
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
