using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebAPI.DTOs;
using WebApp.Models;
using static Azure.Core.HttpHeader;

namespace WebApp.Controllers
{
    public class BookController : Controller
    {
        // Khai báo một biến Uri để lưu địa chỉ cơ sở của API
        Uri baseAddress = new Uri("https://localhost:7028/api");
        // Khai báo một biến HttpClient để gửi yêu cầu HTTP đến API
        private readonly HttpClient _client;

        // Constructor của lớp BookController, khởi tạo đối tượng HttpClient
        public BookController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;

        }

        // Phương thức Index trả về view hiển thị danh sách sách
        public IActionResult Index()
        {
            // Khởi tạo một danh sách sách
            List<SachDTO> bookList = new List<SachDTO>();
            // Gửi yêu cầu HTTP GET đến API để lấy danh sách sách
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Book/GetAllBook").Result;

            // Kiểm tra xem yêu cầu có thành công không
            if (response.IsSuccessStatusCode)
            {
                // Đọc nội dung của phản hồi và chuyển đổi thành chuỗi
                string data = response.Content.ReadAsStringAsync().Result;
                // Chuyển đổi chuỗi JSON thành danh sách sách
                bookList = JsonConvert.DeserializeObject<List<SachDTO>>(data);
            }
            // Trả về view với danh sách sách
            return View(bookList);
        }

        // Phương thức SearchBook dùng để tìm kiếm sách theo tên
        [HttpPost]
        public IActionResult SearchBook(string tenSach)
        {
            // Khởi tạo một danh sách sách
            List<SachDTO> bookList = new List<SachDTO>();
            // Gửi yêu cầu HTTP GET đến API để tìm kiếm sách theo tên
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + $"/Book/GetBookByName/{tenSach}").Result;

            // Kiểm tra xem yêu cầu có thành công không
            if (response.IsSuccessStatusCode)
            {
                // Đọc nội dung của phản hồi và chuyển đổi thành chuỗi
                string data = response.Content.ReadAsStringAsync().Result;
                // Chuyển đổi chuỗi JSON thành đối tượng dynamic
                var responseObject = JsonConvert.DeserializeObject<dynamic>(data);
                // Lấy danh sách sách từ đối tượng dynamic và chuyển đổi thành danh sách sách
                bookList = responseObject.sachList.ToObject<List<SachDTO>>();
            }

            // Trả về kết quả thành công và danh sách sách tìm được
            return Ok(new { success = true, sachList = bookList });
        }

        // Phương thức GetBookByCategory dùng để lấy sách theo danh mục
        [HttpPost]
        public IActionResult GetBookByCategory(string ngonNgu, string theLoai, string namXB)
        {
            // Khởi tạo một danh sách sách
            List<SachDTO> bookList = new List<SachDTO>();

            try
            {
                // Gửi yêu cầu HTTP GET đến API để lấy sách theo danh mục
                HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + $"/Book/GetBookByCategory/{ngonNgu}/{theLoai}/{namXB}").Result;

                // Kiểm tra xem yêu cầu có thành công không
                if (response.IsSuccessStatusCode)
                {
                    // Đọc nội dung của phản hồi và chuyển đổi thành chuỗi
                    string data = response.Content.ReadAsStringAsync().Result;
                    // Chuyển đổi chuỗi JSON thành đối tượng dynamic
                    var responseObject = JsonConvert.DeserializeObject<dynamic>(data);
                    // Lấy danh sách sách từ đối tượng dynamic và chuyển đổi thành danh sách sách
                    bookList = responseObject.sachList.ToObject<List<SachDTO>>();
                }
                else
                {
                    // Xử lý trường hợp yêu cầu không thành công
                    return BadRequest(new { success = false, message = "Failed to retrieve data from API." });
                }
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ
                return StatusCode(500, new { success = false, message = ex.Message });
            }

            // Trả về kết quả thành công và danh sách sách tìm được
            return Ok(new { success = true, sachList = bookList });
        }
    }
}

/*using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebAPI.DTOs;
using WebApp.Models;
using static Azure.Core.HttpHeader;

namespace WebApp.Controllers
{
    public class BookController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7028/api");
        private readonly HttpClient _client;

        public BookController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;

        }

        public IActionResult Index()
        {
            List<SachDTO> bookList = new List<SachDTO>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Book/GetAllBook").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                bookList = JsonConvert.DeserializeObject<List<SachDTO>>(data);
            }
            return View(bookList);
        }

        [HttpPost]
        public IActionResult SearchBook(string tenSach)
        {

            List<SachDTO> bookList = new List<SachDTO>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + $"/Book/GetBookByName/{tenSach}").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                var responseObject = JsonConvert.DeserializeObject<dynamic>(data);
                bookList = responseObject.sachList.ToObject<List<SachDTO>>();
            }

            return Ok(new { success = true, sachList = bookList });
        }


        [HttpPost]
        public IActionResult GetBookByCategory(string ngonNgu, string theLoai, string namXB)
        {
            List<SachDTO> bookList = new List<SachDTO>();

            try
            {
                HttpResponseMessage response = _client.GetAsync($"/Book/GetBookByCategory/{ngonNgu}/{theLoai}/{namXB}").Result;

                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    var responseObject = JsonConvert.DeserializeObject<dynamic>(data);
                    bookList = responseObject.sachList.ToObject<List<SachDTO>>();
                }
                else
                {
                    // Handle non-success status code
                    return BadRequest(new { success = false, message = "Failed to retrieve data from API." });
                }
            }
            catch (Exception ex)
            {
                // Handle exception
                return StatusCode(500, new { success = false, message = ex.Message });
            }

            return Ok(new { success = true, sachList = bookList });
        }


    }
}
*/