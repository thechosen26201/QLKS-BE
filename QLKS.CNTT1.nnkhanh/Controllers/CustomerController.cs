using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using Swashbuckle.AspNetCore.Annotations;
using QLKS.CNTT1.nnkhanh.Entities;
using QLKS.CNTT1.nnkhanh.Enum;

namespace QLKS.CNTT1.nnkhanh.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        /// <summary>
        /// Thêm mới 1 khách hàng
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [SwaggerResponse(StatusCodes.Status201Created, type: typeof(Guid))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public IActionResult InsertNewCustomer([FromBody] Customer customer)
        {
            try
            {
                // tạo kết nối tới DB
                string connectionString = DbContext.ConnectionString;
                using (var mySqlConnection = new MySqlConnection(connectionString))
                {
                    // Chuẩn bị tên Procedure
                    string procedureName = "Proc_Customer_Wishlist_Insert";

                    // Tạo parameters
                    var parameters = new DynamicParameters();

                    // Chuẩn bị tham số đầu vào
                    #region variablesInsert
                    parameters.Add("v_accountCode", customer.AccountCode);
                    parameters.Add("v_customerCode", customer.CustomerCode);
                    parameters.Add("v_customerName", customer.CustomerName);
                    parameters.Add("v_customerAddress", customer.CustomerAddress);
                    parameters.Add("v_phoneNumber", customer.PhoneNumber);
                    parameters.Add("v_dateOfBirth", customer.DateOfBirth);
                    parameters.Add("v_userName", customer.UserName);
                    parameters.Add("v_password", customer.Password);
                    parameters.Add("v_role", 0);
                    parameters.Add("v_email", customer.Email);
                    parameters.Add("v_createdDate", DateTime.Now);
                    parameters.Add("v_createdBy", "Khanh Nguyen");
                    parameters.Add("v_modifiedDate", DateTime.Now);
                    parameters.Add("v_modifiedBy", "Khanh Nguyen");
                    #endregion

                    //Thực hiện chạy Procedure
                    var result = mySqlConnection.Execute(procedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);
                    //if (result > 0)
                    //{
                    //    return StatusCode(StatusCodes.Status201Created, $"Thêm mới thành công {customer.CustomerID}");
                    //}
                    return StatusCode(StatusCodes.Status201Created, $"Thêm mới thành công {customer.CustomerID}");

                    //return StatusCode(StatusCodes.Status400BadRequest, "e002");
                }
            }
            catch (MySqlException mySqlException)
            {
                if (mySqlException.ErrorCode == MySqlErrorCode.DuplicateKeyEntry)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, Errors.e003);
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
        /// Cập nhật thông tin 1 khách hàng
        /// </summary>
        /// <param name="customerID">ID khách hàng</param>
        /// <param name="customer">Thông tin khách hàng đó</param>
        /// <returns>ID khách hàng</returns>
        [HttpPut("customerID")]
        [SwaggerResponse(StatusCodes.Status200OK, type: typeof(Guid))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateCustomer([FromRoute] Guid customerID, [FromBody] Customer customer)
        {
            try
            {
                //Khởi tạo chuỗi kết nối db
                string connectionString = DbContext.ConnectionString;
                using (var mySqlConnection = new MySqlConnection(connectionString))
                {
                    // Chuẩn bị tên Procedure
                    var storedProcedureName = "Proc_Customer_Delete";

                    // Chuẩn bị tên parameter
                    var parameters = new DynamicParameters();

                    // Chuẩn bị tham số đầu vào
                    parameters.Add("v_customerID", customerID);
                    parameters.Add("v_customerName", customer.CustomerName);
                    parameters.Add("v_customerAddress", customer.CustomerAddress);
                    parameters.Add("v_phoneNumber", customer.PhoneNumber);
                    parameters.Add("v_dateOfBirth", customer.DateOfBirth);
                    parameters.Add("v_userName", customer.UserName);
                    parameters.Add("v_password", customer.Password);
                    parameters.Add("v_role", 0);
                    parameters.Add("v_email", customer.Email);
                    parameters.Add("v_createdDate", DateTime.Now);
                    parameters.Add("v_createdBy", "Khanh");
                    parameters.Add("v_modifiedDate", DateTime.Now);
                    parameters.Add("v_modifiedBy", "Khanh");

                    // Thực hiện chạy procedure
                    var result = mySqlConnection.Execute(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);

                    if (result > 0)
                    {
                        return StatusCode(StatusCodes.Status200OK, $"Cập nhật thông tin khách hàng { customerID} thành công");
                    }
                    else
                    {
                        return StatusCode(StatusCodes.Status400BadRequest, "lỗi không cập nhật được");
                    }
                }
            }
            catch (MySqlException mySqlException)
            {
                if (mySqlException.ErrorCode == MySqlErrorCode.DuplicateKeyEntry)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "e003");
                }
                return StatusCode(StatusCodes.Status400BadRequest, "e001: Cập nhật thất bại");
            }
            catch (Exception exception)
            {
                //e001 ex chung
                Console.Write(exception.ToString());
                return StatusCode(StatusCodes.Status400BadRequest, "e001");
            }
        }

        /// <summary>
        /// Xóa 1 khách hàng
        /// </summary>
        /// <param name="customerID"></param>
        /// <returns>ID khách hàng</returns>
        [HttpDelete("{customerID}")]
        [SwaggerResponse(StatusCodes.Status200OK, type: typeof(Guid))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteCustomer([FromRoute] Guid customerID)
        {
            try
            {
                string connectionString = DbContext.ConnectionString;
                using (var mySqlConnection = new MySqlConnection(connectionString))
                {
                    // Tạo tên procedure
                    string storedProcedureName = "Proc_Customer_Delete";

                    // Chuẩn bị tên parameters
                    var parameters = new DynamicParameters();

                    // Chuẩn bị tham số 
                    parameters.Add("v_customerID", customerID);

                    // Chạy storedProcedure
                    var result = mySqlConnection.Execute(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);

                    if (result > 0)
                    {
                        return StatusCode(StatusCodes.Status200OK, $"Xóa thành công khách hàng {customerID}");
                    }
                    else
                    {
                        return StatusCode(StatusCodes.Status400BadRequest, "lỗi không xóa được");
                    }
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "ERROR");
            }
        }
    }
}
