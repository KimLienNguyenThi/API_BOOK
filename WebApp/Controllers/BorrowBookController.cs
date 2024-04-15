using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebAPI.DTOs;

namespace WebApp.Controllers
{
    // Khai báo một lớp controller có tên BorrowBookController, kế thừa từ lớp Controller của ASP.NET Core
    public class BorrowBookController : Controller
    {
        // Khai báo một biến Uri để lưu địa chỉ cơ sở của API
        Uri baseAddress = new Uri("https://localhost:7028/api");
        // Khai báo một biến HttpClient để gửi yêu cầu HTTP đến API
        private readonly HttpClient _client;

        // Constructor của lớp BorrowBookController, khởi tạo đối tượng HttpClient
        public BorrowBookController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;

        }

        // Phương thức Index trả về view hiển thị danh sách sách để mượn
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
    }
}


/*using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebAPI.DTOs;

namespace WebApp.Controllers
{
    public class BorrowBookController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7028/api");
        private readonly HttpClient _client;

        public BorrowBookController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;

        }

        public IActionResult Index()
        {
            List<SachDTO> bookList = new List<SachDTO>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Book/GetBook").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                bookList = JsonConvert.DeserializeObject<List<SachDTO>>(data);
            }
            return View(bookList);
        }
    }
}
*/