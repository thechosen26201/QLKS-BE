using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using Swashbuckle.AspNetCore.Annotations;
using QLKS.CNTT1.nnkhanh.Entities;
using Dapper;


namespace QLKS.CNTT1.nnkhanh.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        /// <summary>
        /// Thêm mới 1 hóa đơn
        /// </summary>
        /// <param name="order"></param>
        /// <returns>ID thêm mới thành công</returns>
        /// Created by: NNKHANh 23/10/22
        [HttpPost]
        [SwaggerResponse(StatusCodes.Status201Created, type: typeof(Guid))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public IActionResult InsertOrder([FromBody] RoomOrder order)
        {
            try
            {
                // Tạo chuỗi kết nối tới DB
                string connectionString = DbContext.ConnectionString;

                using (var mySqlConnection = new MySqlConnection(connectionString))
                {

                    // Chuẩn bị tên Procedure
                    string storedProcedureName = "Proc_RoomOrder_Insert";

                    // Tạo parameters
                    var parameters = new DynamicParameters();

                    // Chuẩn bị tham số đầu vào
                    parameters.Add("v_orderCode", order.OrderCode);
                    parameters.Add("v_totalPrice", order.TotalPrice);
                    parameters.Add("v_status", 0);
                    parameters.Add("v_roomID", order.RoomID);
                    parameters.Add("v_roomName", order.RoomName);
                    parameters.Add("v_bookedDate", order.BookedDate);
                    parameters.Add("v_leftDate", order.LeftDate);
                    parameters.Add("v_hotelID", order.HotelID);
                    parameters.Add("v_hotelName", order.HotelName);
                    parameters.Add("v_hotelCode", order.HotelCode);
                    parameters.Add("v_customerID", order.CustomerID);
                    parameters.Add("v_customerCode", order.CustomerCode);
                    parameters.Add("v_customerName", order.CustomerName);
                    parameters.Add("v_phoneNumber", order.PhoneNumber);
                    parameters.Add("v_email", order.Email);
                    parameters.Add("v_paymentID", order.PaymentID);
                    parameters.Add("v_paymentCode", order.PaymentCode);
                    parameters.Add("v_paymentName", order.PaymentName);
                    parameters.Add("v_wishlistID", null);
                    parameters.Add("v_createdDate", DateTime.Now);
                    parameters.Add("v_createdBy", "Nguyen nam Khanh");
                    parameters.Add("v_modifiedDate", DateTime.Now);
                    parameters.Add("v_modifiedBy", "Nguyen Nam Khanh");

                    // Thực hiện chạy storedProcedure
                    var results = mySqlConnection.Execute(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);
                    if (results > 0)
                    {
                        return StatusCode(StatusCodes.Status201Created, $"Thêm mới thành công {order.OrderID}");
                    }
                    return StatusCode(StatusCodes.Status400BadRequest, "e002");
                }

            }
            catch (MySqlException mySqlException)
            {
                if (mySqlException.ErrorCode == MySqlErrorCode.DuplicateKeyEntry)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "e003");
                }
                return StatusCode(StatusCodes.Status400BadRequest, "e001: Thêm mới thất bại");
            }
            catch (Exception exception)
            {
                Console.Write(exception);
                return StatusCode(StatusCodes.Status400BadRequest, "e001");
            }


        }

        /// <summary>
        /// Xóa đơn đặt phòng
        /// </summary>
        /// <param name="orderID">ID của hóa đơn muốn xóa</param>
        /// <returns>Danh sách ID xóa thành công</returns>
        /// Created by: NNKhanh 23/10/22
        [HttpDelete("{orderID}")]
        [SwaggerResponse(StatusCodes.Status200OK, type: typeof(Guid))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteOrder([FromRoute] Guid orderID)
        {
            try
            {
                //Tạo kết nối tới DB   
                string connectionString = DbContext.ConnectionString;
                using (var mySqlConnection = new MySqlConnection(connectionString))
                {
                    //Chuẩn bị tên Procedure
                    string storedProcedureName = "Proc_RoomOrder_Delete";

                    // Tạo parameters cho procedure
                    var parameters = new DynamicParameters();

                    // Chuẩn bị tham số cho procedure
                    //string id;

                    //id = String.Join("','", orderID);
                    //id = $"('{id}')";

                    parameters.Add("v_orderID", orderID);
                    var result = mySqlConnection.Execute(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);

                    //thực hiện trả kết quả về cho người dùng
                    if (result > 0)
                    {
                        return StatusCode(StatusCodes.Status200OK, $"xóa thành công {orderID}" );
                    }
                    return StatusCode(StatusCodes.Status400BadRequest, "failed");
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "ERROR");
            }
        }

        /// <summary>
        /// Lấy mã mới
        /// </summary>
        /// <returns>Mã mới</returns>
        [HttpGet("new-code")]
        [SwaggerResponse(StatusCodes.Status200OK, type: typeof(string))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public IActionResult getNewOrderCode()
        {
            try
            {
                //connect DB
                string connectionString = DbContext.ConnectionString;
                using (var mySqlConnection = new MySqlConnection(connectionString))
                {
                    //tạo câu lệnh GET
                    string getMaxCodeCommand = "SELECT r.OrderCode FROM roomorder r ORDER BY r.OrderCode DESC LIMIT 1;";
                    //string getMaxCodeCommand = "SELECT Func_RoomOrder_GetNewCode();";


                    //thực hiện truy vấn 
                    var maxCode = mySqlConnection.QueryFirstOrDefault<string>(getMaxCodeCommand);
                    //trả về cho người dùng

                    if(maxCode != null)
                    {
                        var newCode = "OD" + (Int64.Parse(maxCode.Substring(2)) + 1).ToString();
                        return StatusCode(StatusCodes.Status200OK, newCode);
                    }
                    else
                    {
                        maxCode = "OD1000";
                        return StatusCode(StatusCodes.Status200OK, maxCode);
                    }
                }
            }
            catch (Exception e)
            {
                Console.Write(e);
                return StatusCode(StatusCodes.Status400BadRequest, "e001");
            }

        }
    }
}
