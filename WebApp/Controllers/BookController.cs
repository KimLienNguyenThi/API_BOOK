using Microsoft.AspNetCore.Mvc;
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
