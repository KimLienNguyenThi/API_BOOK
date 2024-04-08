using Microsoft.AspNetCore.Mvc;
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
